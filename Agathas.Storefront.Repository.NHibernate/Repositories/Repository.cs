using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Specification;
using NHibernate;
using NHibernate.Linq;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Infrastructure.Querying;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{    
    public abstract class Repository<T, EntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {            
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public T FindBy(EntityKey Id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(Id);
        }    

        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            
            return (List<T>)criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            
            return (List<T>)criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }

        public IEnumerable<T> QueryWith(ISpecification<T> specification, int index, int count)
        {                        
            return SessionFactory.GetCurrentSession().Query<T>().Where(specification.IsSatisfied()).ToList(); 
        }

        public IEnumerable<T> QueryWith(ISpecification<T> specification)
        {                        
            return SessionFactory.GetCurrentSession().Query<T>().Where(specification.IsSatisfied()).ToList();
        }
    }
}
