using System;

namespace Frends.GooglePubSub.Publish.Definitions
{
    /// <summary>
    /// Contains error for sending some message to PubSub.
    /// </summary>
    public class MessagePublishingError
    {
        /// <summary>
        /// Message that was not sent.
        /// </summary>
        /// <example>
        /// {  
        ///     "Data" = "My message",
        ///     "OrderingKey" = "Key1",
        ///     "Attrubutes" =
        ///     [
        ///         { "Key": "attr1", "Value": "val1" },
        ///         { "Key": "attr2", "Value": "val2" }
        ///     ]
        /// }
        /// </example>
        public Message Message { get; set; }

        /// <summary>
        /// Error that happened during message sending.
        /// </summary>
        /// <example>An error occurred while sending error to topic...</example>
        public string Error { get; set; }
    }
}
