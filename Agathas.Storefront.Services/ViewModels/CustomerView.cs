using System;
using System.Collections.Generic;

namespace Agathas.Storefront.Services.ViewModels
{
    public class CustomerView
    {
        public string IdentityToken { get; set; }
        public string NameFirstName { get; set; }
        public string NameSecondName { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddressBook { get; set; }
    } 
}
