using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Models;
using WeGo.Administration.Domain.Interfaces.Context;
using WeGo.Administration.Domain.Interfaces.Respoitory;

namespace WeGo.Administration.Infra.Data.Repository
{
    /// <inheritdoc/>
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        ///
        /// </summary>
        protected readonly IWeGoContext Context;

        /// <summary>
        /// Collection type of T
        /// </summary>
        private readonly IMongoCollection<T> DbSet;

        /// <inheritdoc/>
        public Repository(IWeGoContext context)
        {
            this.Context = context;
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        /// <inheritdoc/>
        public virtual Task Add(T obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return data.ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<T> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        /// <inheritdoc/>
        public virtual Task Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public virtual Task Update(T obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.Id), obj));

            return Task.CompletedTask;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }

                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
}