using System;
using System.Collections.Generic;
using System.Text;
using WeGo.Administration.Core.Domain.Models;

namespace WeGo.Administration.Domain.ValueObjects.Customer
{
    public sealed class Email : ValueObject<Email>
    {
        private readonly string value;

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(Name));
            this.value = email;
        }

        //public override string ToString()
        //{
        //    return value;
        //}

        public override string ToString()
        {
            return value;
        }

        protected override bool EqualsCore(Email other)
        {
            return value == other.value;
        }

        protected override int GetHashCodeCore()
        {
            return value.GetHashCode();
        }
    }
}