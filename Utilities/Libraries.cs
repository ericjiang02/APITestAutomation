using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestAutomation.Utilities
{
    public static class Libraries
    {
        public static IRestResponse<T> ExecuteRequest<T>(this RestClient client, IRestRequest request) where T : new()
        {
            var response = client.Execute<T>(request);
            return response;
        }

        public static int GetResponseObject(this IRestResponse response, string responseObject)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[responseObject].ToObject<int>();
        }
    }
}
