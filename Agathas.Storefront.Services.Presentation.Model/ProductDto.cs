using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.Presentation.Model
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int ProductTitleId { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public int ColourId { get; set; }
        public string ColourName { get; set; }
    }
}
