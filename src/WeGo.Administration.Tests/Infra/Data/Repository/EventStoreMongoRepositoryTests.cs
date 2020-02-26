using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Operations;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Domain.Interfaces.Context;
using WeGo.Administration.Infra.Data.Context;
using WeGo.Administration.Infra.Data.Repository.EventSourcing;
using WeGo.Administration.Tests.Factory;
using WeGo.Administration.Tests.Fakes;
using Xunit;

namespace WeGo.Administration.Tests.Infra.Data.Repository
{
    public class EventStoreMongoRepositoryTests
    {
        protected readonly IEventStoreMongoContext context;

        private readonly IAsyncCursor<StoredEvent> asyncCursor;
        private readonly IConfiguration configuration;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IMongoCollection<StoredEvent> mongoCollection;

        public EventStoreMongoRepositoryTests()
        {
            configuration = Substitute.For<IConfiguration>();
            configuration["MongoConnection:ConnectionString"].Returns(@"mongodb://localhost:27017");
            configuration["MongoConnection:Database"].Returns(typeof(StoredEvent).Name);
            mongoCollection = Substitute.For<IMongoCollection<StoredEvent>>();
            context = Substitute.For<IEventStoreMongoContext>();
            context.GetCollection<StoredEvent>(typeof(StoredEvent).Name).Returns(mongoCollection);
            eventStoreRepository = new EventStoreMongoRepository(context);
            asyncCursor = Substitute.For<IAsyncCursor<StoredEvent>>();
        }

        [Fact]
        public void QuandoTentarObterTodosStoredEvent_RetornarDadosEncontrados()
        {
            var aggregateId = Guid.NewGuid();

            mongoCollection.FindAsync(Builders<StoredEvent>.Filter.Eq("_id", aggregateId)).ReturnsForAnyArgs(asyncCursor);

            var data = eventStoreRepository.All(aggregateId).Result;

            Assert.Empty(data);
        }

        [Fact]
        public void QuantoTentarInsertirUmStoredEvent_ReturnarTaksCompleted()
        {
            var @event = new EventFake();
            var retorno = eventStoreRepository.Store(new StoredEvent(@event, DateTime.UtcNow.ToString(), "user"));

            Assert.NotNull(retorno);
        }
    }
}