using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_creating_a_delivery_address_with_a_null_address
    {

        [Test]
        [ExpectedException(typeof(InvalidDeliveryAddressException))]
        public void Then_an_InvalidDeliveryAddressException_should_be_thrown()
        {
            var customer = new Customer("jhkjhkjhkj",
                                      new EmailAddress("Scott@elbandit.co.uk"),
                                      new Name("Scott", "Millett"));

            var invalidDeliveryAddress = new DeliveryAddress("My Work Address", customer, null);

            Assert.Fail();
        }
    }
}
