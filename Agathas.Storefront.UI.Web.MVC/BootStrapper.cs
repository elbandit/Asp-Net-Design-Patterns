using System;
using Agathas.Storefront.Controllers.ActionArguments;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Infrastructure.Payments;
using Agathas.Storefront.Infrastructure.Presentation;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Model.Orders.Events;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Model.Orders;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Cache;
using Agathas.Storefront.Services.Cache.CacheStorage;
using Agathas.Storefront.Services.DomainEventHandlers;
using Agathas.Storefront.Services.Implementations;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Presentation;
using StructureMap;
using StructureMap.Configuration.DSL;
using Agathas.Storefront.Infrastructure.Email;

namespace Agathas.Storefront.UI.Web.MVC
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            
            public ControllerRegistry()
            {
                
                // Repositories                
                ForRequestedType<IBasketRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.BasketRepository>();
                ForRequestedType<ICategoryRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.CategoryRepository>();
                ForRequestedType<IProductTitleRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.ProductTitleRepository>();
                ForRequestedType<IProductRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.ProductRepository>();
                ForRequestedType<ICustomerRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.CustomerRepository>();
                ForRequestedType<IOrderRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.OrderRepository>();
                ForRequestedType<IDeliveryOptionRepository>().TheDefault.Is.OfConcreteType<Repository.NHibernate.Repositories.DeliveryOptionRepository>();
                ForRequestedType<IPresentationRepository>().TheDefault.Is.OfConcreteType<PresentationRepository>();
                ForRequestedType<IUnitOfWork>().TheDefault.Is.OfConcreteType<Repository.NHibernate.NHUnitOfWork>();

                // Authentication
                ForRequestedType<IExternalAuthenticationService>().TheDefault.Is.OfConcreteType<RpxAuthenticationService>();
                ForRequestedType<IFormsAuthentication>().TheDefault.Is.OfConcreteType<AspFormsAuthentication>();
                ForRequestedType<ILocalAuthenticationService>().TheDefault.Is.OfConcreteType<AspMembershipAuthorisation>();

                // Product Catalogue & Category Service with Caching Layer Registration
                this.InstanceOf<IProductCatalogueService>().Is.OfConcreteType<ProductCatalogueService>()
                    .WithName("RealProductCatalogueService");

                // Uncomment the line below to use the product service caching layer
                //ForRequestedType<IProductCatalogueService>().TheDefault.Is.OfConcreteType<CachedProductCatalogueService>()
                //    .CtorDependency<IProductCatalogueService>().Is(x => x.TheInstanceNamed("RealProductCatalogueService"));
               

                // Other Services                
                ForRequestedType<ICustomerService>().TheDefault.Is.OfConcreteType<CustomerService>();
                ForRequestedType<IBasketService>().TheDefault.Is.OfConcreteType<BasketService>();                
                ForRequestedType<ICookieStorageService>().TheDefault.Is.OfConcreteType<CookieStorageService >();
                ForRequestedType<IOrderService>().TheDefault.Is.OfConcreteType<OrderService>();

                // Payment
                ForRequestedType<IPaymentService>().TheDefault.Is.OfConcreteType<PayPalPaymentService>();

                // Controller Helpers
                ForRequestedType<IActionArguments>().TheDefault.Is.OfConcreteType<HttpRequestActionArguments>();

                // Application Settings
                ForRequestedType<IApplicationSettings>().TheDefault.Is.OfConcreteType<WebConfigApplicationSettings>();

                // Caching Strategies
                ForRequestedType<ICacheStorage>().TheDefault.Is.OfConcreteType<HttpContextCacheAdapter>();

                // Logger
                ForRequestedType<ILogger>().TheDefault.Is.OfConcreteType<Log4NetAdapter>();

                // EmailAddress Service
                //ForRequestedType<IEmailService>().TheDefault.Is.OfConcreteType<TextLoggingEmailService>();
                ForRequestedType<IEmailService>().TheDefault.Is.OfConcreteType<SMTPService>();

                // Handlers for Domain Events
                ForRequestedType<IDomainEventHandlerFactory>().TheDefault.Is.OfConcreteType<StructureMapDomainEventHandlerFactory>();
                ForRequestedType<IDomainEventHandler<OrderSubmittedEvent>>().AddConcreteType<OrderSubmittedHandler>();
               
                
            }
        }
    }
}

