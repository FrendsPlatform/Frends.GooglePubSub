namespace Frends.GooglePubSub.Consume.Definitions;

using System.ComponentModel;

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
}