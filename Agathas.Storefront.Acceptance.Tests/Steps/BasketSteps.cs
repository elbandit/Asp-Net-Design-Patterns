using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Acceptance.Tests.PageObjects;
using Agathas.Storefront.Acceptance.Tests.Utilities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using TechTalk.SpecFlow;
using NUnit;

namespace Agathas.Storefront.Acceptance.Tests.Steps
{
    [Binding]
    public class StepDefinitions
    {
        [Given(@"I have no products in my basket")]
        public void GivenIHaveNoProductsInMyBasket()
        {
            // TODO: Clear Basket
        }

        [Given(@"I'm on a product detail page")]
        public void GivenIMOnAProductDetailPage()
        {
            WebBrowser.Current.GoTo("http://localhost:3279/Product/Levi-506-Stretch-Diamond/2");
        }
       
        [When(@"I click the add product button")]
        public void WhenIClickTheAddProductButton()
        {
            ProductDetailPage.AddProduct();            
        }

        [Then(@"I should see a total of  items in my basket")]
        public void ThenIShouldSeeATotalOfItemsInMyBasket()
        {            
            var basketText = "1 Item(s) at $27.99";

            Assert.AreEqual(basketText, ProductDetailPage.BasketSummary);
            
        }
    }
}
