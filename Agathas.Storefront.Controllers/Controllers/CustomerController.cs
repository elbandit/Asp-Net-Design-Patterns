using System.Linq;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ViewModels.CustomerAccount;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.CustomerService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.Controllers
{
    [Authorize]
    public class CustomerController : BaseController 
    {        
        private readonly ICustomerService _customerService;
        private readonly IFormsAuthentication _formsAuthentication;

        public CustomerController(ICookieStorageService cookieStorageService,                                  
                                  ICustomerService customerService,
                                  IFormsAuthentication formsAuthentication)
            : base(cookieStorageService)
        {            
            _customerService = customerService;
            _formsAuthentication = formsAuthentication;
        }

        [Authorize]
        public ActionResult Detail()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();

            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDetailView customerDetailView = new CustomerDetailView();
            customerDetailView.Customer = response.Customer;                 
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDetailView);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Detail(CustomerView customerView)
        {
            ModifyCustomerRequest request = new ModifyCustomerRequest();

            request.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();
            request.Email = customerView.EmailAddress;
            request.FirstName = customerView.NameFirstName;
            request.SecondName = customerView.NameSecondName;

            ModifyCustomerResponse response = _customerService.ModifyCustomer(request);

            CustomerDetailView customerDetailView = new CustomerDetailView();

            customerDetailView.Customer = response.Customer;
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDetailView);
        }

        [Authorize]
        public ActionResult DeliveryAddresses()
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();

            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDetailView customerDetailView = new CustomerDetailView();

            customerDetailView.Customer = response.Customer;
            customerDetailView.BasketSummary = base.GetBasketSummaryView();

            return View("DeliveryAddresses", customerDetailView);
        }

        [Authorize]
        public ActionResult EditDeliveryAddress(int deliveryAddressId)
        {
            GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();

            GetCustomerResponse response = _customerService.GetCustomer(customerRequest);

            CustomerDeliveryAddressView deliveryAddressView = new CustomerDeliveryAddressView();

            deliveryAddressView.CustomerView = response.Customer;
            deliveryAddressView.Address =
                response.Customer.DeliveryAddressBook.Where(d => d.Id == deliveryAddressId).FirstOrDefault();
            deliveryAddressView.BasketSummary = base.GetBasketSummaryView();

            return View(deliveryAddressView);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditDeliveryAddress(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressModifyRequest request = new DeliveryAddressModifyRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();

            _customerService.ModifyDeliveryAddress(request);

            return DeliveryAddresses();
        }

        [Authorize]
        public ActionResult AddDeliveryAddress()
        {
            CustomerDeliveryAddressView customerDeliveryAddressView = new CustomerDeliveryAddressView();

            customerDeliveryAddressView.Address = new DeliveryAddressView();
            customerDeliveryAddressView.BasketSummary = base.GetBasketSummaryView();

            return View(customerDeliveryAddressView);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDeliveryAddress(DeliveryAddressView deliveryAddressView)
        {
            DeliveryAddressAddRequest request = new DeliveryAddressAddRequest();
            request.Address = deliveryAddressView;
            request.CustomerIdentityToken = _formsAuthentication.GetAuthorisationToken();

            _customerService.AddDeliveryAddress(request);
            
            return DeliveryAddresses();
        }
    }
}
