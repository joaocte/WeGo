namespace WeGo.Administration.Core.Domain.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <inheritdoc/>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        /// <inheritdoc/>
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
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
            var valueObject = obj as T;
            return valueObject is object && EqualsCore(valueObject);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <inheritdoc/>
        protected abstract bool EqualsCore(T other);

        /// <inheritdoc/>
        protected abstract int GetHashCodeCore();
    }
}