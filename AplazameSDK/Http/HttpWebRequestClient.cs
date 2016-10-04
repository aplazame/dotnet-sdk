using System;
using System.IO;
using System.Net;

namespace Aplazame.Http
{
    public class HttpWebRequestClient : IClient
    {
        public IResponse Send(IRequest request)
        {
            if (null == request) throw new ArgumentNullException(nameof(request));

            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(request.Uri);
            hr.Method = request.Method;
            hr.Headers = request.Headers;

            string body = request.Body;
            if (0 != body.Length)
            {
                using (StreamWriter sw = new StreamWriter(hr.GetRequestStream()))
                {
                    sw.Write(body);
                }
            }

            HttpWebResponse result;

            try
            {
                result = (HttpWebResponse)hr.GetResponse();
            }
            catch (WebException e)
            {
                if (null == e.Response) throw;
                result = (HttpWebResponse)e.Response;
            }

            StreamReader sr = new StreamReader(result.GetResponseStream());
            string responseBody = sr.ReadToEnd();

            IResponse response = new Response(
                (int)result.StatusCode,
                responseBody
            );

            return response;
        }
    }
}
