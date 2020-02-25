using System;
using System.Threading.Tasks;

namespace WeGo.Administration.Domain.Interfaces.UoW
{
    /// <summary>
    /// Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<bool> Commit();
    }
}