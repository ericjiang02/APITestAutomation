using System;
using System.Collections.Generic;
using System.Text;
using APITestAutomation.Base;
using TechTalk.SpecFlow;

namespace APITestAutomation.Hooks
{
    [Binding]
    public class TestInitialise
    {
        private Settings _settings;

        public TestInitialise(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        { ;
            var baseUrl = "https://calculator-api.azurewebsites.net/";
            _settings.BaseUrl = new Uri(baseUrl.ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }

    }
}
