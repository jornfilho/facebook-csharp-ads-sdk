using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Global
{
    /// <summary>
    ///     Bid info objective type
    /// </summary>
    public enum BidInfoObjectiveType
    {
        [FacebookName("")]
        Undefined = 0,
        
        [FacebookName("IMPRESSIONS")]
        Impressions = 1,

        [FacebookName("CLICKS")]
        Clicks = 2,

        [FacebookName("ACTIONS")]
        Actions = 3,

        [FacebookName("REACH")]
        Reach = 4,

        [FacebookName("SOCIAL")]
        Social = 5
    }
}