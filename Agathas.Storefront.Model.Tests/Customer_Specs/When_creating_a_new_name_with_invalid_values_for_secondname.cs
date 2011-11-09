using System;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_creating_a_new_name_with_invalid_values_for_secondname
    {
        private Name _name;

        [SetUp]
        public void Given()
        {

        }

        [Test]
        [ExpectedException(typeof(InvalidNameException))]
        public void Then_a_NameInvalidException_will_be_thrown()
        {
            _name = new Name("Scott", String.Empty);
        }
    }
}