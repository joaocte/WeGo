using MediatR;
using System;

namespace WeGo.Administration.Core.Domain.Events
{
    /// <summary>
    /// Default event type.
    /// </summary>
    public abstract class Event : Message, INotification
    {
        /// <inheritdoc/>
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// timestamp of the event.
        /// </summary>
        public DateTime Timestamp { get; private set; }
    }
}