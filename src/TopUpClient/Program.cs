using System;
using System.Threading.Tasks;
using TopUps.Infrastructure.Repository;

namespace TopUpClient
{
    public class Program
    {
        private static TopUpRepository topUpRepository;

        public Program()
        {
             topUpRepository = new TopUpRepository();
        }


        public static async Task Main(string[] args)
        {

            var request1 = new TopUpRequest()
            {
                MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                MessageTime = DateTime.Now.ToString("hhmmss"),
                MessageId = "332527",
                PhoneNo = "630000000000",
                Amount = 25

            };
            var data1 = await topUpRepository.SendDataToMobileOperator(request1);


            var request2 = new TopUpRequest()
            {
                Identifier = "EZE",
                MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                MessageTime = DateTime.Now.ToString("hhmmss"),
                MessageId = "332527",
                PhoneNo = "630000000000",
                Amount = 25

            };
            var data2 = await topUpRepository.SendDataToMobileOperatorWithIdentifier(request2);
        }
    }
}
