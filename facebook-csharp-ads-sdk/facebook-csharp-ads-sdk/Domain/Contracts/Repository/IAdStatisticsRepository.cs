using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.AdStatistics;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    public interface IAdStatisticsRepository : IBaseRepository<BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>>
    {
        Task<BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>> Read(long id, DateTime? startTimeUtc, DateTime? endTimeUtc);
    }
}
