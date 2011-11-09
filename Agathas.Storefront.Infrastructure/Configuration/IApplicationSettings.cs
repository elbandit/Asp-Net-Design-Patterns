using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        int NumberOfResultsPerPage {get; }
       
        string LoggerName { get; }

        string RpxApiKey { get;  }

        string PayPalBusinessEmail { get; }
        string PayPalPaymentPostToUrl { get; }
    }
}
