using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Basket;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Basket_Item_Specs
{
    [TestFixture]
    public class When_a_basket_item_is_created_with_a_null_product
    {
        private BasketItem _basketItem;

        [SetUp]
        public void Given()
        {
            _basketItem = new BasketItem(null, new Basket.Basket(), new NonNegativeQuantity(1));
        }

        [Test]
        public void Then_it_should_have_a_broken_rule_highlighting_the_requirement_for_a_product()
        {            
            Assert.AreEqual(BasketItemBusinessRules.ProductRequired.Rule, _basketItem.GetBrokenRules().First(x => true).Rule);
            Assert.AreEqual(BasketItemBusinessRules.ProductRequired.Property, _basketItem.GetBrokenRules().First(x => true).Property);        
        }

        [Test]
        public void Then_it_should_have_1_broken_rule()
        {
            Assert.AreEqual(1, _basketItem.GetBrokenRules().Count());
        }
    }
}
