using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_updating_a_customers_email_address : with_a_valid_customer
    {        
        private EmailAddress _email;
        
        public override void When()
        {
            _email = new EmailAddress("Scott@elbandit.co.uk");

            sut.ChangeEmailTo(_email);
        }

        [Test]
        public void Then_the_customer_email_property_will_be_set()
        {
            Assert.AreEqual(_email, sut.Email); 
        }        
    }
}
