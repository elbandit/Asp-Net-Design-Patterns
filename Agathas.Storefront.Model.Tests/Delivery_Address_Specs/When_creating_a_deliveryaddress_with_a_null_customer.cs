using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_creating_a_deliveryaddress_with_a_null_customer
    {
        [Test]
        [ExpectedException(typeof(InvalidDeliveryAddressException))]
        public void Then_an_InvalidDeliveryAddressException_will_be_thrown()
        {
            var address = new Address("My Street", string.Empty, "My City", "My State", "My Country", "My Zip");

            var deliveryAddress = new DeliveryAddress("My Address", null, address);

            Assert.Fail();
        }
    }
}
