using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture()]
    public class When_validating_an_empty_email_address
    {
        private string _blankEmailAddress;
        private EmailValidationSpecification _emailValidationSpecification;

        [SetUp]
        public void Given()
        {
            _blankEmailAddress = string.Empty;

            _emailValidationSpecification = new EmailValidationSpecification();
        }

        [Test]
        public void Then_the_email_address_will_not_satisfiy_the_email_validation_specification()
        {
            Assert.IsFalse(_emailValidationSpecification.IsSatisfiedBy(_blankEmailAddress));
        }
    }
}