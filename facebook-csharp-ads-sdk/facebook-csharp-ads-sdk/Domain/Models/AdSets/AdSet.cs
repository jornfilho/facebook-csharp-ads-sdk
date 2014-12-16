using System;
using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Domain.Models.Global;

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
        //[IsFacebookCreateResponse(true)]
        public long Id { get; private set; }

        /// <summary>
        ///     <para> Name of the ad set </para>
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        //[CanCreateOnFacebook(true)]
        //[CanUpdateOnFacebook(true)]
        public string Name { get; private set; }

        /// <summary>
        ///     Ad set bid type
        /// </summary>
        [FacebookName("bid_type")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdSetBidTypeEnum)]
        public AdSetBidTypeEnum? BidTypeEnum { get; private set; }

        /// <summary>
        ///     Ad set bid info
        /// </summary>
        [FacebookName("bid_info")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.BidInfoArray)]
        public IList<BidInfo> BidInfo { get; private set; }

        /// <summary>
        ///     The ad campaign this ad set is a part of
        /// </summary>
        [FacebookName("campaign_group_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AdCampaignId { get; private set; }

        /// <summary>
        ///     Ad set status
        /// </summary>
        [FacebookName("campaign_status")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdSetStatusEnum)]
        public AdSetStatusEnum? Status { get; private set; }

        /// <summary>
        ///     Ad set start time
        /// </summary>
        [FacebookName("start_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.DateTime)]
        public DateTime? StartTime { get; private set; }

        /// <summary>
        ///     Ad set end time
        /// </summary>
        [FacebookName("end_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.DateTime)]
        public DateTime? EndTime { get; private set; }

        /// <summary>
        ///     Ad set updated time
        /// </summary>
        [FacebookName("updated_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.DateTime)]
        public DateTime? UpdatedTime { get; private set; }

        /// <summary>
        ///     Ad set created time
        /// </summary>
        [FacebookName("created_time")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.DateTime)]
        public DateTime? CreatedTime { get; private set; }

        /// <summary>
        ///     The daily budget of the set, defined in your account currency
        /// </summary>
        [FacebookName("daily_budget")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        public int? DailyBudget { get; private set; }

        /// <summary>
        ///     The life time budget of the set, defined in your account currency
        /// </summary>
        [FacebookName("lifetime_budget")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        public int? LifetimeBudget { get; private set; }

        /// <summary>
        ///     The budget you have left on the set, defined in your account currency
        /// </summary>
        [FacebookName("budget_remaining")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int32)]
        public int? BudgetRemaining { get; private set; }

        // Todo: targeting

        [FacebookName("promoted_object")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.PromotedObject)]
        public PromotedObject PromotedObject { get; private set; }

        #endregion Properties

        public override AdSet Create()
        {
            throw new NotImplementedException();
        }

        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetSingleCreateParams()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetSingleUpdateParams()
        {
            throw new NotImplementedException();
        }

        public override AdSet ReadSingle(long id)
        {
            throw new NotImplementedException();
        }

        public override AdSet Update()
        {
            throw new NotImplementedException();
        }
    }
}