using System;
using System.Collections.Generic;
using System.Text;
using WeGo.Administration.Core.Domain.Models;
using WeGo.Administration.Domain.ValueObjects.Customer;

namespace WeGo.Administration.Domain.Entities
{
    public static class Factory
    {
        public static Customer NewCustomer(DateTime birthDate, Email email, Name name)
         => new Customer(Guid.NewGuid(), birthDate, email, name);
    }

    public class Customer : Entity
    {
        public Customer(Guid id, DateTime birthDate, Email email, Name name)
        {
            Id = id;
            BirthDate = birthDate;
            Email = email;
            Name = name;
        }

        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }

        public override bool Equals(object obj)

        {
            Customer compareTo = obj as Customer;
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
                return obj.ToString() == this.ToString();
            }

            return (compareTo).BirthDate == this.BirthDate && compareTo.Email.Equals(this.Email) && compareTo.Name.Equals(this.Name) && compareTo.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}