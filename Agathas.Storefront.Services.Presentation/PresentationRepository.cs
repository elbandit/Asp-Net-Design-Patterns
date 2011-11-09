using System;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Infrastructure.Presentation;
using Agathas.Storefront.Infrastructure.Specification;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace Agathas.Storefront.Services.Presentation
{
    public class PresentationRepository : IPresentationRepository
    {
        public IEnumerable<T> FindByType<T>()
        {
            using (var session = SessionFactory.GetNewSession())
            {
                ICriteria criteriaQuery = session.CreateCriteria(typeof(T));

                return (List<T>)criteriaQuery.List<T>();
            }      
        }

        public IEnumerable<T> FindByExample<T>(object propertiesAndValues)
        {
            var dictionary = GetPropertyInformation(propertiesAndValues);

            using (var session = SessionFactory.GetNewSession())
            {
                ICriteria criteriaQuery = session.CreateCriteria(typeof(T));

                foreach (var pair in dictionary)
                {
                    ICriterion criterion = Expression.Eq(pair.Key, pair.Value);

                    criteriaQuery.Add(criterion);
                }

                return criteriaQuery.List<T>();
            }     
        }

        public IEnumerable<T> FindBySpec<T>(ISpecification<T> specification)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                return session.Query<T>().Where(specification.IsSatisfied()).ToList(); 
            }      
        }

        public T FindFirstByExample<T>(object propertiesAndValues)
        {
            var dictionary = GetPropertyInformation(propertiesAndValues);
                                               
            using (var session = SessionFactory.GetNewSession())
            {
                ICriteria criteriaQuery = session.CreateCriteria(typeof(T));

                foreach (var pair in dictionary)
                {
                    ICriterion criterion = Expression.Eq(pair.Key, pair.Value);

                    criteriaQuery.Add(criterion);
                }

                return criteriaQuery.List<T>().SingleOrDefault();
            }            
        }

        private static Dictionary<string, object> GetPropertyInformation(object example)
        {
            var exampleData = new Dictionary<string, object>();

            example.GetType().GetProperties().ToList().ForEach(x => exampleData.Add(x.Name, x.GetValue(example, new object[] { })));

            return exampleData;
        }

        public T FindFirstBySpec<T>(ISpecification<T> specification)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                return session.Query<T>().Where(specification.IsSatisfied()).FirstOrDefault();
            } 
        }
    }
}
