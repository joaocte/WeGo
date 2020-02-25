using MediatR;
using WeGo.Administration.Core.Domain.Bus;
using WeGo.Administration.Core.Domain.Commands;
using WeGo.Administration.Core.Domain.Notifications;
using WeGo.Administration.Domain.Interfaces.UoW;

namespace WeGo.Administration.Tests.Fakes
{
    public class CommandHandlerFake : Administration.Domain.CommandHandlers.CommandHandler
    {
        public CommandHandlerFake(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public new void NotifyValidationErrors(Command command)
        {
            base.NotifyValidationErrors(command);
        }
    }
}