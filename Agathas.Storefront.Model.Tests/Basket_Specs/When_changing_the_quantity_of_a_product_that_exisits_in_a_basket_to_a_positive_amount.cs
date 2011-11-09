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
    public class When_changing_the_quantity_of_a_product_that_exisits_in_a_basket_to_a_positive_amount
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
        public void Then_the_quantity_of_that_product_should_update_to_match()
        {
             var newQty = new NonNegativeQuantity(5);

            _basket.ChangeQuantityOfProduct(newQty, _product);

            Assert.AreEqual(newQty.Value, _basket.Items().FirstOrDefault(i => i.Product == _product).Quantity.Value);
        }        
    }
}
