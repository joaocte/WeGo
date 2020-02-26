using MediatR;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Bus;
using WeGo.Administration.Core.Domain.Commands;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Core.Domain.Events.Interfaces;

namespace WeGo.Administration.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IEventStore eventStore;
        private readonly IMediator mediator;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            this.eventStore = eventStore;
            this.mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                eventStore?.Save(@event);

            return mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }
    }
}