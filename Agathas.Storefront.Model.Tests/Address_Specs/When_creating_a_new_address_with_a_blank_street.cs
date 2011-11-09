using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Address_Specs
{
    [TestFixture]
    public class When_creating_a_new_address_with_a_blank_street
    {
        [Test]
        [ExpectedException(typeof(InvalidAddressException))]
        public void Then_an_InvalidAddressException_will_be_thrown()
        {
            var invalidAddress = new Address(String.Empty, String.Empty, "City", "State", "Country", "PostCode");
            
            Assert.Fail();
        }
    }
}
