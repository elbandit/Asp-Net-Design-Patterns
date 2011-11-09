using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.Querying;

namespace Agathas.Storefront.Model.Products
{
    public interface IProductRepository : IReadOnlyRepository<Product, int>
    {

    }
}
