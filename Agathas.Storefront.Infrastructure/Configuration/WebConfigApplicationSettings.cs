using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Agathas.Storefront.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings 
    {        
        public int NumberOfResultsPerPage
        {
            get { return int.Parse(ConfigurationManager.AppSettings["NumberOfResultsPerPage"]); }
        }    
 
        public string PayPalBusinessEmail
        {
            get { return ConfigurationManager.AppSettings["PayPalBusinessEmail"]; }
        }

        public string PayPalPaymentPostToUrl
        {
            get { return ConfigurationManager.AppSettings["PayPalPaymentPostToUrl"]; }
        }

        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

        public string RpxApiKey
        {
            get { return ConfigurationManager.AppSettings["RpxApiKey"]; }
        }
    }
}
