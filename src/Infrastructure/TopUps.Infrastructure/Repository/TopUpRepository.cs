using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TopUps.Core.Repository_Interfaces;

namespace TopUps.Infrastructure.Repository
{
    public class TopUpRepository : ITopUpRepository
    {
        public async Task<IList<int>> SendDataToMobileOperator(TopUpRequest request)
        {
            
            var returnvalue = new List<int>();

            try
            {
                var response = await SendRequest(request);

                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var x = new System.Xml.Serialization.XmlSerializer(response.GetType());

                    XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

                    using (TextReader reader = new StringReader(result))
                    {
                        returnvalue = (List<int>)serializer.Deserialize(reader);
                    }

                }
                return returnvalue;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<HttpResponseMessage> SendRequest(TopUpRequest request)
        {
            var url = "Sample url";
            try
            {
                HttpClient webClient = new HttpClient();
                webClient.DefaultRequestHeaders.Add("content-type", "application/xml");
                webClient.DefaultRequestHeaders.Add("MessageDate", DateTime.Now.ToString("ddMMyyy"));
                webClient.DefaultRequestHeaders.Add("MessageTime", DateTime.Now.ToString("hhmmss"));
                var data = new System.Xml.Serialization.XmlSerializer(request.GetType());
                var stringContent = new StringContent(data.ToString(), Encoding.UTF8, "application/xml");
                var response = await webClient.PostAsync(url, stringContent);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        
    }
}
