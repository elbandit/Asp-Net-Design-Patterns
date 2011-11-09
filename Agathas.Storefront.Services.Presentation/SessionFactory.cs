
using NHibernate;
using NHibernate.Cfg;

namespace Agathas.Storefront.Services.Presentation
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static void Init()
        {
            if (_sessionFactory == null)
            {
                Configuration config = new Configuration();
                config.AddAssembly("Agathas.Storefront.Services.Presentation");

                log4net.Config.XmlConfigurator.Configure();

                config.Configure();

                _sessionFactory = config.BuildSessionFactory();
            }
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        public static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }        
    }
}
