namespace Frends.GooglePubSub.Consume.Tests.lib;

using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Frends.GooglePubSub.Consume.Definitions;

internal class Helper
{
    internal static async Task<List<string>> Publish(Input input, string topicID, Message[] messages, CancellationToken cancellationToken)
    {
        var client = CreatePublisherClient(input, topicID);
        var messageIds = new List<string>();

        foreach (var message in messages)
        {
            var msgId = await client.PublishAsync(message.ToPubSubMessage());
            messageIds.Add(msgId);
        }

        client.ShutdownAsync(cancellationToken).Wait(cancellationToken);
        return messageIds;
    }

    internal static PublisherClient CreatePublisherClient(Input input, string topicID)
    {
        var clientBuilder = new PublisherClientBuilder
        {
            TopicName = new TopicName(input.ProjectID, topicID),
            EmulatorDetection = Google.Api.Gax.EmulatorDetection.EmulatorOrProduction,
        };
        if (!string.IsNullOrEmpty(input.ServiceAccountKeyJSON))
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input.ServiceAccountKeyJSON));
            var credential = ServiceAccountCredential.FromServiceAccountData(stream);
            clientBuilder.Credential = credential;
        }

        return clientBuilder.Build();
    }
}