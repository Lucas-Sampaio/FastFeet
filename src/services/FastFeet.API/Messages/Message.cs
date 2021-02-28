using System;

namespace FastFeet.API.Messages
{
    public class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; set; }
        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
