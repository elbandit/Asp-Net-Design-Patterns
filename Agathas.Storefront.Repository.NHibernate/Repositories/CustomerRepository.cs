using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Customers;
using NHibernate;
using NHibernate.Criterion;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow) 
            : base(uow)
        {
        }

        public Customer FindBy(string identityToken)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(Customer))
               .Add(Expression.Eq(PropertyNameHelper.ResolvePropertyName<Customer>(c => c.IdentityToken), identityToken));

            IList<Customer> customers = criteriaQuery.List<Customer>();

            Customer customer = customers.FirstOrDefault();
            return customer;
        }
    }
}
