using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.AdStatistics;
using facebook_csharp_ads_sdk.Domain.Models.AdStatistics;
using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

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
        /// <param name="adObjectId"> Id of Ad, Ad Set, Ad Campaign or Ad Account</param>
        /// <param name="startTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <param name="endTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <returns>list of base objects of type AdStatistics</returns>
        public static async Task<BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>> GetStatistics(this IAdStatisticsQueryable adObject, long adObjectId, DateTime? startTimeUtc, DateTime? endTimeUtc)
        {
            return await adObject._adStatisticsRepository.Read(adObjectId, startTimeUtc, endTimeUtc);
        }
    }
}
