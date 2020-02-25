using System;

namespace WeGo.Administration.Core.Domain.Events
{
    /// <summary>
    ///
    /// </summary>
    public class StoredEvent : Event
    {
        /// <inheritdoc/>
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        /// <inheritdoc/>
        protected StoredEvent() { }

        /// <summary>
        ///
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public string User { get; private set; }
    }
}