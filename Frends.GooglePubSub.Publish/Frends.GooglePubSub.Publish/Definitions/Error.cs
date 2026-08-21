using System;

namespace Frends.GooglePubSub.Publish.Definitions;

/// <summary>
/// Error information returned when ThrowErrorOnFailure is false.
/// </summary>
public class Error
{
    /// <summary>
    /// Error message.
    /// </summary>
    /// <example>An error occurred.</example>
    public string Message { get; set; }

    /// <summary>
    /// Additional exception information.
    /// </summary>
    /// <example>System.Exception: An error occurred.</example>
    public Exception AdditionalInfo { get; set; }
}
