using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using AutoMapper;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Mapping
{    
    public static class IProductAttributeMapper
    {       
        public static RefinementGroup ConvertToRefinementGroup(this IEnumerable<IProductAttribute> productAttributes, RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup() { Name = refinementGroupType.ToString(), GroupId = (int)refinementGroupType };

            refinementGroup.Refinements = Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>(productAttributes);

            return refinementGroup;
        }
    }
}
