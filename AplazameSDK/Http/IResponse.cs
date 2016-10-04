namespace Aplazame.Http
{
    public interface IResponse
    {
        /// <summary>
        /// Gets the response status code.
        ///
        /// The status code is a 3-digit integer result code of the server"s attempt
        /// to understand and satisfy the request.
        /// </summary>
        int StatusCode { get; }
        
        /// <summary>
        /// Gets the response reason phrase associated with the status code.
        ///
        /// Because a reason phrase is not a required element in a response
        /// status line, the reason phrase value MAY be null. Implementations MAY
        /// choose to return the default RFC 7231 recommended reason phrase (or those
        /// listed in the IANA HTTP Status Code Registry) for the response"s
        /// status code.
        ///
        /// @link http://tools.ietf.org/html/rfc7231#section-6
        /// @link http://www.iana.org/assignments/http-status-codes/http-status-codes.xhtml
        /// </summary>
        /// <returns>The data of the response.</returns>
        string ReasonPhrase { get; }
        
        /// <summary>
        /// Gets the body of the message.
        /// </summary>
         string Body { get; }
    }
}
