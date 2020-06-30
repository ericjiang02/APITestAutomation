using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using APITestAutomation.Helpers;
using APITestAutomation.Base;
using APITestAutomation.Model;
using APITestAutomation.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;


namespace APITestAutomation.Steps
{
    [Binding]
    public sealed class CalculatorSteps
    {
        private readonly ScenarioContext context;
        private Settings _settings;

        public CalculatorSteps(ScenarioContext injectedContext, Settings settings)
        {
            context = injectedContext;
            _settings = settings;
        }

        [Given(@"I enter leftNumber, operator and rightNumber on the calculator")]
        public void GivenIEnterLeftNumberOperatorAndRightNumber(Table table)
        {
            foreach (var row in table.Rows)
            {
                context.Add("leftNumber", Int32.Parse(row[0]));
                context.Add("operator", row[1]);
                context.Add("rightNumber", Int32.Parse(row[2]));
            }
        }

        [When("I press Calculate")]
        public void WhenIPressCalculate()
        {
            _settings.Request = new RestRequest("api/Calculate", Method.POST);
            _settings.Request.AddHeader("x-functions-key", "cYWOrJhggJO8/CHx52TfmD8AH5RdGEjSIBjHhuiHb5qnFV0jzDyngQ==");

            JObject jObjectbody = new JObject();
            jObjectbody.Add("leftNumber", context.Get<int>("leftNumber"));
            jObjectbody.Add("rightNumber", context.Get<int>("rightNumber"));
            jObjectbody.Add("operator", context.Get<string>("operator"));

            _settings.Request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            _settings.Response = _settings.RestClient.ExecuteRequest<CalcValue>(_settings.Request);
        }

        [Then(@"I should see result (.*) returned")]
        public void ThenIShouldSeeResultReturnedOnTheScreen(int expectedResult)
        {
            int value = _settings.Response.GetResponseObject("value");
            Assert.AreEqual(expectedResult, value, "Calculator output is different from expected");
        }
    }
}
