namespace Frends.GooglePubSub.Consume.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Options class usually contains parameters that are required.
/// </summary>
public class Options
{
    /// <summary>
    /// Sets the timeout for the pull request to PubSub.
    /// Too short timeout can lead to DeadlineExceeded exception.
    /// </summary>
    /// <example>20</example>
    [DefaultValue(20)]
    public int Timeout { get; set; }

    /// <summary>
    /// Maximum amount of messages that is pulled from the PubSub.
    /// </summary>
    /// <example>20</example>
    [DefaultValue(20)]
    public int MaxResults { get; set; }

    /// <summary>
    /// Determines if messages are acknowledged after consuming them.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool Acknowledge { get; set; }

    /// <summary>
    /// Whether to throw an error on failure.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Overrides the error message on failure. If `ThrowErrorOnFailure` is set to `true`, then the original exception will be wrapped in a new Exception with this error message.
    /// </summary>
    /// <example>Consuming messages failed: check the subscription</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("")]
    public string ErrorMessageOnFailure { get; set; } = string.Empty;
}
