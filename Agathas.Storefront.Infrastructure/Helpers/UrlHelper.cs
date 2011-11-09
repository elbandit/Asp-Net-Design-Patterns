using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Agathas.Storefront.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resouce)
        {
            return string.Format("{0}://{1}{2}{3}",
                  HttpContext.Current.Request.Url.Scheme,
                  HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                  (HttpContext.Current.Request.ApplicationPath.Equals("/")) ? string.Empty : HttpContext.Current.Request.ApplicationPath,
                  resouce);
        }
    }
}
