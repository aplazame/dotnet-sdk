using System;

namespace Aplazame.Http
{
    public interface IClient
    {
        /// <exception cref="Exception">If requests cannot be performed due network issues.</exception>
        IResponse Send(IRequest request);
    }
}
