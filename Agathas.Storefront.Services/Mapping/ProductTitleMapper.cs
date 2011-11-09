using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ConvertToProductViews(this IEnumerable<ProductTitle> products)
        {
            return Mapper.Map<IEnumerable<ProductTitle>, IEnumerable<ProductSummaryView>>(products);           
        }

        public static ProductView ConvertToProductDetailView(this ProductTitle product)
        {
            return Mapper.Map<ProductTitle, ProductView>(product);
        }        
    }
}
