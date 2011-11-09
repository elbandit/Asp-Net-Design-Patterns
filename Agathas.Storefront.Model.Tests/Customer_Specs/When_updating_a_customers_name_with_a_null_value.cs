using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_updating_a_customers_name_with_a_null_value : with_a_valid_customer 
    {
        public override void When()
        {
            
        }

        [Test]
        [ExpectedException(typeof(InvalidNameException))]
        public void Then_an_InvalidNameException_will_be_thrown()
        {
            sut.ChangeNameTo(null);
        }
    }
}
