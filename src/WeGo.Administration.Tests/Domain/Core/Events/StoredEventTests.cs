using NSubstitute;
using System;
using WeGo.Administration.Core.Domain.Events;
using Xunit;

namespace WeGo.Administration.Tests.Domain.Core.Events
{
    public class StoredEventFake : StoredEvent
    {
        public StoredEventFake() : base()
        {
        }
    }

    public class StoredEventTests
    {
        [Fact(DisplayName = "Instantiate a new StoredEvent")]
        public void InstantiateANewStoredEvent_ReturnNewStoredEvent()
        {
            var @event = Substitute.For<Event>();
            var data = DateTime.UtcNow.ToShortDateString();
            var usuario = "usuario";
            var storedEvent = new StoredEvent(@event, data, usuario);

            Assert.NotNull(storedEvent);
            Assert.IsType<Guid>(storedEvent.Id);
            Assert.Equal(data, storedEvent.Data);
            Assert.Equal(usuario, storedEvent.User);
            Assert.IsType<DateTime>(storedEvent.Timestamp);
        }

        [Fact(DisplayName = "Instantiate a new StoredEvent Com construtor vazio")]
        public void InstantiateANewStoredEventComConstrutorVazio_ReturnNewStoredEvent()
        {
            var @event = Substitute.For<Event>();
            var data = DateTime.UtcNow.ToShortDateString();
            var usuario = "usuario";
            var storedEvent = new StoredEventFake();

            Assert.NotNull(storedEvent);
        }
    }
}