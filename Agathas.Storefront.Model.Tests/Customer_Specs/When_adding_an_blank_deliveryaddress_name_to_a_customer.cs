using System;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_adding_an_blank_deliveryaddress_name_to_a_customer : with_a_valid_customer
    {
        private Address _address;

        public override void When()
        {
            _address = new Address("My Street", String.Empty, "City", "State", "Country", "ZipCode");
        }

        [Test]
        [ExpectedException(typeof(InvalidAddressException))]
        public void Then_an_InvalidAddressException_will_be_thrown()
        {
            sut.AddAddress(_address, string.Empty);
        }
    }
}