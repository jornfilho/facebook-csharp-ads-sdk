using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     <para> Facebook Ad Set </para>
    ///     <para>https://developers.facebook.com/docs/reference/ads-api/adset/</para>
    /// </summary>
    public class AdSet : BaseCrudObject<AdSet>
    {
        #region Dependencies

        /// <summary>
        ///     Interface of the ad set repository
        /// </summary>
        private readonly IAdSetRepository adSetRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="adSetRepository"> Interface of the ad set repository </param>
        public AdSet(IAdSetRepository adSetRepository)
        {
            this.adSetRepository = adSetRepository;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        ///     <para> Id of the ad account </para> 
        /// </summary>
        [FacebookName("account_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AccountId { get; private set; }

        /// <summary>
        ///     <para> Id of the ad set </para>
        /// </summary>
        [FacebookName("id")]
        [DefaultValue(0L)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        [IsFacebookCreateResponseAttribute(true)]
        public long Id { get; private set; }

        /// <summary>
        ///     <para> Name of the ad set </para>
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public string Name { get; private set; }

        /// <summary>
        ///     Ad set bid type
        /// </summary>
        [FacebookName("bid_type")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdSetBidTypeEnum)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public AdSetBidTypeEnum? BidType { get; private set; }

        /// <summary>
        ///     Ad set bid info
        /// </summary>
        [FacebookName("bid_info")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.BidInfoArray)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public IList<BidInfo> BidInfo { get; private set; }

        /// <summary>
        ///     The ad campaign this ad set is a part of
        /// </summary>
        [FacebookName("campaign_group_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        [CanCreateOnFacebook(true)]
        public long? AdCampaignId { get; private set; }

        /// <summary>
        ///     Ad set status
        /// </summary>
        [FacebookName("campaign_status")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdSetStatusEnum)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public AdSetStatusEnum? Status { get; private set; }

        /// <summary>
        ///     Ad set start time
        /// </summary>
        [FacebookName("start_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.UnixTimestamp)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public DateTime? StartTime { get; private set; }

        /// <summary>
        ///     Ad set end time
        /// </summary>
        [FacebookName("end_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.UnixTimestamp)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public DateTime? EndTime { get; private set; }

        /// <summary>
        ///     Ad set updated time
        /// </summary>
        [FacebookName("updated_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.UnixTimestamp)]
        public DateTime? UpdatedTime { get; private set; }

        /// <summary>
        ///     Ad set created time
        /// </summary>
        [FacebookName("created_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.UnixTimestamp)]
        public DateTime? CreatedTime { get; private set; }

        /// <summary>
        ///     The daily budget of the set, defined in your account currency
        /// </summary>
        [FacebookName("daily_budget")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public int? DailyBudget { get; private set; }

        /// <summary>
        ///     The life time budget of the set, defined in your account currency
        /// </summary>
        [FacebookName("lifetime_budget")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public int? LifetimeBudget { get; private set; }

        /// <summary>
        ///     The budget you have left on the set, defined in your account currency
        /// </summary>
        [FacebookName("budget_remaining")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        public int? BudgetRemaining { get; private set; }

        /// <summary>
        ///     The targeting specification of this ad set
        /// </summary>
        [FacebookName("targeting")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public string Targeting { get; private set; }

        /// <summary>
        ///     The object that the ad set is trying to promote and advertise
        /// </summary>
        [FacebookName("promoted_object")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.PromotedObject)]
        [CanCreateOnFacebook(true)]
        public PromotedObject PromotedObject { get; private set; }

        /// <summary>
        ///     Execute options on Facebook create and update
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("execution_options")]
        [FacebookFieldType(FacebookFieldType.ExecutionOptionsEnumList)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public IList<ExecutionOptionsEnum> ExecutionOptionsList { get; private set; }

        /// <summary>
        ///     Allows you to specify that you would like to retrieve all fields of the set in your response
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("redownload")]
        [CanCreateOnFacebook(true)]
        public bool? Redownload { get; private set; }

        #endregion Properties

        public override AdSet Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Delete tha ad set in Facebook
        /// </summary>
        /// <returns> Success </returns>
        public override bool Delete()
        {
            try
            {
                bool success = this.Id.IsValidAdCampaignId() && this.adSetRepository.Delete(this.Id).Result;
                this.SetInvalidUpdateModel();
                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Delete the ad set in Facebook
        /// </summary>
        /// <param name="id"> Id of the ad set </param>
        /// <returns> Sucess </returns>
        public override bool Delete(long id)
        {
            try
            {
                this.Id = id;
                return this.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Dictionary<string, string> GetSingleCreateParams()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetSingleUpdateParams()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     <para> Read ad set by id </para>
        /// </summary>
        /// <param name="id"> Ad set id </param>
        /// <returns> Ad set with fields passed </returns>
        public override AdSet ReadSingle(long id)
        {
            try
            {
                return id.IsValidAdSetId()
                    ? this.adSetRepository.Read(id).Result
                    : this;
            }
            catch (Exception)
            {
                return this;
            }
        }

        /// <summary>
        ///     <para> Read ad set by id </para>
        /// </summary>
        /// <param name="id"> Ad set id </param>
        /// <param name="fieldsToRead"> Fields to read </param>
        /// <returns> Ad set with fields passed </returns>
        public AdSet ReadSingle(long id, IList<AdSetReadFieldsEnum> fieldsToRead)
        {
            try
            {
                return id.IsValidAdSetId()
                    ? this.adSetRepository.Read(id, fieldsToRead).Result
                    : this;
            }
            catch (Exception)
            {
                return this;
            }
        }

        public override AdSet Update()
        {
            throw new NotImplementedException();
        }

        public override void ParseReadSingleResponse(string facebookResponse)
        {
           
            if (String.IsNullOrEmpty(facebookResponse))
            {
                return;
            }

            base.ParseReadSingleResponse(facebookResponse);
            this.GetBidTypeFromFacebookResponse(facebookResponse);
            this.GetStatusFromFacebookResponse(facebookResponse);
            this.GetTargetingFromFacebookResponse(facebookResponse);
            this.GetBidInfoFromFacebookResponse(facebookResponse);
            this.GetPromotedObjectFromFacebookResponse(facebookResponse);

            /*
            * PromotedObject
            */
        }

        #region Private methods
        
        /// <summary>
        ///     Get bid type from read Facebook response
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        private void GetBidTypeFromFacebookResponse(string facebookResponse)
        {
            try
            {
                var facebookName = this.GetPropertyFacebookName("BidType");
                var response = JObject.Parse(facebookResponse);
                if (response[facebookName] == null || response[facebookName].Type != JTokenType.String)
                {
                    return;
                }

                this.BidType = response[facebookName].ToString().GetAdSetBidType();
            }
            catch (Exception)
            {
                this.BidType = null;
            }
        }

        /// <summary>
        ///     Get ad set status from read Facebook response
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        private void GetStatusFromFacebookResponse(string facebookResponse)
        {
            try
            {
                var facebookName = this.GetPropertyFacebookName("Status");
                var response = JObject.Parse(facebookResponse);
                if (response[facebookName] == null || response[facebookName].Type != JTokenType.String)
                {
                    return;
                }

                this.Status = response[facebookName].ToString().GetAdSetStatus();
            }
            catch (Exception)
            {
                this.Status = null;
            }
        }

        /// <summary>
        ///     Get ad set targeting from read Facebook response
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        private void GetTargetingFromFacebookResponse(string facebookResponse)
        {
            try
            {
                var facebookName = this.GetPropertyFacebookName("Targeting");
                var response = JObject.Parse(facebookResponse);
                if (response[facebookName] == null || response[facebookName].Type != JTokenType.Object)
                {
                    return;
                }

                this.Targeting = JsonConvert.SerializeObject(response[facebookName]);
            }
            catch (Exception)
            {
                this.Targeting = null;
            }
        }
        
        /// <summary>
        ///     Get ad set bid info from read Facebook response
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        private void GetBidInfoFromFacebookResponse(string facebookResponse)
        {
            try
            {
                var facebookName = this.GetPropertyFacebookName("BidInfo");
                var response = JObject.Parse(facebookResponse);
                if (response[facebookName] == null || response[facebookName].Type != JTokenType.Object)
                {
                    return;
                }

                var bInfoObject = JObject.Parse(response[facebookName].ToString());

                this.BidInfo = new List<BidInfo>();
                foreach (var bidInfoJToken in bInfoObject)
                {
                    BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = bidInfoJToken.Key.GetBidInfoType();
                    if (bidInfoObjectiveTypeEnum == BidInfoObjectiveTypeEnum.Undefined)
                    {
                        continue;
                    }

                    int bidInfoValue = bidInfoJToken.Value.ToString().TryParseInt(-1);
                    if (bidInfoValue < 0)
                    {
                        continue;
                    }

                    BidInfo bidInfo = new BidInfo().SetAttributes(bidInfoObjectiveTypeEnum, bidInfoValue);
                    this.BidInfo.Add(bidInfo);
                }

                if (!this.BidInfo.Any())
                {
                    this.BidInfo = null;
                }
            }
            catch (Exception)
            {
                this.BidInfo = null;
            }
        }

        /// <summary>
        ///     Get ad set promoted object from read Facebook response
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        private void GetPromotedObjectFromFacebookResponse(string facebookResponse)
        {
            var facebookName = this.GetPropertyFacebookName("PromotedObject");
            var response = JObject.Parse(facebookResponse);
            if (response[facebookName] == null || response[facebookName].Type != JTokenType.Object)
            {
                return;
            }

            var promotedObject = new PromotedObject();
            promotedObject.ParseReadSingleResponse(response[facebookName]);
            this.PromotedObject = promotedObject;
        }

        #endregion Private methods
    }
}