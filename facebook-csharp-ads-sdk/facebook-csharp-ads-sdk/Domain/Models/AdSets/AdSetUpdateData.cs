using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.Global;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     Data to update a ad set
    /// </summary>
    public class AdSetUpdateData
    {
        /// <summary>
        ///     Bid info
        /// </summary>
        public List<BidInfo> BidInfoList { get; set; }

        /// <summary>
        ///     Bid type
        /// </summary>
        public AdSetBidTypeEnum? BidType { get; set; }

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
        ///     Ad set start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     Ad set start status
        /// </summary>
        public AdSetStatusEnum? Status { get; set; }

        /// <summary>
        ///     The targeting specification of this ad set
        /// </summary>
        public string Targeting { get; set; }
    }
}