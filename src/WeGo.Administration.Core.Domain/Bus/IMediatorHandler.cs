using System.Threading.Tasks;
using WeGo.Administration.Core.Domain.Commands;
using WeGo.Administration.Core.Domain.Events;

namespace WeGo.Administration.Core.Domain.Bus
{
    /// <summary>
    /// Provides an event and command handler.
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// Query event.
        /// </summary>
        /// <typeparam name="T">Type of event.</typeparam>
        /// <param name="event">Query event to execute.</param>
        /// <returns></returns>
        Task RaiseEvent<T>(T @event) where T : Event;

        /// <summary>
        /// Handling event.
        /// </summary>
        /// <typeparam name="T">Type of event.</typeparam>
        /// <param name="command">Command to execute.</param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;
    }
}