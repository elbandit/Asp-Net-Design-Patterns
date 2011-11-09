using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Acceptance.Tests.Utilities;

namespace Agathas.Storefront.Acceptance.Tests.PageObjects
{
    public class ProductDetailPage
    {
        public static string Title
        {
            get { return WebBrowser.Current.TextField("Title").Value; }

            set { WebBrowser.Current.TextField("Title").Value = value; }
        }

        public static string BasketSummary
        {
            get { return WebBrowser.Current.Element("basket-summary-text").Text; }
        }

        public static void AddProduct()
        {            
            WebBrowser.Current.Button("AddToBasket").Click();
        }
    }
}
