using System.Linq;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Basket_Specs
{
    [TestFixture]
    public class When_changing_the_quantity_of_a_product_that_exisits_in_a_basket_to_a_zero_quantity
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
        public void Then_the_product_should_be_removed()
        {
            var newQty = new NonNegativeQuantity(0);

            _basket.ChangeQuantityOfProduct(newQty, _product);

            Assert.IsNull(_basket.Items().FirstOrDefault(i => i.Product == _product));
        }
    }
}