using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopUps.Core.Repository_Interfaces
{
    public  interface ITopUpRepository
    {
        Task<IList<int>> SendDataToMobileOperator(TopUpRequest request);

    }
}
