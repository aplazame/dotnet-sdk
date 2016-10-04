using System;

namespace Aplazame.Api
{
    /// <summary>
    /// Exception thrown when there is communication possible with the API.
    /// </summary>
    public class ApiCommunicationException : Exception
    {
        public ApiCommunicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
