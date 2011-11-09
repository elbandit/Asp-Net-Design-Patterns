using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Logging
{
    public interface ILogger
    {
        void Log(string message);
    }
}
