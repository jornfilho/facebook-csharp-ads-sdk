using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.AdStatistics;
using facebook_csharp_ads_sdk.Domain.Models.AdStatistics;

namespace facebook_csharp_ads_sdk.Domain.Extensions.AdStatistics
{
    /// <summary>
    /// Extension methods for Facebook ad statistics
    /// </summary>
    public static class AdStatisticsExtensions
    {
        /// <summary>
        /// Query statistics of a Facebook ad object. When no date is provided, lifetime stats are returned. 
        /// With only start time provided, stats are returned since that date, and when both start and end time 
        /// are provided, stats are returned for the date interval.
        /// </summary>
        /// <param name="startTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <param name="endTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <returns></returns>
        public static IList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics> stats(this IAdStatisticsQueryable adObject, DateTime startTimeUtc, DateTime endTimeUtc)
        {
            return new List<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>();
        }
    }
}
