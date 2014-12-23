using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdSet
{
    /// <summary>
    ///     Ad set bid type enum
    /// </summary>
    public enum AdSetBidTypeEnum
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        /// <summary>
        ///     CPM
        /// </summary>
        [FacebookName("CPM")]
        Cpm = 1,

        /// <summary>
        ///     CPC
        /// </summary>
        [FacebookName("CPC")]
        Cpc = 2,
        
        /// <summary>
        ///     Multi premium
        /// </summary>
        [FacebookName("MULTI_PREMIUM")]
        MultiPremium = 3,

        /// <summary>
        ///     Absolute oCMM
        /// </summary>
        [FacebookName("ABSOLUTE_OCPM")]
        AbsoluteOcpm = 4,

        /// <summary>
        ///     CPA
        /// </summary>
        [FacebookName("CPA")]
        Cpa = 5
    }
}