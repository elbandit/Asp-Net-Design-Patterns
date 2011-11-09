using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Brands;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class BrandMapper
    {
        public static IEnumerable<BrandView> ConvertToBrandViews(this IEnumerable<Brand> brands)
        {
            return Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandView>>(brands);
        }               
    }
}
