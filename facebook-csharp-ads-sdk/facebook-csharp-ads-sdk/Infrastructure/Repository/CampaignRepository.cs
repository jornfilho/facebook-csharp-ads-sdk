using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        #region Properties
        
        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
        private readonly IFacebookSession facebookSession;

        #endregion

        #region Constructor

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public CampaignRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
            {
                throw new ArgumentNullException();
            }

            this.facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        ///     <para> Get the ad campaign by id </para>
        /// </summary>
        /// <param name="campaignId"> Id of the campaign </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad campaign with id </returns>
        public async Task<AdCampaign> Read(long campaignId)
        {
            var fieldList = new List<AdCampaignFieldsEnum> { AdCampaignFieldsEnum.Id, AdCampaignFieldsEnum.Name, AdCampaignFieldsEnum.AccountId, AdCampaignFieldsEnum.Adgroups, AdCampaignFieldsEnum.BuyingType, AdCampaignFieldsEnum.Objective, AdCampaignFieldsEnum.Status  };
            AdCampaign campaignResult = await this.Read(campaignId, fieldList);
            return campaignResult;
        }

        /// <summary>
        ///     <para> Get the ad campaign by field list </para>
        /// </summary>
        /// <param name="campaignId"> Id of the campaign </param>
        /// <param name="fields"> Field list you wish to retrieve </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad campaign has passed fields </returns>
        public async Task<AdCampaign> Read(long campaignId, IList<AdCampaignFieldsEnum> fields)
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
            {
                fields = new List<AdCampaignFieldsEnum> { AdCampaignFieldsEnum.Id };
            }

            string fieldNameList = this.GetFieldNameQueryString(fields);
            string campaignEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdCampaignEndpoint;
            campaignEndpoint = String.Format(campaignEndpoint, campaignId, this.facebookSession.GetUserAccessToken(), fieldNameList);

            IRequest webRequest = new Request();
            var getRequest = await webRequest.GetAsync(campaignEndpoint);
            var account = new AdCampaign(this).ParseSingleResponse(getRequest);
            return account;
        }

        #region Private methods
        
        /// <summary>
        ///     Get the query string of chosen fields to read
        /// </summary>
        /// <param name="fields"> Chosen fields to read </param>
        /// <returns> String with field name chose separate by comma </returns>
        public string GetFieldNameQueryString(IList<AdCampaignFieldsEnum> fields)
        {
            if (fields == null || !fields.Any())
            {
                return string.Empty;
            }

            string nameList = string.Empty;
            foreach (var adCampaignFieldsEnum in fields)
            {
                string fieldName = adCampaignFieldsEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (String.IsNullOrEmpty(fieldName))
                {
                    continue;
                }

                if (String.IsNullOrEmpty(nameList))
                {
                    nameList = fieldName;
                    continue;
                }

                nameList += "," + fieldName;
            }

            return nameList;
        }

        #endregion Private methods
    }
}
