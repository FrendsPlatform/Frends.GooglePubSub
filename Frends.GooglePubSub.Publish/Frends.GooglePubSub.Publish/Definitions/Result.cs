using System.Collections.Generic;

namespace Frends.GooglePubSub.Publish.Definitions;

/// <summary>
/// Publish task result
/// </summary>
public class Result
{
    /// <summary>
    /// Indicates whether the overall publish operation completed successfully.
    /// True when the batch operation completes and results are returned, even if some individual messages fail.
    /// False only when a failure prevents the overall operation from completing.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; internal set; }

    /// <summary>
    /// Error information when the overall operation fails (ThrowErrorOnFailure is false).
    /// Null when Success is true.
    /// </summary>
    /// <example>{ "Message": "An error occurred.", "AdditionalInfo": {} }</example>
    public Error Error { get; internal set; }

    /// <summary>
    /// IDs of successfully sent messages.
    /// </summary>
    /// <example>{ "12345", "54321" }</example>
    public List<string> MessageIDs { get; internal set; }

    /// <summary>
    /// Errors that occurred during sending of messages, if any.
    /// </summary>
    /// <example>
    /// { 'Message that was not sent', 'Error that happened during message sending' },
    /// {
    ///     {  
    ///         "Attrubutes" =
    ///             [
    ///                 { "Key": "attr1", "Value": "val1" },
    ///                 { "Key": "attr2", "Value": "val2" }
    ///             ]
    ///         "Data" = "My message",
    ///         "OrderingKey" = "Key1",
    ///     },
    ///     "An error occurred while sending error to topic..."
    /// }
    /// </example>
    public List<MessagePublishingError> Errors { get; internal set; }
}