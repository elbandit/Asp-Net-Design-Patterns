using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using Agathas.Storefront.Repository.NHibernate.SessionStorage;

namespace Agathas.Storefront.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _SessionFactory;        

        public static void Init()
        {
            if (_SessionFactory == null)
            {
                Configuration config = new Configuration();
                config.AddAssembly("Agathas.Storefront.Repository.NHibernate");

                log4net.Config.XmlConfigurator.Configure();

                config.Configure();

                _SessionFactory = config.BuildSessionFactory();
            }
        }        

        private static ISessionFactory GetSessionFactory()
        {
            if (_SessionFactory == null)
                Init();

            return _SessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer _sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = _sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                _sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}
