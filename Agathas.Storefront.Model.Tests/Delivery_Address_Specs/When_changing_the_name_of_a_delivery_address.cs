using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public class When_changing_the_name_of_a_delivery_address : with_a_valid_delivery_address
    {
        private string newAddressName;

        public override void When()
        {
            newAddressName = "My pad in London";
            sut.ChangeNameTo(newAddressName);
        }

        [Test]
        public void Then_the_property_getter_should_be_updated()
        {
            Assert.AreEqual(newAddressName, sut.Name);
        }        
    }
}
