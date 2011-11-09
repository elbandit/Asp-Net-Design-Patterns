using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Orders;
using Agathas.Storefront.Model.Orders.States;
using Agathas.Storefront.Model.Products;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Order_Specs
{    
    [TestFixture]
    public class When_creating_a_new_order
    {
        private Order _order;

        [SetUp]
        public void Given()
        {
            DomainEvents.DomainEventHandlerFactory = new StubDomaubinEventHandlerFactory();

            _order = new Order();

            ProductTitle productTitle = new ProductTitle("Hat", 9.00m, new Brand(), new Category(), new ProductColour(),
                                                         new List<Product>());

            Product product = new Product(productTitle, new ProductSize());

            _order.AddItem(product, 1);
        }

        [Test]
        public void Then_the_order_should_be_in_an_open_state()
        {
            Assert.AreEqual(OrderStates.Open.Status, _order.Status);
        }
    }
}
