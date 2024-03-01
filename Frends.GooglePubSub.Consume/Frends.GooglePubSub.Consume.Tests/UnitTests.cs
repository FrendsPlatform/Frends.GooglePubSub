namespace Frends.GooglePubSub.Consume.Tests;

using System;
using System.Threading.Tasks;
using Frends.GooglePubSub.Consume;
using Frends.GooglePubSub.Consume.Definitions;
using Frends.GooglePubSub.Consume.Tests.lib;
using NUnit.Framework;

[TestFixture]
internal class UnitTests
{
    private const string TestProjectId = "my-project";
    private const string TestTopicId = "my-topic";
    private const string TestSubscribtionId = "my-subscription";

    private Input input;
    private Options options;
    private Message[] messages;

    [SetUp]
    public async Task SetUp()
    {
        Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8681");

        input = new Input
        {
            ProjectID = TestProjectId,
            SubscriptionID = TestSubscribtionId,
            ServiceAccountKeyJSON = string.Empty,
        };

        options = new Options
        {
            Timeout = 1,
            Acknowledge = true,
            MaxResults = 2,
        };

        messages = new[]
        {
            new Message
            {
                Data = "Hello, world!",
                Attributes = new[] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                OrderingKey = string.Empty,
            },
            new Message
            {
                Data = "Hello, world 2!",
                Attributes = new[] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                OrderingKey = string.Empty,
            },
        };

        await GooglePubSub.Consume(input, options, default);
    }

    [Test]
    public async Task ConsumeWithAck()
    {
        var publishMessages = Helper.Publish(input, TestTopicId, messages, default);
        var result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(publishMessages.Count, result.Messages.Count);
    }

    [Test]
    public async Task ConsumeWithNAck()
    {
        var publishMessages = Helper.Publish(input, TestTopicId, messages, default);

        var result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(publishMessages.Count, result.Messages.Count);

        var topicID = "my-another-topic";
        input.SubscriptionID = "my-another-subscription";
        publishMessages = Helper.Publish(input, topicID, messages, default);

        result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(publishMessages.Count, result.Messages.Count);

        result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(0, result.Messages.Count);
    }

    [Test]
    public async Task ConsumeWithNoMessages()
    {
        options.MaxResults = 1;
        var result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(0, result.Messages.Count);
    }

    [Test]
    public async Task ConsumeWithoutAcknowledge()
    {
        Helper.Publish(input, TestTopicId, messages, default);

        options.MaxResults = 1;
        options.Acknowledge = false;
        var result = await GooglePubSub.Consume(input, options, default);
        Assert.AreEqual(1, result.Messages.Count);
    }
}