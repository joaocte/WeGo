using MediatR;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Bus;
using WeGo.Administration.Core.Domain.Commands;
using WeGo.Administration.Core.Domain.Notifications;
using WeGo.Administration.Domain.Interfaces.UoW;

namespace WeGo.Administration.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMediatorHandler bus;
        private readonly DomainNotificationHandler notifications;
        private readonly IUnitOfWork uow;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            this.uow = uow;
            this.notifications = (DomainNotificationHandler)notifications;
            this.bus = bus;
        }

        public async Task<bool> Commit()
        {
            if (notifications.HasNotifications()) return false;
            if (await uow.Commit()) return true;

            await bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}