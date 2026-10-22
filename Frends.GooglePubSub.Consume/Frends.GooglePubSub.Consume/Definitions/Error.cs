namespace Frends.GooglePubSub.Consume.Definitions;

using System;

/// <summary>
/// Error details.
/// </summary>
public class Error
{
    /// <summary>
    /// Summary of the error.
    /// </summary>
    /// <example>DeadlineExceeded error while pulling messages from subscription</example>
    public string Message { get; set; }

    /// <summary>
    /// The exception that caused the error.
    /// </summary>
    /// <example>Exception object</example>
    public Exception AdditionalInfo { get; set; }
}
