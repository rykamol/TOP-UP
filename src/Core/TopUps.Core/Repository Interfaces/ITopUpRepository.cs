using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopUps.Core.Models;

namespace TopUps.Core.Repository_Interfaces
{
    public  interface ITopUpRepository
    {
        Task<IList<int>> SendDataToMobileOperator(TopUpRequest request);
        Task<TopUpResponse> SendDataToMobileOperatorWithIdentifier(TopUpRequest request);
    }
}
