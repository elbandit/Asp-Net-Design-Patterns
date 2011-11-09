using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Basket_Specs
{
    [TestFixture]
    public class When_removing_an_exisitng_product_from_a_basket
    {
        private Basket.Basket _basket;
        private Product _product;

        [SetUp]
        public void Given()
        {
            _basket = new Basket.Basket();

            _product = new Product(new ProductTitle("Product A", 15m, new Brand(), new Category(), new ProductColour(), null), new ProductSize());

            _basket.Add(_product);
        }

        [Test]
        public void Then_the_product_should_no_longer_be_in_the_basket()
        {
            _basket.Remove(_product);

            Assert.IsNull(_basket.Items().FirstOrDefault(i => i.Product == _product));

            Assert.AreEqual(0, _basket.NumberOfItemsInBasket());
        }
    }
}
