using MediatR;
using System;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Bus;
using WeGo.Administration.Core.Domain.Commands;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Core.Domain.Events.Interfaces;

namespace WeGo.Administration.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IEventStore _eventStore;
        private readonly IMediator _mediator;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}