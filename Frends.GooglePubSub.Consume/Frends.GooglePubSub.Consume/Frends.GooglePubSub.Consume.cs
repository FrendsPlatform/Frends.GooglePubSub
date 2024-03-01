namespace Frends.GooglePubSub.Consume;

using Google.Api.Gax;
using Google.Api.Gax.Grpc;
using Google.Cloud.PubSub.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Frends.GooglePubSub.Consume.Definitions;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Grpc.Core;

/// <summary>
/// Google PubSub Task.
/// </summary>
public static class GooglePubSub
{
    /// <summary>
    /// Frends Task for consuming messages from Google Cloud PubSub service.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.GooglePubSub.Consume).
    /// </summary>
    /// <param name="input">Input parameters.</param>
    /// <param name="options">Optional options.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object [ List&lt;OutputMessage&gt; Messages [ { string Data, Dictionary Attributes, string MessageId, DateTime PublishTime, string OrderingKey } ] } </returns>
    public static async Task<Result> Consume([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        var receivedMessages = new List<OutputMessage>();

        var subscriberClient = await CreateSubscriberClient(input, cancellationToken);

        var subscriptionName = new SubscriptionName(input.ProjectID, input.SubscriptionID);

        var callSettings = new CallSettings(
            cancellationToken,
            Expiration.FromTimeout(TimeSpan.FromSeconds(options.Timeout)),
            retry: null,
            headerMutation: null,
            writeOptions: null,
            propagationToken: null);

        try
        {
            var response = await subscriberClient.PullAsync(subscriptionName, maxMessages: options.MaxResults, callSettings).ConfigureAwait(false);

            receivedMessages.AddRange(response.ReceivedMessages.Select(p => new OutputMessage(p.Message)));

            if (options.Acknowledge && receivedMessages.Any())
                await subscriberClient.AcknowledgeAsync(subscriptionName, response.ReceivedMessages.Select(msg => msg.AckId), cancellationToken).ConfigureAwait(false);
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
        {
            throw new ArgumentException($"DeadlineExceeded error while pulling messages from subscription: {ex.Message}.\nConsider increasing the timeout parameters.");
        }

        return new Result(receivedMessages);
    }

    private static async Task<SubscriberServiceApiClient> CreateSubscriberClient(Input input, CancellationToken cancellationToken)
    {
        var clientBuilder = new SubscriberServiceApiClientBuilder
        {
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction,
        };

        if (!string.IsNullOrEmpty(input.ServiceAccountKeyJSON))
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input.ServiceAccountKeyJSON));
            var credential = ServiceAccountCredential.FromServiceAccountData(stream);
            clientBuilder.Credential = credential;
        }

        return await clientBuilder.BuildAsync(cancellationToken).ConfigureAwait(false);
    }
}
