using System;

namespace Aplazame.Api
{
    /// <summary>
    /// This exception is thrown when the data cannot be deserialized/unmarshalled.
    /// </summary>
    public class DeserializeException : Exception
    {
        public DeserializeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
