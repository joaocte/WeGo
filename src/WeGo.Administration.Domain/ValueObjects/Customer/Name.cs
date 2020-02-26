using System;
using System.Collections.Generic;
using System.Text;
using WeGo.Administration.Core.Domain.Models;

namespace WeGo.Administration.Domain.ValueObjects.Customer
{
    public sealed class Name : ValueObject<Name>
    {
        private readonly string value;

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(Name));
            this.value = name;
        }

        public override string ToString()
        {
            return value;
        }

        protected override bool EqualsCore(Name other)
        {
            return value == other.value;
        }

        protected override int GetHashCodeCore()
        {
            return value.GetHashCode();
        }
    }
}