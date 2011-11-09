using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_adding_an_null_deliveryaddress_to_a_customer : with_a_valid_customer
    {        
        private Address _invalidAddress;

        public override void When()
        {
            _invalidAddress = null;
        }

        [Test]
        [ExpectedException(typeof(InvalidAddressException))]
        public void Then_an_InvalidAddressException_will_be_thrown()
        {
            sut.AddAddress(_invalidAddress, "My Address Name");
        }        
    }
}
