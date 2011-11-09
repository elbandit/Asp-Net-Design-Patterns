using System;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ActionArguments;
using Agathas.Storefront.Controllers.ViewModels.Account;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Services.Implementations;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.CustomerService;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class AccountRegisterController : BaseAccountController
    {
        public AccountRegisterController(ILocalAuthenticationService authenticationService,
                                         ICustomerService customerService,
                                         IExternalAuthenticationService externalAuthenticationService,
                                         IFormsAuthentication formsAuthentication,
                                         IActionArguments actionArguements)
            : base(authenticationService, customerService, externalAuthenticationService,
                  formsAuthentication, actionArguements)
        {            
        }
       
        public ActionResult Register()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false, string.Empty);
                       
            return View(accountView);
        }
       

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(FormCollection collection)
        {
            User user;
            
            string password = collection[FormDataKeys.Password.ToString()];
            string email = collection[FormDataKeys.Email.ToString()];
            string firstName = collection[FormDataKeys.FirstName.ToString()];
            string secondName = collection[FormDataKeys.SecondName.ToString()];

            try
            {
                user = _authenticationService.RegisterUser(email, password);
            }
            catch (InvalidOperationException ex)
            {
                AccountView accountView = InitializeAccountViewWithIssue(true, ex.Message);
                
                return View(accountView);
            }

            if (user.IsAuthenticated)
            {
                try
                {
                    CreateCustomerRequest createCustomerRequest =
                                            new CreateCustomerRequest();
                    createCustomerRequest.CustomerIdentityToken =
                                            user.AuthenticationToken;
                    createCustomerRequest.Email = email;
                    createCustomerRequest.FirstName = firstName;
                    createCustomerRequest.SecondName = secondName;

                    _formsAuthentication.SetAuthorisationToken(user.AuthenticationToken);
                    _customerService.CreateCustomer(createCustomerRequest);

                    return RedirectToAction("Detail", "Customer");
                }
                catch (CustomerInvalidException ex)
                {
                    AccountView accountView = InitializeAccountViewWithIssue(true, ex.Message);                    

                    return View(accountView);
                }
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not authenticate you. Please try again.");
                
                return View(accountView);
            }
        }

        public ActionResult ReceiveTokenAndRegister(string token, string returnUrl)
        {
            User user = _externalAuthenticationService.GetUserDetailsFrom(token);

            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthorisationToken(user.AuthenticationToken);

                // Register user
                CreateCustomerRequest createCustomerRequest =
                                                  new CreateCustomerRequest();
                createCustomerRequest.CustomerIdentityToken = user.AuthenticationToken;
                createCustomerRequest.Email = user.Email;
                createCustomerRequest.FirstName = "[Please Enter]";
                createCustomerRequest.SecondName = "[Please Enter]";

                _customerService.CreateCustomer(createCustomerRequest);

                return RedirectBasedOn(returnUrl);
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                                           "Sorry we could not authenticate you.");
                accountView.CallBackSettings.ReturnUrl =
                                            GetReturnActionFrom(returnUrl).ToString(); ;                               

                return View("Register", accountView);
            }
        }

        private AccountView InitializeAccountViewWithIssue(bool hasIssue, string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndRegister";
            accountView.CallBackSettings.Controller = "AccountRegister";
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

