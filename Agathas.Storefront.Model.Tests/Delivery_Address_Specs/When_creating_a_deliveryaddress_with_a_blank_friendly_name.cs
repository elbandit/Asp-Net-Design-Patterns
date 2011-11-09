using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_creating_a_deliveryaddress_with_a_blank_friendly_name  
    {
        private Customer _customer;
        private Address _address;

        [SetUp]
        public void Given()
        {
            _customer = new Customer("dfgdfg", new EmailAddress("Scott@elbandit.co.uk"), new Name("Scott", "Millett"));

            _address = new Address("My Street", string.Empty, "My City", "My State", "My Country", "My Zip");
        }

        [Test]
        [ExpectedException(typeof(InvalidDeliveryAddressException))]
        public void Then_an_InvalidDeliveryAddressException_should_be_thrown()
        {
            var invalidDeliveryAddress = new DeliveryAddress(string.Empty, _customer, _address);
        }
    }
}
