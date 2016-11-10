using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Aplazame.Http
{
    public class HttpWebRequestClient : IClient
    {
        public IResponse Send(IRequest request)
        {
            if (null == request) throw new ArgumentNullException(nameof(request));

            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(request.Uri);
            hr.Method = request.Method;

            Type type = typeof(HttpWebRequest);
            foreach (String headerName in request.Headers.AllKeys)
            {
                var headerValue = request.Headers[headerName];
                if (WebHeaderCollection.IsRestricted(headerName))
                {
                    string propertyName = headerName.Replace("-", "");
                    PropertyInfo headerProperty = type.GetProperty(propertyName);
                    headerProperty.SetValue(hr, headerValue);
                }
                else
                {
                    hr.Headers.Add(headerName, headerValue);
                }
            }

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
