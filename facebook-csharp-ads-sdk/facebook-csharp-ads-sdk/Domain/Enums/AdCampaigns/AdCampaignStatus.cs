using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns
{
    /// <summary>
    ///     Status of the campaign
    /// </summary>
    public enum AdCampaignStatus
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        /// <summary>
        ///     Campaign active
        /// </summary>
        [FacebookName("ACTIVE")]
        Active,

        /// <summary>
        ///     Campaign paused
        /// </summary>
        [FacebookName("PAUSED")]
        Paused
    }
}