using System;
using System.Collections.Generic;
using Aplazame.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Aplazame.Api
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void SuccessRequest()
        {
            Mock<IClient> httpClientMock = new Mock<IClient>();
            httpClientMock.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(200, "{\"foo\": \"value\"}"));

            Client client = new Client(
                "http://api.example.com",
                Client.EnvironmentSandbox,
                "fooAccessToken",
                httpClientMock.Object
            );

            dynamic response = client.Request("get", "uri");

            Assert.AreEqual("value", response.foo.ToString());
        }
        
        [TestMethod]
        public void SendRequestThrowException()
        {
            foreach (KeyValuePair<string, object> dataSet in WrongResponseProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                IClient httpClient = dataSetValue.HttpClient;
                Type exceptionType = dataSetValue.ExceptionType;
                Client client = new Client(
                    "http://api.example.com",
                    Client.EnvironmentSandbox,
                    "fooAccessToken",
                    httpClient
                );
                
                try
                {
                    client.Request("get", "uri");
                    Assert.Fail("Expected exception " + exceptionType + " to be thrown");
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, exceptionType);
                }
            }
        }

       public Dictionary<string, object> WrongResponseProvider()
       {
            object errorModel = new {
                error = new {
                    type = "errorType",
                    message = "errorMessage",
                },
            };

            Mock<IClient> apiCommunication = new Mock<IClient>();
            apiCommunication.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Throws(new ApiCommunicationException("test", new Exception()));

            Mock<IClient> deserialization = new Mock<IClient>();
            deserialization.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(200, "<html>"));

            Mock<IClient> apiClient = new Mock<IClient>();
            apiClient.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(400, JsonConvert.SerializeObject(errorModel)));

            Mock<IClient> apiClientWithoutBody = new Mock<IClient>();
            apiClientWithoutBody.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(400, null));

            Mock<IClient> serverProblem = new Mock<IClient>();
            serverProblem.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(500, JsonConvert.SerializeObject(errorModel)));

            Mock<IClient> serverProblemWithoutBody = new Mock<IClient>();
            serverProblemWithoutBody.Setup(httpClient => httpClient.Send(It.IsAny<IRequest>())).Returns(new Response(500, null));

           return new Dictionary<string, object>()
           {
               // Description => [HttpClient, exception]
               { "Communication", new { HttpClient=apiCommunication.Object, ExceptionType=typeof(ApiCommunicationException) } },
               { "Deserialization", new { HttpClient=deserialization.Object, ExceptionType=typeof(DeserializeException) } },
               { "ApiClient", new { HttpClient=apiClient.Object, ExceptionType=typeof(ApiClientException) } },
               { "ApiClientWithoutBody", new { HttpClient=apiClientWithoutBody.Object, ExceptionType=typeof(ApiClientException) } },
               { "ServerProblem", new { HttpClient=serverProblem.Object, ExceptionType=typeof(ApiServerException) } },
               { "ServerProblemWithoutBody", new { HttpClient=serverProblemWithoutBody.Object, ExceptionType=typeof(ApiServerException) } },
           };
       }
    }
}
