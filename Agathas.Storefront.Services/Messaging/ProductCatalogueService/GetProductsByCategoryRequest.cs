using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class GetProductsByCategoryRequest
    {
        public GetProductsByCategoryRequest()
        {
            ColourIds = new int[0];
            BrandIds = new int[0];
            SizeIds = new int[0];
        }
        public int CategoryId { get; set; }

        public int[] ColourIds { get; set; }
        public int[] BrandIds { get; set; }
        public int[] SizeIds { get; set; }

        public ProductsSortBy SortBy { get; set; }
        public int Index { get; set; }
        public int NumberOfResultsPerPage { get; set; }    
    }
}
