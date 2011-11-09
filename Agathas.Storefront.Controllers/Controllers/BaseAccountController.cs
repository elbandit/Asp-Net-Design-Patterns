using System;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ActionArguments;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Services.Interfaces;

namespace Agathas.Storefront.Controllers.Controllers
{
    public abstract class BaseAccountController : Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly ICustomerService _customerService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentication;
        protected readonly IActionArguments _actionArguements;

        public BaseAccountController(ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IExternalAuthenticationService externalAuthenticationService,
                            IFormsAuthentication formsAuthentication,
                            IActionArguments actionArguements)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
            _externalAuthenticationService = externalAuthenticationService;
            _formsAuthentication = formsAuthentication;
            _actionArguements = actionArguements;
        }

        public ActionResult RedirectBasedOn(string returnUrl)
        {
            if (returnUrl == ActionArgumentKey.GoToCheckout.ToString())
                return RedirectToAction("Checkout", "Checkout");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl) &&
                                    returnUrl.ToLower().Contains("checkout"))
                return ActionArgumentKey.GoToCheckout;
            else
                return ActionArgumentKey.GoToAccount;
        }
    }     
}
