using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
    public class AdCampaign : BaseCrudObject<AdCampaign>
    {
        #region Dependencies

        /// <summary>
        ///     Interface of the campaign repository
        /// </summary>
        private readonly ICampaignRepository campaignRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="campaignRepository"> Interface of the campaign repository </param>
        public AdCampaign(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        ///     <para> Id of the ad campaign </para>
        /// </summary>
        [FacebookName("id")]
        [DefaultValue(0L)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long Id { get; private set; }

        /// <summary>
        ///     <para> Id of the ad account </para> 
        /// </summary>
        [FacebookName("account_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AccountId { get; private set; }

        /// <summary>
        ///     <para> Name of the ad campaign </para>
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Name { get; private set; }

        /// <summary>
        ///     <para> Objective of the ad campaign </para> 
        /// </summary>
        [FacebookName("objective")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignObjectiveEnum)]
        public AdCampaignObjectiveEnum? Objective { get; private set; }

        /// <summary>
        ///     <para> Status of the ad campaign </para> 
        /// </summary>
        [FacebookName("campaign_group_status")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignStatusEnum)]
        public AdCampaignStatusEnum? Status { get; private set; }

        /// <summary>
        ///     <para> Buying type of the ad campaign </para> 
        /// </summary>
        [FacebookName("buying_type")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignBuyingTypeEnum)]
        public AdCampaignBuyingTypeEnum? BuyingType { get; private set; }

        /// <summary>
        ///     <para> Adgroups owned by this ad campaign </para> 
        /// </summary>
        [FacebookName("adgroups")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64Array)]
        public IList<long> AdGroups { get; private set; }

        #endregion Properties

        /// <summary>
        ///     <para> Read ad campaign by id </para>
        /// </summary>
        /// <param name="id"> Campaign id </param>
        /// <returns> Campaign with id field </returns>
        public override AdCampaign ReadSingle(long id)
        {
            try
            {
                return id.IsValidAdCampaignId() ? this.campaignRepository.Read(id).Result : this;
            }
            catch
            {
                return this;
            }
        }

        /// <summary>
        ///     Delete the ad campaign in facebook
        /// </summary>
        /// <returns> Success </returns>
        public override bool Delete()
        {
            try
            {
                return this.Id.IsValidAdCampaignId() && this.campaignRepository.Delete(this.Id).Result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Delete the ad campaign in facebook
        /// </summary>
        /// <param name="id"> Id of the ad campaign </param>
        /// <returns> Success </returns>
        public override bool Delete(long id)
        {
            try
            {
                this.Id = id;
                return this.Delete();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Overrite of the base parse method 
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        public override void ParseReadSingleesponse(string facebookResponse)
        {
            base.ParseReadSingleesponse(facebookResponse);
            if (!this.IsValid)
            {
                return;
            }

            if (!this.Id.IsValidAdCampaignId())
            {
                this.SetInvalid();
                return;
            }

            this.GetAdGroupIdListFromFacebookResponse(facebookResponse);
        }

        /// <summary>
        ///     Get ids list of ad group by facebook response
        /// </summary>
        /// <param name="jsonResult"> Facebook response </param>
        private void GetAdGroupIdListFromFacebookResponse(string jsonResult)
        {
            var facebookResponse = JObject.Parse(jsonResult);

            JToken jTokenAdGroups = facebookResponse["adgroups"];
            if (jTokenAdGroups != null && jTokenAdGroups.Type == JTokenType.Object)
            {
                var adGroupList = JObject.Parse(facebookResponse["adgroups"].ToString());

                JToken adGroupIds = adGroupList["data"];
                if (adGroupIds != null && adGroupIds.Type == JTokenType.Array)
                {
                    this.AdGroups = new List<long>();
                    foreach (var jTokenAdGroupId in adGroupIds)
                    {
                        JToken id = jTokenAdGroupId["id"];
                        if (id != null && id.Type == JTokenType.String)
                        {
                            long adGroupId = id.ToString().TryParseLong();
                            if (adGroupId > 0)
                            {
                                this.AdGroups.Add(adGroupId.ToString().TryParseLong());
                            }
                        }
                    }
                }
            }
        }
    }
}
