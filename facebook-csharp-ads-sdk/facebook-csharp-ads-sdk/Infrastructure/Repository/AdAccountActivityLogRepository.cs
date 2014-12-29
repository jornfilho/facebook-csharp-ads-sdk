using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts.Connections;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts.Connections;
using facebook_csharp_ads_sdk._Utils.Parser;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdAccountActivityLogRepository : IAdActivityLogRepository
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
        public AdAccountActivityLogRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            this._facebookSession = facebookSession;
        } 

        #endregion

        #region Methods
        /// <summary>
        /// Get ad account activity log with default fields
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IList<AdActivityLog>> Read(long id)
        {
            IList<AdActivityLog> result = await Read(id, AdActivityLogFieldsEnumExtensions.GetDefaultsAdActivityLogFieldsList());
            return result;
        }

        /// <summary>
        /// Get ad account activity log
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<IList<AdActivityLog>> Read(long id, IList<AdActivityLogFieldsEnum> fields)
        {
            this._facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
                fields = AdActivityLogFieldsEnumExtensions.GetDefaultsAdActivityLogFieldsList();

            string fieldNames = string.Join(",", fields.GetFacebookNamesList());
            string endpoint = this._facebookSession.GetFacebookAdsApiConfiguration().AdAccountActivityLogEndpoint;
            endpoint = string.Format(endpoint, id, this._facebookSession.GetUserAccessToken(), fieldNames);

            IRequest webRequest = new Request();
            var adActivities = new List<AdActivityLog>();
            var adActivityModel = new AdActivityLog();

            while (true)
            {
                var getRequest = await webRequest.GetAsync(endpoint);
                if (String.IsNullOrEmpty(getRequest))
                    break;

                var groupsList = adActivityModel.ParseMultipleResponse(getRequest);
                if (groupsList == null)
                    break;

                adActivities.AddRange(groupsList.Data);

                var nextPage = getRequest.GetNextPage();
                if (String.IsNullOrEmpty(nextPage) || nextPage.Equals(endpoint))
                    break;

                endpoint = nextPage;
            }

            return adActivities;
        }
        #endregion
    }
}
