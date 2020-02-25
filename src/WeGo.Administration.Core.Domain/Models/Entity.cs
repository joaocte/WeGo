using System;

namespace WeGo.Administration.Core.Domain.Models
{
    /// <summary>
    /// Entity base.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <inheritdoc/>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /// <inheritdoc/>
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}