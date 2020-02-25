using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Events;
using WeGo.Administration.Domain.Interfaces.Context;
using WeGo.Administration.Infra.Data.Context;
using static MongoDB.Bson.Serialization.BsonDeserializationContext;

namespace WeGo.Administration.Infra.Data.Repository.EventSourcing
{
    public class EventStoreMongoRepository : IEventStoreRepository
    {
        /// <summary>
        ///
        /// </summary>
        protected readonly IEventStoreMongoContext context;

        /// <summary>
        /// Collection type of T
        /// </summary>
        private readonly IMongoCollection<StoredEvent> DbSet;

        public EventStoreMongoRepository(IEventStoreMongoContext context)
        {
            this.context = context;
            DbSet = context.GetCollection<StoredEvent>(typeof(StoredEvent).Name);
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            var data = await DbSet.FindAsync(Builders<StoredEvent>.Filter.Eq("_id", aggregateId));
            return data.ToList();
        }

        public async Task Store(StoredEvent theEvent)
        {
            context.AddCommand(() => DbSet.InsertOneAsync(theEvent));
            await Task.CompletedTask;
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EventStoreMongoRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        #endregion IDisposable Support
    }
}