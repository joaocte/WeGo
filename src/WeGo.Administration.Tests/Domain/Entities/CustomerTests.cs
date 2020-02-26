using System;
using System.Collections.Generic;
using System.Text;
using WeGo.Administration.Domain.Entities;
using WeGo.Administration.Domain.ValueObjects.Customer;
using Xunit;

namespace WeGo.Administration.Tests.Domain.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void DeveGarantirQueDuasInstanciasDeCustomerSaoDiferentes_ReturnFalse()
        {
            var id = Guid.NewGuid();
            var customer = new Customer(id, DateTime.Now.AddYears(-10), new Email("abc@teste.com"), new Name("joao"));
            var customer2 = new Customer(id, DateTime.Now.AddYears(-18), new Email("teste@teste.com"), new Name("joao"));

            Assert.False(customer2.Equals(customer));
        }

        [Fact]
        public void DeveGarantirQueDuasInstanciasDeCustomerSaoIguais_ReturnTrue()
        {
            var id = Guid.NewGuid();
            var birthDay = DateTime.Now.AddYears(-18);
            var customer = new Customer(id, birthDay, new Email("teste@teste.com"), new Name("joao"));
            var customer2 = new Customer(id, birthDay, new Email("teste@teste.com"), new Name("joao"));

            Assert.True(customer.Equals(customer2));
        }

        [Fact]
        public void DeveInstanciarUmNovoCustomer()
        {
            var customer = new Customer(Guid.NewGuid(), DateTime.Now.AddYears(-18), new Email("teste@teste.com"), new Name("joao"));

            Assert.NotNull(customer);
            Assert.Equal("teste@teste.com", customer.Email.ToString());
            Assert.Equal("joao", customer.Name.ToString());
        }
    }
}