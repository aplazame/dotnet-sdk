using System.Net;
using Aplazame.Http;
using Newtonsoft.Json;

namespace Aplazame.Api
{
    public class ApiRequest : Request
    {
        public const string SdkVersion = "0.2.1";
        public const string FormatJson = "json";
        public const string FormatXml = "xml";
        public const string FormatYaml = "yaml";

        public static string CreateAuthorizationHeader(string accessToken)
        {
            return "Bearer " + accessToken;
        }

        public static string CreateAcceptHeader(bool useSandbox, int apiVersion, string format)
        {
            var header = "application/vnd.aplazame";
            if (useSandbox) header += ".sandbox";
            header += $".v{apiVersion}+{format}";

            return header;
        }

        /// <param name="useSandbox"></param>
        /// <param name="apiVersion"></param>
        /// <param name="accessToken">The Access Token of the request (Public API key or Private API key)</param>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        public ApiRequest(
            bool useSandbox,
            int apiVersion,
            string accessToken,
            string method,
            string uri
        ) : this (useSandbox, apiVersion, accessToken, method, uri, null)
        {
        }

        /// <param name="useSandbox"></param>
        /// <param name="apiVersion"></param>
        /// <param name="accessToken">The Access Token of the request (Public API key or Private API key)</param>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        /// <param name="data">data The data of the request.</param>
        public ApiRequest(
            bool useSandbox,
            int apiVersion,
            string accessToken,
            string method,
            string uri,
            object data
        ) : base(method, uri, PrepareHeaders(useSandbox, apiVersion, accessToken, data), SerializeData(data))
        {
        }

        private static WebHeaderCollection PrepareHeaders(
            bool useSandbox,
            int apiVersion,
            string accessToken,
            object data = null
        )
        {
            WebHeaderCollection headers = new WebHeaderCollection
            {
                { "Accept", CreateAcceptHeader(useSandbox, apiVersion, FormatJson) },
                { "Authorization", CreateAuthorizationHeader(accessToken) },
                { "User-Agent", $"Aplazame/{SdkVersion}, CSharp/{typeof(string).Assembly.ImageRuntimeVersion}" }
            };

            if (null != data)
            {
                headers.Add("Content-Type", "application/json");
            }

            return headers;
        }
        private static string SerializeData(object data = null)
        {
            string serializedData = (null != data) ? JsonConvert.SerializeObject(data) : "";

            return serializedData;
        }
    }
}
