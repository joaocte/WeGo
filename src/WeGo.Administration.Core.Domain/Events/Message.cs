using MediatR;
using System;

namespace WeGo.Administration.Core.Domain.Events
{
    public abstract class Message : IRequest<bool>
    {
        /// <inheritdoc/>
        protected Message()
        {
            MessageType = GetType().Name;
        }

        /// <summary>
        /// Unique message id.
        /// </summary>
        public Guid AggregateId { get; protected set; }

        /// <summary>
        /// Type of message, obtained at the time of creation.
        /// </summary>
        public string MessageType { get; protected set; }
    }
}