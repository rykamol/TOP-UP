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
            var request = new TopUpRequest()
            {

            };
            var data = await topUpRepository.SendDataToMobileOperator(request);

        }
    }
}
