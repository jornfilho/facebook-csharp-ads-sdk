using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns
{
    /// <summary>
    ///     Buying type of the campaign
    /// </summary>
    public enum AdCampaignBuyingTypeEnum
    {
        [FacebookName("")]
        Undefined = 0,

        [FacebookName("AUCTION")]
        Auction = 1,

        [FacebookName("FIXED_CPM")]
        FixedCpm = 2,

        [FacebookName("RESERVED")]
        Reserved = 3
    }
}