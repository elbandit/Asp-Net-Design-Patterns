using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.ViewModels
{
    public class BasketItemView
    {
        public int ProductId { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductSizeName { get; set; }
        public int ProductTitleId { get; set; }
        public int QuantityValue { get; set; }
        public string ProductPrice { get; set; }
        public string LineTotal { get; set; }
    }
}
