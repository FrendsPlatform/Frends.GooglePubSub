using Frends.GooglePubSub.Publish.Definitions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Frends.GooglePubSub.Publish;

/// <summary>
/// Google PubSub task.
/// </summary>
public static class GooglePubSub
{
    /// <summary>
    /// This tasks publishes one or more messages to Google PubSub service.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.GooglePubSub.Publish)
    /// </summary>
    /// <param name="input">Input parameters.</param>
    /// <param name="cancellationToken">Cancellation token, passed by Frends.</param>
    /// <returns>Return value containing successful message IDs and possible errors.</returns>
    public static async Task<Result> Publish([PropertyTab] Input input, CancellationToken cancellationToken)
    {
        var client = CreatePublisherClient(input);
        var messageIds = new List<string>();
        var errors = new List<MessagePublishingError>();

        foreach (var message in input.Messages)
        {
            try
            {
                var msgId = await client.PublishAsync(message.ToPubSubMessage());
                messageIds.Add(msgId);
            }
            catch (Exception ex)
            {
                errors.Add(new MessagePublishingError { Message = message, Error = ex.ToString() });
            }
        }
        client.ShutdownAsync(cancellationToken).Wait();
        var result = new Result { MessageIDs = messageIds, Errors = errors };
        return result;
    }

    private static PublisherClient CreatePublisherClient(Input input)
    {
        var clientBuilder = new PublisherClientBuilder();
        clientBuilder.TopicName = new TopicName(input.ProjectID, input.TopicID);
        clientBuilder.EmulatorDetection = Google.Api.Gax.EmulatorDetection.EmulatorOrProduction;
        clientBuilder.Settings = new PublisherClient.Settings { EnableMessageOrdering = input.EnableMessageOrdering };
        if (!string.IsNullOrEmpty(input.ServiceAccountKeyJSON))
        {
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input.ServiceAccountKeyJSON)))
            {
                var credential = ServiceAccountCredential.FromServiceAccountData(stream);
                clientBuilder.Credential = credential;
            }
        }

        return clientBuilder.Build();
    }
}
