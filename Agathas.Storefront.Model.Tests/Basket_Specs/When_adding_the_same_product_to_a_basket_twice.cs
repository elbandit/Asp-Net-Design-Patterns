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
    public class When_adding_the_same_product_to_a_basket_twice
    {
        private Basket.Basket _basket;
        private Product _product;

        [SetUp]
        public void Given()
        {
            _basket = new Basket.Basket();

            _product = new Product(new ProductTitle("Product A", 15m, new Brand(), new Category(), new ProductColour(), null), new ProductSize());

            _basket.Add(_product);
            _basket.Add(_product);
        }

        [Test]
        public void Then_the_basket_total_should_be_equal_to_the_cost_of_2x_the_product()
        {
            Assert.AreEqual(_product.Price * 2, _basket.BasketTotal);
        }

        [Test]
        public void Then_the_total_number_of_items_in_a_basket_should_be_equal_to_2()
        {
            Assert.AreEqual(2, _basket.NumberOfItemsInBasket());
        }

        [Test]
        public void Then_the_basket_items_total_should_be_equal_to_2x_the_cost_of_the_product()
        {
            Assert.AreEqual(_product.Price * 2, _basket.ItemsTotal);
        }

        [Test]
        public void Then_the_quantity_for_the_product_should_be_2()
        {
            Assert.AreEqual(2, _basket.Items().FirstOrDefault(i => i.Product == _product).Quantity.Value);
        }

        [Test]
        public void Then_the_line_total_for_the_product_should_equal_to_the_cost_of_2x_the_product()
        {
            Assert.AreEqual(_product.Price * 2, _basket.Items().FirstOrDefault(i => i.Product == _product).LineTotal());
        }       
    }
}
