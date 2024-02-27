namespace Frends.GooglePubSub.Consume.Definitions;

using System;
using System.Collections.Generic;
using Google.Cloud.PubSub.V1;
using Google.Protobuf.Collections;

/// <summary>
/// Class for OutputMessage.
/// </summary>
public class OutputMessage
{
    internal OutputMessage(PubsubMessage message)
    {
        Data = message.Data.ToStringUtf8();
        Attributes = ToDictionary(message.Attributes);
        MessageId = message.MessageId;
        PublishTime = message.PublishTime.ToDateTime();
        OrderingKey = message.OrderingKey;
    }

    /// <summary>
    /// Pubsub Message Data  field converted to utf-8 string.
    /// </summary>
    /// <example>Hello world!</example>
    public string Data { get; set; }

    /// <summary>
    /// Pubsub Message Attributes field converted to dictionary.
    /// </summary>
    /// <example>{ "myCustomAttr1": "myAttrValue1" }</example>
    public Dictionary<string, string> Attributes { get; set; }

    /// <summary>
    /// Pubsub Message MessageId field.
    /// </summary>
    /// <example>271</example>
    public string MessageId { get; set; }

    /// <summary>
    /// Pubsub Message PublishTime field converted to DateTime.
    /// </summary>
    /// <example>2024-02-27T07:53:25Z</example>
    public DateTime PublishTime { get; set; }

    /// <summary>
    /// Pubsub Message OrderingKey field.
    /// </summary>
    /// <example>key</example>
    public string OrderingKey { get; set; }

    private static Dictionary<string, string> ToDictionary(MapField<string, string> attributes)
    {
        var dict = new Dictionary<string, string>();
        foreach (var entry in attributes)
        {
            dict.Add(entry.Key, entry.Value);
        }

        return dict;
    }
}