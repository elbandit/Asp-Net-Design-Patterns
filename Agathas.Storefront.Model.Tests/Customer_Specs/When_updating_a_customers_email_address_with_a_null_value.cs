using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_updating_a_customers_email_address_with_a_null_value : with_a_valid_customer
    {        
        public override void When()
        {                        
        }

        [Test]
        [ExpectedException(typeof(InvalidEmailAddressException))]
        public void Then_an_InvalidEmailAddressException_will_be_thrown()
        {
            sut.ChangeEmailTo(null);
        }
    }
}