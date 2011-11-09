using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_changing_the_name_of_a_customer : with_a_valid_customer
    {
        private Name _newName;

        public override void When()
        {
            _newName = new Name("Mickey", "Mouse");

            sut.ChangeNameTo(_newName);
        }

        [Test]
        public void Then_the_property_should_match_the_new_name()
        {
            Assert.AreEqual(_newName, sut.Name);
        }
    }
}
