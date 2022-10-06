using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using System.Linq;

namespace Frends.GooglePubSub.Publish.Definitions;

/// <summary>
/// Message attribute.
/// </summary>
public class MessageAttribute
{
    /// <summary>
    /// Default ctor.
    /// </summary>
    public MessageAttribute()
    { }

    /// <summary>
    /// Ctor with key and value params.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public MessageAttribute(string key, string value)
    {
        Key = key;
        Value = value;
    }

    /// <summary>
    /// Attribute key.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Attribute value.
    /// </summary>
    public string Value { get; set; }
}
/// <summary>
/// Message to be sent to Google PubSub.
/// </summary>
public class Message
{
    /// <summary>
    /// Dictionary of attributes for the message.
    /// </summary>
    /// <example>
    /// [
    ///     { "attr1", "value1" },
    ///     { "attr2", "value2" }
    /// ]</example>
    public MessageAttribute[] Attributes { get; set; }

    /// <summary>
    /// Message data.
    /// </summary>
    /// <example>Hello, world!</example>
    public string Data { get; set; }

    /// <summary>
    /// Message ordering key.
    /// </summary>
    /// <example>12345</example>
    public string OrderingKey { get; set; } = "";

    internal PubsubMessage ToPubSubMessage()
    {
        var result = new PubsubMessage
        {
            Data = ByteString.CopyFromUtf8(Data),
            OrderingKey = OrderingKey == null ? "" : OrderingKey,
        };
        result.Attributes.Add(Attributes.ToDictionary(o => o.Key, o => o.Value));
        return result;
    }
}