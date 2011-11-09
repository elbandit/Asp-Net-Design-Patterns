using System;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_changing_the_address_part_of_a_delivery_address_with_an_invalid_value : with_a_valid_delivery_address 
    {
        public override void When()
        {

        }

        [Test]
        [ExpectedException(typeof(InvalidDeliveryAddressException))]
        public void Then_an_InvalidAddressException_should_be_thrown()
        {
            sut.ChangeAddressTo(null);
        }

        
    }
}