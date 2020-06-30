using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace APITestAutomation.Helpers
{
    public class RestHelper
    {
        public RestClient endpoint = null;
        public int leftNumber;
        public int rightNumber;
        //public RestClient SetEndpoint(string endpointUrl)
        //{
        //    endpoint = new RestClient(endpointUrl);
        //    return endpoint;
        //}

        //public int SetLeftNumber(int leftNumber)
        //{
        //    return leftNumber;
        //}
        //public int SetRightNumber(int rightNumber)
        //{
        //    return rightNumber;
        //}
    }
}
