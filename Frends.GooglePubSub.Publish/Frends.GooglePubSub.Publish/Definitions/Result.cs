using System.Collections.Generic;

namespace Frends.GooglePubSub.Publish.Definitions
{
    /// <summary>
    /// Publish task result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// IDs of successfully sent messages.
        /// </summary>
        /// <example>[ "12345", "54321" ]</example>
        public List<string> MessageIDs { get; internal set; }

        /// <summary>
        /// Errors that occurred during sending of messages, if any.
        /// </summary>
        /// <example>
        /// [
        ///     {  
        ///         "Data" = "My message",
        ///         "OrderingKey" = "Key1",
        ///         "Attrubutes" =
        ///         [
        ///             { "Key": "attr1", "Value": "val1" },
        ///             { "Key": "attr2", "Value": "val2" }
        ///         ]
        ///     }
        /// ]
        /// </example>
        public List<MessagePublishingError> Errors { get; internal set; }
    }
}
