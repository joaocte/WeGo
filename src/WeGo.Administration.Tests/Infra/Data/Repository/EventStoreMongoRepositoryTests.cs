using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Infra.Data.Context;
using WeGo.Administration.Infra.Data.Repository.EventSourcing;
using WeGo.Administration.Tests.Fakes;
using Xunit;

namespace WeGo.Administration.Tests.Infra.Data.Repository
{
    public class EventStoreMongoRepositoryTests
    {
        protected readonly EventStoreMongoContext context;

        private readonly IConfiguration configuration;
        private readonly IEventStoreRepository eventStoreRepository;

        public EventStoreMongoRepositoryTests()
        {
            configuration = Substitute.For<IConfiguration>();
            configuration["MongoConnection:ConnectionString"].Returns(@"mongodb://localhost:27017");
            configuration["MongoConnection:Database"].Returns(typeof(StoredEvent).Name);

            context = Substitute.For<EventStoreMongoContext>(configuration);
            eventStoreRepository = new EventStoreMongoRepository(context);
        }

        [Fact]
        public void QuandoTentarObterTodosStoredEvent_RetornarDadosEncontrados()
        {
            var data = eventStoreRepository.All(Arg.Any<Guid>()).Result;
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