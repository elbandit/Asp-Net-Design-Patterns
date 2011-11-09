using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Basket_Specs
{
    [TestFixture]
    public class When_not_selecting_a_delivery_option_for_a_basket
    {
        private Basket.Basket _basket;        

        [SetUp]
        public void Given()
        {
            _basket = new Basket.Basket();            
        }

        [Test]
        public void Then_the_delivery_cost_should_be_0()
        {
           Assert.AreEqual(0, _basket.DeliveryCost());
        }
    }
}
