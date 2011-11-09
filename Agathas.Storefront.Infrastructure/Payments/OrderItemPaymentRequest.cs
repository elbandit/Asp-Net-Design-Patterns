using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Payments
{
    public class OrderItemPaymentRequest
    {
        public int Id { get; set;}
        public string ProductName { get; set;}
        public decimal Price { get; set;}
        public int Quantity { get; set; }        
    }
}
