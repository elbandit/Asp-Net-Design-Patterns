using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Order_Specs
{
    [TestFixture]
    public class When_paying_for_an_order_that_has_already_been_paid_for : with_valid_order
    {
        public override void When()
        {
            
        }

        [Test]
        public void Then_an_OrderAlreadyPaidForException_should_be_thrown()
        {
            Assert.Fail();
        }
    }
}
