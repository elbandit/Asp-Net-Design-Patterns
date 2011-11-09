using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Products
{
    public interface IProductTitleRepository : IReadOnlyRepository<ProductTitle, int>
    {        
    }
}
