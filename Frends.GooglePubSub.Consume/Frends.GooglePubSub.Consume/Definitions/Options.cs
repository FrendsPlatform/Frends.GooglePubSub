namespace Frends.GooglePubSub.Consume.Definitions;

using System.ComponentModel;

/// <summary>
/// Options class usually contains parameters that are required.
/// </summary>
public class Options
{
    /// <summary>
    /// Expiration determines how long Task will wait for messages if there aren't any.
    /// </summary>
    /// <example>30</example>
    [DefaultValue(1)]
    public int Expiration { get; set; }

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