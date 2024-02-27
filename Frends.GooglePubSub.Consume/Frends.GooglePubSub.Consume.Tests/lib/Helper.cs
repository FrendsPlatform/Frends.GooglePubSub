namespace Frends.GooglePubSub.Consume.Tests.lib;

using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Frends.GooglePubSub.Consume.Definitions;

internal class Helper
{
    internal static List<string> Publish(Input input, string topicID, Message[] messages, CancellationToken cancellationToken)
    {
        var client = CreatePublisherClient(input, topicID);
        var messageIds = new List<string>();

        foreach (var msgId in messages.Select(async p => await client.PublishAsync(p.ToPubSubMessage())))
            messageIds.Add(msgId.Result);

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