using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Delivery_Address_Specs
{
    [TestFixture]
    public abstract class with_a_valid_delivery_address
    {
        [SetUp]
        public void SetUp()
        {
            var address = new Address("My Street", string.Empty, "My City", "My State", "My Country", "My Zip");

            var customer = new Customer("jhkjhkjhkj", 
                                        new EmailAddress("Scott@elbandit.co.uk"),
                                        new Name("Scott", "Millett"));

            sut = new DeliveryAddress("My Delivery Address", customer, address);

            When();
        }

        public DeliveryAddress sut { get; set; }

        public abstract void When();
    }
}