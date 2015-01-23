using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCreative
{
    public enum CallToActionTypeEnum
    {
        
        Undefined = 0,

        [FacebookName("OPEN_LINK")]
        OpenLink = 1,

        [FacebookName("BOOK_TRAVEL")]
        BookTravel = 2,

        [FacebookName("SHOP_NOW")]
        ShopNow = 3,

        [FacebookName("PLAY_GAME")]
        PlayGame = 4,

        [FacebookName("LISTEN_MUSIC")]
        ListenMusic = 5,

        [FacebookName("WATCH_VIDEO")]
        WatchVideo = 6,

        [FacebookName("USE_APP")]
        UseApp = 7
    }
}
