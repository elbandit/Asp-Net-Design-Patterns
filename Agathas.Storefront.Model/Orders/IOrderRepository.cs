using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Orders
{
    public interface IOrderRepository : IRepository<Order, int>
    {        
    }
}
