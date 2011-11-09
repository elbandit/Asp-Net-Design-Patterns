using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture()]
    public class When_validating_an_invalid_email_address
    {
        private string _invalidEmailAddress;
        private EmailValidationSpecification _emailValidationSpecification;

        [SetUp]
        public void Given()
        {
            _invalidEmailAddress = "gg@kkkkk";

            _emailValidationSpecification = new EmailValidationSpecification();
        }

        [Test]
        public void Then_the_email_address_will_not_satisfiy_the_email_validation_specification()
        {
            Assert.IsFalse(_emailValidationSpecification.IsSatisfiedBy(_invalidEmailAddress));
        }              
    }
}
