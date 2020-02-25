using System;
using WeGo.Administration.Core.Domain.Events;

namespace WeGo.Administration.Tests.Factory
{
    public static class StoredEventFactory
    {
        public static StoredEvent ReturnNewStoredEvent(Event @event)
        {
            return new StoredEvent(@event, DateTime.UtcNow.ToShortDateString(), "usuario");
        }
    }
}