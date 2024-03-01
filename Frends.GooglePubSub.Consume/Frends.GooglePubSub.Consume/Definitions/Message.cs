namespace Frends.GooglePubSub.Consume.Definitions;

using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using System.Linq;

/// <summary>
/// Message consumed from Google PubSub.
/// </summary>s
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
    public string OrderingKey { get; set; } = string.Empty;

    internal PubsubMessage ToPubSubMessage()
    {
        var result = new PubsubMessage
        {
            Data = ByteString.CopyFromUtf8(Data),
            OrderingKey = OrderingKey ?? string.Empty,
        };
        result.Attributes.Add(Attributes.ToDictionary(o => o.Key, o => o.Value));
        return result;
    }
}