namespace Frends.GooglePubSub.Consume.Tests;

using Frends.GooglePubSub.Consume.Definitions;

internal abstract class TestBase
{
    protected static Input DefaultInput() => new()
    {
        ProjectID = "my-project",
        SubscriptionID = "my-subscription",
        ServiceAccountKeyJSON = string.Empty,
    };

    protected static Options DefaultOptions() => new()
    {
        Timeout = 1,
        MaxResults = 2,
        Acknowledge = true,
    };
}
