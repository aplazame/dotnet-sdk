using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplazame.Api
{
    [TestClass]
    public class ApiRequestTest
    {
        [TestMethod]
        public void CreateAcceptHeader()
        {
            foreach (KeyValuePair<string, object> dataSet in AcceptHeaderProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                string header = ApiRequest.CreateAcceptHeader(dataSetValue.useSandbox, dataSetValue.apiVersion, dataSetValue.format);

                Assert.AreEqual(dataSetValue.expectedHeader, header);
            }
        }

        public Dictionary<string, object> AcceptHeaderProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description ,[useSandbox, apiVersion, format, expectedHeader]
                { "with sandbox", new {useSandbox=true, apiVersion=1, format="json", expectedHeader="application/vnd.aplazame.Sandbox.v1+json" } },
                { "without sandbox", new {useSandbox=false, apiVersion=1, format="json", expectedHeader="application/vnd.aplazame.v1+json" } },
                { "xml", new {useSandbox=false, apiVersion=1, format="xml", expectedHeader="application/vnd.aplazame.v1+xml" } },
                { "yaml", new {useSandbox=false, apiVersion=1, format="yaml", expectedHeader="application/vnd.aplazame.v1+yaml" } },
            };
        }
        
        [TestMethod]
        public void CreateAuthorizationHeader()
        {
            foreach (KeyValuePair<string, object> dataSet in AuthorizationHeaderProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                string header = ApiRequest.CreateAuthorizationHeader(dataSetValue.accessToken);

                Assert.AreEqual(dataSetValue.expectedHeader, header);
            }
        }

        public Dictionary<string, object> AuthorizationHeaderProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description ,[accessToken, expectedHeader]
                { "foo", new {accessToken="foo", expectedHeader="Bearer foo" } },
            };
        }
        
        [TestMethod]
        public void Constructor()
        {
            foreach (KeyValuePair<string, object> dataSet in ConstructorProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                ApiRequest helper = new ApiRequest(dataSetValue.UseSandbox, dataSetValue.AccessToken, "GET", "http://api.example.com");

                Assert.AreEqual(dataSetValue.ExpectedHeaders.ToString(), helper.Headers.ToString(), "getHeaders not match");
            }
        }

        public Dictionary<string, object> ConstructorProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description => [useSandbox, accessToken, expectedHeader]
                { "foo", new {
                    UseSandbox = true,
                    AccessToken = "foo",
                    ExpectedHeaders = new WebHeaderCollection()
                    {
                        { "Accept", "application/vnd.aplazame.Sandbox.v1+json" },
                        { "Authorization", "Bearer foo" },
                        { "User-Agent", $"Aplazame/{ApiRequest.SdkVersion}, CSharp/{typeof(string).Assembly.ImageRuntimeVersion}" },
                    },
                } },
            };
        }
    }
}
