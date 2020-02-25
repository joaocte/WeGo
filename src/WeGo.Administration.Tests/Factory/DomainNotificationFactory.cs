using WeGo.Administration.Core.Domain.Notifications;

namespace WeGo.Administration.Tests.Factory
{
    public static class DomainNotificationFactory
    {
        public static DomainNotification DeveRetornarUmNovoDomainNotification() =>
            new DomainNotification("key", "value");
    }
}