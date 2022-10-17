using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using System.Linq;

namespace Frends.GooglePubSub.Publish.Definitions;

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