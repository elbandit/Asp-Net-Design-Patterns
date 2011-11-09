using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public abstract class with_a_valid_customer
    {
        [SetUp]
        public void Context()
        {
            sut = new Customer("jhkjhkjhkj", 
                               new EmailAddress("Scott@elbandit.co.uk"),
                               new Name("Scott", "Millett"));

            When();
        }

        public abstract void When();        

        public Customer sut { get; set; }
    }
}