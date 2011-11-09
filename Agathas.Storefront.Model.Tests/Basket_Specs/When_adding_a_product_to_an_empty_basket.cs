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
    public class When_adding_a_product_to_an_empty_basket
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
        public void Then_the_basket_total_should_be_equal_to_the_cost_of_the_product()
        {
            Assert.AreEqual(_product.Price, _basket.BasketTotal);
        }

        [Test]
        public void Then_the_basket_should_contain_a_total_of_one_item()
        {
            Assert.AreEqual(1, _basket.NumberOfItemsInBasket());
        }

        [Test]
        public void Then_the_basket_should_contain_a_total_of_one_of_the_product()
        {
            Assert.AreEqual(1, _basket.Items().FirstOrDefault(i => i.Product == _product).Quantity.Value);
        }
    }
}
