using FluentValidation.Results;
using System;
using WeGo.Administration.Core.Domain.Events;

namespace WeGo.Administration.Core.Domain.Commands
{
    /// <summary>
    /// Command base.
    /// </summary>
    public abstract class Command : Message
    {
        /// <inheritdoc/>
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Timestamp of command.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Command validation result.
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// To tell if the command is valid.
        /// </summary>
        /// <returns>true if the command is valid, otherwise false.</returns>
        public abstract bool IsValid();
    }
}