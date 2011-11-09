using System;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ActionArguments;
using Agathas.Storefront.Controllers.ViewModels.Account;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.CustomerService;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class AccountLogOnController : BaseAccountController
    {       
        public AccountLogOnController(ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IExternalAuthenticationService externalAuthenticationService,
                            IFormsAuthentication formsAuthentication,
                            IActionArguments actionArguements)
            : base(authenticationService, customerService, externalAuthenticationService,
                  formsAuthentication, actionArguements)
        {            
        }

        public ActionResult LogOn()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false, "");
            
            return View(accountView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string email, string password, string returnUrl)
        {
            User user = _authenticationService.Login(email, password);

            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthorisationToken(user.AuthenticationToken);

                if (!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in. Please try again.");
                accountView.CallBackSettings.ReturnUrl =
                                          GetReturnActionFrom(returnUrl).ToString();                
                
                return View("LogOn", accountView);
            }
        }

        public ActionResult ReceiveTokenAndLogon(string token, string returnUrl)
        {
            User user = _externalAuthenticationService.GetUserDetailsFrom(token);

            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthorisationToken(user.AuthenticationToken);

                GetCustomerRequest getCustomerRequest = new GetCustomerRequest();
                getCustomerRequest.CustomerIdentityToken = user.AuthenticationToken;

                GetCustomerResponse getCustomerResponse =
                                   _customerService.GetCustomer(getCustomerRequest);

                if (getCustomerResponse.CustomerFound)
                {
                    return RedirectBasedOn(returnUrl);
                }
                else
                {
                    AccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not find your customer account." +
                               " If you don't have an account with use please register.");
                    accountView.CallBackSettings.ReturnUrl =
                                                                           returnUrl;                                                                     

                    return View("LogOn", accountView);
                }
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in." +
                                           " Please try again.");
                accountView.CallBackSettings
                    .ReturnUrl = returnUrl;                                

                return View("LogOn", accountView);
            }
        }

        public ActionResult SignOut()
        {
            _formsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private AccountView InitializeAccountViewWithIssue(bool hasIssue, string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndLogon";
            accountView.CallBackSettings.Controller = "AccountLogOn";
            accountView.HasIssue = hasIssue;
            accountView.Message = message;

            string returnUrl = _actionArguements
                               .GetValueForArgument(ActionArgumentKey.ReturnUrl);
            accountView.CallBackSettings.ReturnUrl =
                                GetReturnActionFrom(returnUrl).ToString();

            return accountView;            
        }
    }
}
