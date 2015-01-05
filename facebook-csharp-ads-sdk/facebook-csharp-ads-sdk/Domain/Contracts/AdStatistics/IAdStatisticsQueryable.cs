using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk.Domain.Contracts.AdStatistics
{
    /// <summary>
    /// Interface of AdStatistics. Statistics can be retrieved at the ad account, ad set, and ad level
    /// https://developers.facebook.com/docs/reference/ads-api/adstatistics/v2.2
    /// </summary>
    public interface IAdStatisticsQueryable
    {
        IList<AdStatistics> stats(DateTime startDateUtc, DateTime endDateUtc);
    }
}
