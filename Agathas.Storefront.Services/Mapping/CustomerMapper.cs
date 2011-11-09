using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerDetailView(this Customer customer)
        {
            return Mapper.Map<Customer, CustomerView>(customer);          
        }       
    }
}
