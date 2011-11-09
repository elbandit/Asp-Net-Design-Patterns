using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Agathas.Storefront.Infrastructure.Authentication
{
    public class AspFormsAuthentication : IFormsAuthentication 
    {
        public void SetAuthorisationToken(string token)
        {
            FormsAuthentication.SetAuthCookie(token, true);       
        }

        public string GetAuthorisationToken()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
