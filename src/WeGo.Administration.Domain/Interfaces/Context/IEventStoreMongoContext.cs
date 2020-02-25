using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace WeGo.Administration.Domain.Interfaces.Context
{
    /// <summary>
    ///
    /// </summary>
    public interface IEventStoreMongoContext : IDisposable
    {
        /// <summary>
        /// add a command to run.
        /// </summary>
        /// <param name="func">the comand to add.</param>
        void AddCommand(Func<Task> func);

        /// <summary>
        /// get the collection name
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="name"> name of collection.</param>
        /// <returns></returns>
        IMongoCollection<T> GetCollection<T>(string name);

        /// <summary>
        /// Saves all operations to the database.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChanges();
    }
}