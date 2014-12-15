using System;
using System.Collections.Generic;
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
        ///     Create the ad campaign on Facebook
        /// </summary>
        /// <param name="adCampaign"> Ad campaign to create </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad campaign created with id </returns>
        public async Task<AdCampaign> Create(AdCampaign adCampaign)
        {
            if (adCampaign == null)
            {
                return null;
            }

            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            Dictionary<string, string> paramsToCreate = adCampaign.GetSingleCreateParams();

            string campaignCreateEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdCampaignCreateEndpoint;
            campaignCreateEndpoint = String.Format(campaignCreateEndpoint, adCampaign.AccountId, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string requestResult = await webRequest.PostAsync(campaignCreateEndpoint, paramsToCreate);

            adCampaign.ParseCreateResponse(requestResult);
            return adCampaign;
        }

        /// <summary>
        ///     <para> Get the ad campaign by id </para>
        /// </summary>
        /// <param name="campaignId"> Id of the campaign </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad campaign with id </returns>
        public async Task<AdCampaign> Read(long campaignId)
        {
            var fieldList = new List<AdCampaignFieldsEnum> { AdCampaignFieldsEnum.Id };
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
            string campaignEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdCampaignReadEndpoint;
            campaignEndpoint = String.Format(campaignEndpoint, campaignId, this.facebookSession.GetUserAccessToken(), fieldNameList);

            IRequest webRequest = new Request();
            string getRequest = await webRequest.GetAsync(campaignEndpoint);
            var account = new AdCampaign(this);
            account.ParseReadSingleesponse(getRequest);
            return account;
        }
        
        /// <summary>
        ///     Delete the ad campaign
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Success </returns>
        public async Task<bool> Delete(long id)
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            string deleteEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().DeleteEndpoint;
            deleteEndpoint = String.Format(deleteEndpoint, id, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string deleteRequest = await webRequest.DeleteAsync(deleteEndpoint);
            var account = new AdCampaign(this);
            
            return account.ParseDeleteResponse(deleteRequest);
        }

        /// <summary>
        ///     Updated the ad campaign on Facebook
        /// </summary>
        /// <param name="campaign"> Entity to update </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Campaign updated </returns>
        public async Task<AdCampaign> Update(AdCampaign campaign)
        {
            if (campaign == null)
            {
                return null;
            }

            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            Dictionary<string, string> paramsToUpdate = campaign.GetSingleUpdateParams();

            string campaignUpdateEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdCampaignUpdateEndpoint;
            campaignUpdateEndpoint = String.Format(campaignUpdateEndpoint, campaign.Id, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string requestResult = await webRequest.PostAsync(campaignUpdateEndpoint, paramsToUpdate);

            campaign.ParseUpdateResponse(requestResult);
            return campaign;
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
