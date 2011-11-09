using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_changing_the_address_of_a_delivery_address : with_a_valid_delivery_address
    {
        private Address _newAddress;

        public override void When()
        {
            _newAddress = new Address("My Street", string.Empty, "My City", "My State", "My Country", "My Zip");

            sut.ChangeAddressTo(_newAddress);
        }

        [Test]
        public void Then_the_address_property_should_be_udpated()
        {
            Assert.AreEqual(_newAddress, sut.Address);
        }        
    }
}
