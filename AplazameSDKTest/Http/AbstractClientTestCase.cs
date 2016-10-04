using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Aplazame.Http
{
    [TestClass]
    public abstract class AbstractClientTestCase
    {
        [TestMethod]
        public void Send()
        {
            foreach (KeyValuePair<string, object> dataSet in RequestProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                IClient client = CreateClient();

                IRequest request = dataSetValue.Request;
                IResponse response = client.Send(request);

                dynamic responseBody = JsonConvert.DeserializeObject(response.Body);

                Assert.AreEqual(request.Uri, responseBody["url"].ToString());
                Assert.IsNotNull(responseBody["headers"]["X-Foo"]);
                Assert.AreEqual("fooValue", responseBody["headers"]["X-Foo"].ToString());
                string body = request.Body;
                if (0 != body.Length)
                {
                    Assert.IsNotNull(body);
                }
            }
        }

        [TestMethod]
        public void RequestWithoutResponseBody()
        {
            foreach (KeyValuePair<string, object> dataSet in RequestWithoutResponseBodyProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                IClient client = CreateClient();

                IRequest request = dataSetValue.Request;
                int statusCode = dataSetValue.StatusCode;
                IResponse response = client.Send(request);

                Assert.AreEqual(statusCode, response.StatusCode);
            }
        }

        [TestMethod]
        public void SendThrowException()
        {
            foreach (KeyValuePair<string, object> dataSet in InvalidRequestProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                IClient client = CreateClient();
                IRequest request = dataSetValue.Request;
                Type exceptionType = dataSetValue.ExceptionType;
                try
                {
                    client.Send(request);
                    Assert.Fail("Expected exception " + exceptionType + " to be thrown");
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, exceptionType);
                }
            }
        }

        public Dictionary<string, object> RequestProvider()
        {
            WebHeaderCollection headers = new WebHeaderCollection() {
                { "X-Foo", "fooValue" },
            };
            string testBody = "testBody";

            return new Dictionary<string, object>()
            {
                // Description => [request]
                { "delete", new { Request=new Request("delete", "http://httpbin.org/delete", headers) } },
                { "get", new { Request=new Request("get", "http://httpbin.org/get", headers) } },
                { "patch", new { Request=new Request("patch", "http://httpbin.org/patch", headers, testBody) } },
                { "post", new { Request=new Request("post", "http://httpbin.org/post", headers, testBody) } },
                { "put", new { Request=new Request("put", "http://httpbin.org/put", headers, testBody) } },
            };
        }

        public Dictionary<string, object> RequestWithoutResponseBodyProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description => [request, status code]
                { "500", new { Request=new Request("get", "http://httpbin.org/status/500"), StatusCode=500 } },
            };
        }

        public Dictionary<string, object> InvalidRequestProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description => [request, exceptionClass]
                { "Bad host", new { Request=new Request("get", "http://notexists"), ExceptionType=typeof(Exception) } },
            };
        }

        protected abstract IClient CreateClient();
    }
}
