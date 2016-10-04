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

            if (0 == responseBody.Length) return new ApiClientException(response.ReasonPhrase, response.StatusCode.ToString(), new object());

            dynamic decodedBody = JsonConvert.DeserializeObject(responseBody);
            dynamic error = decodedBody.error;
            if (null == error) return new ApiClientException(response.ReasonPhrase, response.StatusCode.ToString(), new object());
            
            return new ApiClientException(error.type.ToString(), error.message.ToString(), error);
        }

        public string ErrorType { get; }

        public object Error { get; }

        public ApiClientException(string errorType, string message, object error) : base(message)
        {
            ErrorType = errorType;
            Error = error;
        }
    }
}
