namespace Frends.GooglePubSub.Consume.Definitions;

/// <summary>
/// Message attribute.
/// </summary>
public class MessageAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageAttribute"/> class.
    /// Default ctor.
    /// </summary>
    public MessageAttribute()
    {
    }

    internal MessageAttribute(string key, string value)
    {
        Key = key;
        Value = value;
    }

    /// <summary>
    /// Attribute key.
    /// </summary>
    /// <example>foo</example>
    public string Key { get; set; }

    /// <summary>
    /// Attribute value.
    /// </summary>
    /// <example>bar</example>
    public string Value { get; set; }
}
