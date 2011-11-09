using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Authentication
{
    public interface IFormsAuthentication
    {
       void SetAuthorisationToken(string token);
       string GetAuthorisationToken();
       void SignOut();
    }                
}
