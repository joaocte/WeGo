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
            Entity compareTo = obj as Entity;
            if (compareTo is null)
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (obj is string)
            {
                return compareTo.ToString() == this.Id.ToString();
            }

            return ((Entity)obj).Id == Id;
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