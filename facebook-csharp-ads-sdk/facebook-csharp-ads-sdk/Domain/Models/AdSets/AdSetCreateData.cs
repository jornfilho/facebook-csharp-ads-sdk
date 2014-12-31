using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.Global;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     Ad set create data
    /// </summary>
    public class AdSetCreateData
    {
        /// <summary>
        ///     Id of the ad account
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        ///     The ad campaign this ad set is a part of
        /// </summary>
        public long AdCampaignId { get; set; }

        /// <summary>
        ///     Ad set bid info
        /// </summary>
        public List<BidInfo> BidInfoList { get; set; }

        /// <summary>
        ///     Ad set bid type
        /// </summary>
        public AdSetBidTypeEnum BidType { get; set; }

        /// <summary>
        ///     The daily budget of the set, defined in your account currency
        /// </summary>
        public int? DailyBudget { get; set; }

        /// <summary>
        ///     Ad set end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        ///     The life time budget of the set, defined in your account currency
        /// </summary>
        public int? LifetimeBudget { get; set; }

        /// <summary>
        ///     Name of the ad set
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The object that the ad set is trying to promote and advertise
        /// </summary>
        public PromotedObject PromotedObject { get; set; }

        /// <summary>
        ///     Ad set start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     Ad set status
        /// </summary>
        public AdSetStatusEnum Status { get; set; }

        /// <summary>
        ///     The targeting specification of this ad set
        /// </summary>
        public string Targeting { get; set; }
    }
}