using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Events;

namespace WeGo.Administration.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        Task<IList<StoredEvent>> All(Guid aggregateId);

        Task Store(StoredEvent theEvent);
    }
}