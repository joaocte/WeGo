using System.Threading;
using WeGo.Administration.Core.Domain.Notifications;
using WeGo.Administration.Tests.Factory;
using Xunit;

namespace WeGo.Administration.Tests.Domain.Core.Notifications
{
    public class DomainNotificationHandlerTests
    {
        [Fact]
        public void DeveAdicionarUmaNovaNotificacaoDoTipoDomainNotification()
        {
            var domainNotificationHandler = new DomainNotificationHandler();

            var domainNotification = DomainNotificationFactory.DeveRetornarUmNovoDomainNotification();
            var cancellationToken = new CancellationToken();

            domainNotificationHandler.Handle(domainNotification, cancellationToken);

            Assert.NotEmpty(domainNotificationHandler.GetNotifications());
            Assert.True(domainNotificationHandler.HasNotifications());
        }

        [Fact]
        public void DeveInstanciarUmNovoDomainNotificationHandler()
        {
            var domainNotificationHandler = new DomainNotificationHandler();

            Assert.False(domainNotificationHandler.HasNotifications());
        }

        [Fact]
        public void DeveRealizarDispose()
        {
            var domainNotificationHandler = new DomainNotificationHandler();

            var domainNotification = DomainNotificationFactory.DeveRetornarUmNovoDomainNotification();
            var cancellationToken = new CancellationToken();

            domainNotificationHandler.Handle(domainNotification, cancellationToken);
            domainNotificationHandler.Dispose();
            Assert.Empty(domainNotificationHandler.GetNotifications());
            Assert.False(domainNotificationHandler.HasNotifications());
        }
    }
}