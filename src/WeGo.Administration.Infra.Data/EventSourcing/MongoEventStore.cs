using Newtonsoft.Json;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Core.Domain.Events.Interfaces;
using WeGo.Administration.Domain.Interfaces;
using WeGo.Administration.Infra.Data.Repository.EventSourcing;

namespace WeGo.Administration.Infra.Data.EventSourcing
{
    public class MongoEventStore : IEventStore
    {
        private readonly IEventStoreRepository eventStoreRepository;
        ///private readonly IUser user;

        public MongoEventStore(IEventStoreRepository eventStoreRepository)
        {
            this.eventStoreRepository = eventStoreRepository;
            //this.user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "user.Name");

            eventStoreRepository.Store(storedEvent);
        }
    }
}