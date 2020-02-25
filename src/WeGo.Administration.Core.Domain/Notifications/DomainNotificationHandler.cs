using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeGo.Administration.Core.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            notifications = new List<DomainNotification>();
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return notifications;
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
    }
}