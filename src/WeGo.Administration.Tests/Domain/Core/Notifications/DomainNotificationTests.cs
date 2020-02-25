using System;
using WeGo.Administration.Core.Domain.Notifications;
using Xunit;

namespace WeGo.Administration.Tests.Domain.Core.Notifications
{
    public class DomainNotificationTests
    {
        [Fact(DisplayName = "Instantiate a new DomainNotification object")]
        public void InstantiateANewDomainNotificationObject_ReturnNewDomainNotification()
        {
            var key = "key";
            var value = "value";
            var domainNotification = new DomainNotification(key, value);

            Assert.Equal(key, domainNotification.Key);
            Assert.Equal(value, domainNotification.Value);
            Assert.IsType<Guid>(domainNotification.DomainNotificationId);
            Assert.Equal(1, domainNotification.Version);
        }
    }
}