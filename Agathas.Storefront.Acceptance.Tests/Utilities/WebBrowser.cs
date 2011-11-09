using TechTalk.SpecFlow;
using WatiN.Core;

namespace Agathas.Storefront.Acceptance.Tests.Utilities
{    
    public class WebBrowser
    {
        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                    ScenarioContext.Current["browser"] = new IE();
                return (Browser)ScenarioContext.Current["browser"];
            }
        }

        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
                Current.Close();
        }
    }
}
