using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using WeGo.Administration.Core.Domain.Events.Interfaces;
using WeGo.Administration.Core.Domain.Notifications;
using WeGo.Administration.Domain.Interfaces;
using WeGo.Administration.Domain.Interfaces.Context;
using WeGo.Administration.Domain.Interfaces.UoW;
using WeGo.Administration.Infra.Data.Context;
using WeGo.Administration.Infra.Data.EventSourcing;
using WeGo.Administration.Infra.Data.Repository.EventSourcing;
using WeGo.Administration.Infra.Data.UoW;

namespace Wego.Administration.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            ///Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            /// Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeGoContext, WeGoContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreMongoRepository>();
            services.AddScoped<IEventStore, MongoEventStore>();
            services.AddScoped<IEventStoreMongoContext, EventStoreMongoContext>();

            // Infra - Identity
        }
    }
}