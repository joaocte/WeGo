using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Models;

namespace WeGo.Administration.Domain.Interfaces.Respoitory
{
    /// <summary>
    /// Provides methods for database operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : Entity
    {
        /// <summary>
        /// Add an object of type <typeparamref name="T"/> to the database.
        /// </summary>
        /// <param name="obj">Object with the information to be added.</param>
        Task Add(T obj);

        /// <summary>
        /// Get all objects of type <typeparamref name="T"/> database.
        /// </summary>
        /// <returns>An IEnumerable containing all objects.</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get an object of type <typeparamref name="T"/> to the given Id.
        /// </summary>
        /// <param name="id">Unique identifier of the object to be removed.</param>
        /// <returns>Object of type <typeparamref name="T"/></returns>
        Task<T> GetById(Guid id);

        /// <summary>
        /// Removes the <typeparamref name="T"/> object for the given id from the database.
        /// </summary>
        /// <param name="id">Unique identifier of the object to be removed.</param>
        Task Remove(Guid id);

        /// <summary>
        /// base changes persist.
        /// </summary>
        /// <returns>Total affected rows.</returns>
        Task<int> SaveChanges();

        /// <summary>
        /// Updates object with new information.
        /// </summary>
        /// <param name="obj">Object with the information to be updated.</param>
        Task Update(T obj);
    }
}