using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.AdStatistics;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    /// <summary>
    /// Ad Statistics repository
    /// </summary>
    public class AdStatisticsRepository : IAdStatisticsRepository
    {
        #region Properties
        
        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
        private readonly IFacebookSession _facebookSession;

        #endregion

        #region Constructor

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public AdStatisticsRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            this._facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        /// Query statistics of a Facebook ad object. When no date is provided, lifetime stats are returned. 
        /// With only start time provided, stats are returned since that date, and when both start and end time 
        /// are provided, stats are returned for the date interval.
        /// </summary>
        /// <param name="adObjectId"> Id of Ad, Ad Set, Ad Campaign or Ad Account</param>
        /// <param name="startTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <param name="endTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <returns>list of base objects of type AdStatistics</returns>
        /// <exception cref="ArgumentException">When dates are not in utc, ArgumentException is thrown</exception>
        public async Task<BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>> Read(long id)
        {
            return await this.Read(id, null, null);
        }

        /// <summary>
        /// Query statistics of a Facebook ad object. When no date is provided, lifetime stats are returned. 
        /// With only start time provided, stats are returned since that date, and when both start and end time 
        /// are provided, stats are returned for the date interval.
        /// </summary>
        /// <param name="adObjectId"> Id of Ad, Ad Set, Ad Campaign or Ad Account</param>
        /// <param name="startTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <param name="endTimeUtc">(optional) start time of statistics in UTC in the ad account timezone</param>
        /// <returns>list of base objects of type AdStatistics</returns>
        /// <exception cref="ArgumentException">When dates are not in utc, ArgumentException is thrown</exception>
        public async Task<BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>> Read(long id, DateTime? startTimeUtc, DateTime? endTimeUtc)
        {
            if (startTimeUtc.HasValue && startTimeUtc.Value.Kind != DateTimeKind.Utc)
                throw new ArgumentException("Argument must be of DateTimeKind Utc", "startTimeUtc");
            else if (endTimeUtc.HasValue && endTimeUtc.Value.Kind != DateTimeKind.Utc)
                throw new ArgumentException("Argument must be of DateTimeKind Utc", "endTimeUtc");

            this._facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });

            string statsEndpoint = this._facebookSession.GetFacebookAdsApiConfiguration().AdStatisticsEndpoint;
            statsEndpoint = string.Format(statsEndpoint, this._facebookSession.GetUserAccessToken(), id, 
                startTimeUtc.HasValue ? startTimeUtc.ToString() : string.Empty,
                endTimeUtc.HasValue ? endTimeUtc.ToString() : string.Empty);
            
            IRequest webRequest = new Request();
            var getRequest = await webRequest.GetAsync(statsEndpoint);

            return new BaseObjectsList<facebook_csharp_ads_sdk.Domain.Models.AdStatistics.AdStatistics>().ParseReadMultipleResponse(getRequest);
        }
    }
}
