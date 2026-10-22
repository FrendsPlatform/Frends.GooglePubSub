namespace Frends.GooglePubSub.Consume.Tests;

using System;
using System.Threading.Tasks;
using Frends.GooglePubSub.Consume.Definitions;
using NUnit.Framework;

[TestFixture]
internal class ErrorHandlerTest
{
    private const string CustomErrorMessage = "CustomErrorMessage";

    private static Input InvalidInput() => new()
    {
        ProjectID = "my-project",
        SubscriptionID = "my-subscription",
        ServiceAccountKeyJSON = "not a valid json key",
    };

    private static Options DefaultOptions() => new()
    {
        Timeout = 1,
        Acknowledge = true,
        MaxResults = 2,
    };

    [Test]
    public void Should_Throw_Error_When_ThrowErrorOnFailure_Is_True()
    {
        var ex = Assert.CatchAsync<Exception>(async () =>
            await GooglePubSub.Consume(InvalidInput(), DefaultOptions(), default));
        Assert.That(ex, Is.Not.Null);
    }

    [Test]
    public async Task Should_Return_Failed_Result_When_ThrowErrorOnFailure_Is_False()
    {
        var options = DefaultOptions();
        options.ThrowErrorOnFailure = false;
        var result = await GooglePubSub.Consume(InvalidInput(), options, default);
        Assert.That(result.Success, Is.False);
        Assert.That(result.Error, Is.Not.Null);
    }

    [Test]
    public void Should_Use_Custom_ErrorMessageOnFailure()
    {
        var options = DefaultOptions();
        options.ErrorMessageOnFailure = CustomErrorMessage;
        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await GooglePubSub.Consume(InvalidInput(), options, default));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Contains.Substring(CustomErrorMessage));
    }
}
