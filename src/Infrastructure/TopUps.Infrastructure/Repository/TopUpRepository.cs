using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TopUps.Core.Models;
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
                var url = "Sample url";
                var response = await SendRequest(url, request);

                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
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

        public async Task<TopUpResponse> SendDataToMobileOperatorWithIdentifier(TopUpRequest request)
        {
            try
            {
                var url = "Sample url";
                var response = await SendRequest(url, request);

                var result = await response.Content.ReadAsStringAsync();

                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(result.GetType());

                using (var textReader = new StringReader(result))
                {
                    return (TopUpResponse)xmlSerializer.Deserialize(textReader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<HttpResponseMessage> SendRequest(string url, TopUpRequest request)
        {
            try
            {
                HttpClient webClient = new HttpClient();
                webClient.DefaultRequestHeaders.Add("content-type", "application/xml");
                if (string.IsNullOrEmpty(request.Identifier))
                {
                    webClient.DefaultRequestHeaders.Add("Identifier", request.Identifier);
                }
                webClient.DefaultRequestHeaders.Add("MessageTime", request.MessageTime);
                webClient.DefaultRequestHeaders.Add("MessageTime", request.MessageTime);
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
