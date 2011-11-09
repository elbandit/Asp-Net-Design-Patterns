using System;
using System.Web;

namespace Agathas.Storefront.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {
        public void Save(string key, string value, DateTime expires)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }

        public string Retrieve(string key)
        {
             HttpCookie cookie = HttpContext.Current.Request.Cookies[key];  
             if (cookie != null)  
                 return cookie.Value;  
             return "";  
        }
    }
}