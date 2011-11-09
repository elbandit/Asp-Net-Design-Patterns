using Agathas.Storefront.Model.Orders;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Order_Specs
{
    [TestFixture]
    public abstract class with_valid_order
    {
        [SetUp]
        public void SetUp()
        {
            sut = new Order();

            When();
        }

        public Order sut { get; set; }

        public abstract void When();
    }
}