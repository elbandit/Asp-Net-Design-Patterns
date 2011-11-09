using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Shipping;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Shipping_Specs
{
    [TestFixture]
    public class When_determining_the_cost_of_delivery_with_a_basket_that_exceeds_the_free_delivery_threshold
    {
        private DeliveryOption _deliveryOption;
        private decimal _freeDeliveryThreshold;

        [SetUp]
        public void Given()
        {
            _freeDeliveryThreshold = 50m;
            
            _deliveryOption = new DeliveryOption(_freeDeliveryThreshold, 10m, null);
        }

        [Test]
        public void Then_the_cost_of_delivery_should_be_0()
        {
            Assert.AreEqual(0, _deliveryOption.GetDeliveryChargeForBasketTotalOf(_freeDeliveryThreshold * 2));
        }
    }
}
