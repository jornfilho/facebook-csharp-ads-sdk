using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdSet
{
    /// <summary>
    ///     Ad set status
    /// </summary>
    public enum AdSetStatusEnum
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        /// <summary>
        ///     Ad set active
        /// </summary>
        [FacebookName("ACTIVE")]
        Active = 1,

        /// <summary>
        ///     Ad set paused
        /// </summary>
        [FacebookName("PAUSED")]
        Paused = 2,

        /// <summary>
        ///     Ad set archived
        /// </summary>
        [FacebookName("ARCHIVED")]
        Archived = 3,

        /// <summary>
        ///     Ad set deleted
        /// </summary>
        [FacebookName("DELETED")]
        Deleted = 4,

        /// <summary>
        ///     Ad campaign paused
        /// </summary>
        [FacebookName("CAMPAIGN_GROUP_PAUSED")]
        AdCamnpaignPaused = 5
    }
}