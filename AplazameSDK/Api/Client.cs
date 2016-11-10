using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;
using Aplazame.Http;
using Newtonsoft.Json;

namespace Aplazame.Api
{
    public class Client
    {
        public const string EnvironmentProduction = "production";
        public const string EnvironmentSandbox = "sandbox";

        private string apiBaseUri;

        private bool useSandbox;

        private string accessToken;

        private IClient httpClient;

        /// <param name="apiBaseUri">The API base URI.</param>
        /// <param name="environment">Destination of the request.</param>
        /// <param name="accessToken">The Access Token of the request (Public API key or Private API key)</param>
        public Client(
            string apiBaseUri,
            string environment,
            string accessToken
        ) : this(apiBaseUri, environment, accessToken, new HttpWebRequestClient())
        {
        }

        /// <param name="apiBaseUri">The API base URI.</param>
        /// <param name="environment">Destination of the request.</param>
        /// <param name="accessToken">The Access Token of the request (Public API key or Private API key)</param>
        /// <param name="httpClient"></param>
        public Client(
            string apiBaseUri,
            string environment,
            string accessToken,
            IClient httpClient
        )
        {
            this.apiBaseUri = apiBaseUri;
            useSandbox = (environment == EnvironmentSandbox);
            this.accessToken = accessToken;
            this.httpClient = httpClient ?? new HttpWebRequestClient();
        }

        /// <summary>
        /// Performs a DELETE request.
        /// </summary>
        /// <param name="path">The path of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Delete(string path)
        {
            return Request("DELETE", path);
        }

        /// <summary>
        /// Performs a GET request.
        /// </summary>
        /// <param name="path">The path of the request</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Get(string path)
        {
            return Get(path, null);
        }

        /// <summary>
        /// Performs a GET request.
        /// </summary>
        /// <param name="path">The path of the request</param>
        /// <param name="query">The filters of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Get(string path, object query)
        {
            if (null != query)
            {
                NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

                foreach (PropertyInfo parameter in query.GetType().GetProperties())
                {
                    queryString[parameter.Name] = (string)parameter.GetValue(query);
                }

                path += "?" + queryString;
            }

            return Request("GET", path);
        }

        /// <summary>
        /// Performs a PATCH request.
        /// </summary>
        /// <param name="path">The path of the request</param>
        /// <param name="data">The data of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Patch(string path, object data)
        {
            return Request("PATCH", path, data);
        }

        /// <summary>
        /// Performs a POST request.
        /// </summary>
        /// <param name="path">The path of the request</param>
        /// <param name="data">The data of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Post(string path, object data)
        {
            return Request("POST", path, data);
        }

        /// <summary>
        /// Performs a PUT request.
        /// </summary>
        /// <param name="path">The path of the request</param>
        /// <param name="data">The data of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public object Put(string path, object data)
        {
            return Request("PUT", path, data);
        }

        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The path of the request</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public dynamic Request(string method, string path)
        {
            return Request(method, path, null);
        }

        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The path of the request</param>
        /// <param name="data">The data of the request.</param>
        /// <returns>The data of the response.</returns>
        /// <exception cref="ApiCommunicationException">If an I/O error occurs.</exception>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        /// <exception cref="ApiServerException">If server was not able to respond.</exception>
        /// <exception cref="ApiClientException">If request is invalid.</exception>
        public dynamic Request(string method, string path, object data)
        {
            if (string.IsNullOrEmpty(method)) throw new ArgumentNullException(nameof(method));
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var uri = apiBaseUri + path;

            var request = new ApiRequest(useSandbox, accessToken, method, uri, data);
            IResponse response;
            try
            {
                response = httpClient.Send(request);
            }
            catch (Exception e)
            {
                throw new ApiCommunicationException(e.Message, e);
            }

            if (response.StatusCode >= 500) throw ApiServerException.FromResponse(response);
            if (response.StatusCode >= 400) throw ApiClientException.FromResponse(response);

            object payload = DecodeResponseBody(response.Body);

            return payload;
        }

        /// <param name="responseBody">The HTTP response body.</param>
        /// <returns>Decoded payload.</returns>
        /// <exception cref="DeserializeException">If response cannot be deserialized.</exception>
        protected object DecodeResponseBody(string responseBody)
        {
            // Response body is empty for HTTP 204 and 304 status code.
            if (string.IsNullOrEmpty(responseBody))
                return new object();

            dynamic payload;

            try
            {
                payload = JsonConvert.DeserializeObject(responseBody);
            }
            catch (JsonReaderException e)
            {
                throw new DeserializeException(e.Message, e);
            }

            return payload;
        }
    }
}
