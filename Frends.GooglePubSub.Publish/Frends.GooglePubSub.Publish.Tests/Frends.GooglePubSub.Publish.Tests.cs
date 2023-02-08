using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Frends.GooglePubSub.Publish.Definitions;
using System.Threading;

namespace Frends.GooglePubSub.Tests;

[TestFixture]
class Tests
{
    private const string TestProjectId = "my-project";
    private const string TestTopicId = "my-topic";

    [SetUp]
    public void SetUp()
    {
        Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8681");
    }

    [Test]
    public async Task PublishTest()
    {
        var result = await Publish.GooglePubSub.Publish(new Input
        {
            ProjectID = TestProjectId,
            TopicID = TestTopicId,
            ServiceAccountKeyJSON = string.Empty, // fileContent,
            Messages = new []
            {
                new Message
                {
                    Data = "Hello, world!",
                    Attributes = new [] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                    OrderingKey = ""
                },
                new Message
                {
                    Data = "Hello, world 2!",
                    Attributes = new [] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                    OrderingKey = ""
                }
            }
        }, CancellationToken.None);
            
        Assert.AreEqual(0, result.Errors.Count, string.Join(Environment.NewLine, result.Errors.Select(e => e.Error)));
        Assert.AreEqual(2, result.MessageIDs.Count);
        foreach(var messageID in result.MessageIDs) Assert.NotNull(messageID);
    }

    [Test]
    public async Task PublishWithOrderingNumberTest()
    {
        var result = await Publish.GooglePubSub.Publish(new Input
        {
            ProjectID = TestProjectId,
            TopicID = TestTopicId,
            ServiceAccountKeyJSON = string.Empty, // fileContent,
            EnableMessageOrdering = true,
            Messages = new[]
            {
                new Message
                {
                    Data = "Hello, world!",
                    Attributes = new [] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                    OrderingKey = "key1"
                },
                new Message
                {
                    Data = "Hello, world 2!",
                    Attributes = new [] { new MessageAttribute("myCustomAttr1", "myAttrValue1") },
                    OrderingKey = "key2"
                }
            }
        }, CancellationToken.None);

        Assert.AreEqual(0, result.Errors.Count, string.Join(Environment.NewLine, result.Errors.Select(e => e.Error)));
        Assert.AreEqual(2, result.MessageIDs.Count);
        foreach (var messageID in result.MessageIDs) Assert.NotNull(messageID);
    }
}