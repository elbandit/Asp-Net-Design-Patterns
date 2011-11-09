using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.ViewModels
{
    public class OrderItemView
    {
        public string ProductName { get; set; }
        public string ProductSizeName { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
