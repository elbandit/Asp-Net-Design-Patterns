using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Authentication
{
    public interface ILocalAuthenticationService
    {
        User Login(string email, string password);
        User RegisterUser(string email, string password);       
    }
}
