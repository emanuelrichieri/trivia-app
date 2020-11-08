using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace TdP2019TPFinalRichieri.Services.Impl
{

    public class HttpService : IHttpService
    {
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public HttpService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Get JSON response from a given API url.
        /// </summary>
        /// <returns>JSON response.</returns>
        /// <param name="pUrl">API URL.</param>
        public dynamic GetResponse(string pUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pUrl);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    dynamic responseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    return responseJSON;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string errorText = reader.ReadToEnd();

                    _logger.Error(ex, errorText);
                }
                return null;
            } 
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}
