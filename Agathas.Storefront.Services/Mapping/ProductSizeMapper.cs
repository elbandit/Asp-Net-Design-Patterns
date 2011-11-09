using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductSizeMapper
    {
        public static IEnumerable<SizeView> ConvertToSizeViews(this IEnumerable<ProductSize> sizes)
        {
            return Mapper.Map<IEnumerable<ProductSize>, IEnumerable<SizeView>>(sizes); 
        }        
    }
}
