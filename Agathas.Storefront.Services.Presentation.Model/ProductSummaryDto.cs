using System;

namespace Agathas.Storefront.Services.Presentation.Model
{
    public class ProductSummaryDto
    {
        public int ColourId { get; set;}
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }        
        public string Price { get; set; }
        public int CategoryId { get; set; }            
    }
}