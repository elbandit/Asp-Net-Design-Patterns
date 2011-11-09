using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_creating_an_email_address_with_invalid_address
    {
        private EmailAddress _email;

        [SetUp]
        public void Given()
        {

        }

        [Test]
        [ExpectedException(typeof(InvalidEmailAddressException))]
        public void Then_an_InvalidEmailAddressException_will_be_thrown()
        {
            _email = new EmailAddress("scott@");
        }
    }
}
