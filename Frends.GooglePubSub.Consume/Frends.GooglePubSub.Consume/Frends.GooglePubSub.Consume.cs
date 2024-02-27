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

        SubscriberServiceApiClient subscriberClient = await new SubscriberServiceApiClientBuilder
        {
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction,
        }.BuildAsync(cancellationToken).ConfigureAwait(false);

        var subscriptionName = new SubscriptionName(input.ProjectID, input.SubscriptionID);

        var callSettings = new CallSettings(
            cancellationToken,
            Expiration.FromTimeout(TimeSpan.FromSeconds(options.Expiration)),
            retry: null,
            headerMutation: null,
            writeOptions: null,
            propagationToken: null);

        var response = await subscriberClient.PullAsync(subscriptionName, maxMessages: options.MaxResults, callSettings).ConfigureAwait(false);

        receivedMessages.AddRange(response.ReceivedMessages.Select(p => new OutputMessage(p.Message)));

        if (options.Acknowledge && receivedMessages.Any())
            await subscriberClient.AcknowledgeAsync(subscriptionName, response.ReceivedMessages.Select(msg => msg.AckId), cancellationToken).ConfigureAwait(false);

        return new Result(receivedMessages);
    }
}
