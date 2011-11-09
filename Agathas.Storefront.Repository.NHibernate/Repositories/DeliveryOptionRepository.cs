using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Shipping;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class DeliveryOptionRepository : Repository<DeliveryOption, int>, IDeliveryOptionRepository
    {
        public DeliveryOptionRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
