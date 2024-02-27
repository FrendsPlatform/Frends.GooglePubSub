namespace Frends.GooglePubSub.Consume.Definitions;

using System.Collections.Generic;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    internal Result(List<OutputMessage> messages)
    {
        Messages = messages;
    }

    /// <summary>
    /// IDs of successfully sent messages.
    /// </summary>
    /// <example>[ { "Hello world!", { "myCustomAttr1": "myAttrValue1" }, "271", "2024-02-27T07:53:25Z", "key" } ]</example>
    public List<OutputMessage> Messages { get; internal set; }
}
