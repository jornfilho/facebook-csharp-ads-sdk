using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns
{
    /// <summary>
    ///     ObjectiveEnum of the ad campaign
    /// </summary>
    public enum AdCampaignObjectiveEnum
    {
        [FacebookName("")]
        Undefined = 0,

        [FacebookName("NONE")]
        None = 1,

        [FacebookName("OFFER_CLAIMS")]
        OfferClaims = 2,

        [FacebookName("PAGE_LIKES")]
        PageLikes = 3,

        [FacebookName("CANVAS_APP_INSTALLS")]
        CanvasAppInstalls = 4,

        [FacebookName("CANVAS_APP_ENGAGEMENT")]
        CanvasAppEngagement = 5,

        [FacebookName("EVENT_RESPONSES")]
        EventResponses = 6,

        [FacebookName("LOCAL_AWARENESS")]
        LocalAwareness = 7,

        [FacebookName("POST_ENGAGEMENT")]
        PostEngagement = 8,

        [FacebookName("WEBSITE_CONVERSIONS")]
        WebsiteConversions = 9,

        [FacebookName("MOBILE_APP_INSTALLS")]
        MobileAppInstalls = 10,

        [FacebookName("MOBILE_APP_ENGAGEMENT")]
        MobileAppEngagement = 11,

        [FacebookName("WEBSITE_CLICKS")]
        WebsiteClicks = 12,

        [FacebookName("VIDEO_VIEWS")]
        VideoViews = 13
    }
}