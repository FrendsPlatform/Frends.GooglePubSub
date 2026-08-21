using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Frends.GooglePubSub.Publish.Definitions;

namespace Frends.GooglePubSub.Tests;

[TestFixture]
internal class ErrorHandlerTest
{
    private const string CustomErrorMessage = "CustomErrorMessage";

    private static Input InvalidInput() => new Input
    {
        ProjectID = "invalid-project",
        TopicID = "invalid-topic",
        ServiceAccountKeyJSON = string.Empty,
        Messages = new[]
        {
            new Message { Data = "test" }
        }
    };

    private static Options DefaultOptions() => new Options
    {
        ThrowErrorOnFailure = true,
        ErrorMessageOnFailure = string.Empty
    };

    [Test]
    public async Task Should_Throw_Error_When_ThrowErrorOnFailure_Is_True()
    {
        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await Publish.GooglePubSub.Publish(InvalidInput(), DefaultOptions(), CancellationToken.None));
        Assert.That(ex, Is.Not.Null);
    }

    [Test]
    public async Task Should_Return_Failed_Result_When_ThrowErrorOnFailure_Is_False()
    {
        var options = DefaultOptions();
        options.ThrowErrorOnFailure = false;
        var result = await Publish.GooglePubSub.Publish(InvalidInput(), options, CancellationToken.None);
        Assert.That(result.Success, Is.False);
    }

    [Test]
    public async Task Should_Use_Custom_ErrorMessageOnFailure()
    {
        var options = DefaultOptions();
        options.ErrorMessageOnFailure = CustomErrorMessage;
        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await Publish.GooglePubSub.Publish(InvalidInput(), options, CancellationToken.None));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain(CustomErrorMessage));
    }
}
