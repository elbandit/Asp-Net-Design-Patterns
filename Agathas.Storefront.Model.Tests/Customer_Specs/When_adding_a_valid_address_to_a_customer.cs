using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests.Customer_Specs
{
    [TestFixture]
    public class When_adding_a_valid_address_to_a_customer : with_a_valid_customer 
    {
        private Address _address;
        private string _deliveryAddressName;

        public override void When()
        {
            _deliveryAddressName = "My Work Pad";
            _address = new Address("Street", String.Empty, "City", "State", "Country", "Post Code");

            sut.AddAddress(_address, _deliveryAddressName);
        }

        [Test]
        public void Then_the_address_should_appear_in_the_customers_list()
        {
            Assert.AreEqual(1, sut.DeliveryAddressBook.Count());

            Assert.IsTrue(sut.DeliveryAddressBook.Any(a => a.Address == _address));            
        }
    }
}
