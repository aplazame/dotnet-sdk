using System.Net;

namespace Aplazame.Http
{
    public interface IRequest
    {
        /// <summary>
        /// Retrieves the HTTP method of the request.
        /// </summary>
        /// <returns>Returns the request method. The return value must use uppercase letters.</returns>
        string Method { get; }

        /// <summary>
        /// Retrieves all message header values.
        /// </summary>
        WebHeaderCollection Headers { get; }

        /// <summary>
        /// Retrieves the URI instance.
        /// http://tools.ietf.org/html/rfc3986#section-4.3
        /// </summary>
        /// <returns>Returns the URI of the request.</returns>
        string Uri { get; }

        /// <summary>
        /// Gets the body of the message.
        /// </summary>
        /// <returns>Returns the body of the request.</returns>
        string Body { get; }
    }
}
