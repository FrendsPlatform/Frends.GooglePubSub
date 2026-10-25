namespace Frends.GooglePubSub.Consume.Definitions;

using System.Collections.Generic;

/// <summary>
/// Result of the task.
/// </summary>
public class Result
{
    /// <summary>
    /// Indicates if the task completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; set; }

    /// <summary>
    /// Messages consumed from Google PubSub.
    /// </summary>
    /// <example>[ { "Hello world!", { "myCustomAttr1": "myAttrValue1" }, "271", "2024-02-27T07:53:25Z", "key" } ]</example>
    public List<OutputMessage> Messages { get; set; }

    /// <summary>
    /// Error that occurred during task execution.
    /// </summary>
    /// <example>object { string Message, Exception AdditionalInfo }</example>
    public Error Error { get; set; }
}
