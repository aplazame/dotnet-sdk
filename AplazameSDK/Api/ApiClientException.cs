using System;
using Aplazame.Http;
using Newtonsoft.Json;

namespace Aplazame.Api
{
    /// <summary>
    /// Exception thrown for HTTP 4xx client errors.
    /// </summary>
    public class ApiClientException : Exception
    {
        public static ApiClientException FromResponse(IResponse response)
        {
            if (null == response) throw new ArgumentNullException(nameof(response));
            string responseBody = response.Body;

            if (0 == responseBody.Length) return new ApiClientException(response.StatusCode, response.ReasonPhrase);

            dynamic decodedBody = JsonConvert.DeserializeObject(responseBody);
            dynamic error = decodedBody.error;
            if (null == error) return new ApiClientException(response.StatusCode, response.ReasonPhrase);
            
            return new ApiClientException(response.StatusCode, error.type.ToString(), error.message.ToString(), error);
        }

        public int HttpStatusCode { get; }

        public string ErrorType { get; }

        public object Error { get; }

        public ApiClientException(int httpStatusCode, string errorType) : this(httpStatusCode, errorType, "", new object())
        {

        }

        public ApiClientException(int httpStatusCode, string errorType, string message, object error) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ErrorType = errorType;
            Error = error;
        }
    }
}
