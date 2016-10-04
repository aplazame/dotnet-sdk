using System;
using System.Net;

namespace Aplazame.Http
{
    public class Request : IRequest
    {
        public string Method { get; }

        public string Uri { get; }

        public WebHeaderCollection Headers { get; }

        public string Body { get; }

        /// <param name="method">The HTTP Method of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        public Request(string method, string uri) : this(method, uri, new WebHeaderCollection())
        {
        }

        /// <param name="method">The HTTP Method of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        /// <param name="headers">The Headers of the request.</param>
        public Request(string method, string uri, WebHeaderCollection headers) : this(method, uri, headers, "")
        {
        }

        /// <param name="method">The HTTP Method of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        /// <param name="headers">The Headers of the request.</param>
        /// <param name="body">The Body of the message.</param>
        public Request(string method, string uri, WebHeaderCollection headers, string body)
        {
            if (null == method) throw new ArgumentNullException(nameof(method));
            Method = method.ToUpper();

            if (null == uri) throw new ArgumentNullException(nameof(uri));
            Uri = uri;

            if (null == headers) throw new ArgumentNullException(nameof(headers));
            Headers = headers;

            if (null == body) throw new ArgumentNullException(nameof(body));
            Body = body;
        }
    }
}
