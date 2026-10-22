namespace Frends.GooglePubSub.Consume.Definitions;

using System.Collections.Generic;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    internal Result(bool success, List<OutputMessage> messages, Error error = null)
    {
        Success = success;
        Messages = messages;
        Error = error;
    }

    /// <summary>
    /// Indicates whether the operation completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Messages consumed from Google PubSub. Null when Success is false.
    /// </summary>
    /// <example>[ { "Hello world!", { "myCustomAttr1": "myAttrValue1" }, "271", "2024-02-27T07:53:25Z", "key" } ]</example>
    public List<OutputMessage> Messages { get; private set; }

    /// <summary>
    /// Error details. Null when Success is true.
    /// </summary>
    /// <example>null</example>
    public Error Error { get; private set; }
}
