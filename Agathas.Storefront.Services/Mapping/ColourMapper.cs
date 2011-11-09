using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ColourMapper
    {
        public static IEnumerable<ColourView> ConvertToColourViews(this IEnumerable<ProductColour> colours)
        {
            return Mapper.Map<IEnumerable<ProductColour>, IEnumerable<ColourView>>(colours);   
        }       
    }
}
