using System;
using Aplazame.Http;
using Newtonsoft.Json;

namespace Aplazame.Api
{
    /// <summary>
    /// Exception thrown for HTTP 5xx client errors.
    /// </summary>
    public class ApiServerException : Exception
    {
        public static ApiServerException FromResponse(IResponse response)
        {
            if (null == response) throw new ArgumentNullException(nameof(response));
            string responseBody = response.Body;

            if (0 == responseBody.Length) return new ApiServerException(response.ReasonPhrase, response.StatusCode.ToString(), new object());

            dynamic decodedBody = JsonConvert.DeserializeObject(responseBody);
            dynamic error = decodedBody.error;
            if (null == error) return new ApiServerException(response.ReasonPhrase, response.StatusCode.ToString(), new object());

            return new ApiServerException(error.type.ToString(), error.message.ToString(), error);
        }

        public string ErrorType { get; }

        public object Error { get; }

        public ApiServerException(string errorType, string message, object error) : base(message)
        {
            ErrorType = errorType;
            Error = error;
        }
    }
}
