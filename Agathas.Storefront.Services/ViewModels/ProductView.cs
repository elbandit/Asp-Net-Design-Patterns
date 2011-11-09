using System;
using System.Collections.Generic;

namespace Agathas.Storefront.Services.ViewModels
{
    public class ProductView  
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public IEnumerable<ProductSizeOption> Products { get; set; }
    }
}