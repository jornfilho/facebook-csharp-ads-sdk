using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// Account capabilities options
    /// </summary>
    public enum CapabilitiesEnum
    {
        Undefined = 0,
        
        [FacebookName("DIRECT_SALES")]
        DirectSales,

        [FacebookName("PREMIUM")]
        Pemium,

        [FacebookName("VIEW_TAGS")]
        ViewTags,

        [FacebookName("CUSTOM_CLUSTER_SHARING")]
        CustomClusterSharing,

        [FacebookName("LOOKALIKE_AUDIENCE")]
        LookalikeAudience,

        [FacebookName("CUSTOM_AUDIENCES_OPT_OUT_LINK")]
        CustomAudiencesOptOutLink,

        [FacebookName("CUSTOM_AUDIENCES_FOLDERS")]
        CustomAudienceFolders,

        [FacebookName("NEW_CAMPAIGN_STRUCTURE")]
        NewCampaignStructure
    }
}
