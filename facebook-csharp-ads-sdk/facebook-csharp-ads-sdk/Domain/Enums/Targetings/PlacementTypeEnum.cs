using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Targetings
{
    /// <summary>
    ///     Placement type of the deliver ads
    /// </summary>
    public enum PlacementTypeEnum
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        /// <summary>
        ///     Right hand side and News feed on desktop
        /// </summary>
        [FacebookName("desktop")]
        Desktop = 1,

        /// <summary>
        ///     News feed on desktop and mobile
        /// </summary>
        [FacebookName("feed")]
        Feed = 2,

        /// <summary>
        ///     News feed on desktop
        /// </summary>
        [FacebookName("desktopfeed")]
        DesktopFeed = 3,

        /// <summary>
        ///     News feed on mobile
        /// </summary>
        [FacebookName("mobile")]
        Mobile = 4,

        /// <summary>
        ///     Right column on desktop computers
        /// </summary>
        [FacebookName("rightcolumn")]
        RightColumn = 5,

        /// <summary>
        ///     Right column on desktop computers and news feed on mobile
        /// </summary>
        [FacebookName("rightcolumn-and-mobile")]
        RightColumnAndMobile = 6,

        /// <summary>
        ///     Right-hand column only (only available for Premium)
        /// </summary>
        [FacebookName("home")]
        Home = 7,

        /// <summary>
        ///     News feed on mobile and on the Audience Network. Note that there is no option to serve just offsite.
        /// </summary>
        [FacebookName("mobilefeed-and-external")]
        MobileFeedAndExternal = 8,

        /// <summary>
        ///     This allows the ad to serve on desktop News Feed, right hand side, mobile News Feed, and on the Audience Network
        /// </summary>
        [FacebookName("desktop-and-mobile-and-external")]
        DesktopAndMobileAndExternal = 9,

        /// <summary>
        ///     This allows the ad to serve on desktop News Feed, mobile News Feed, and on the Audience Network
        /// </summary>
        [FacebookName("feed-and-external")]
        FeedAndExternal = 10,

        /// <summary>
        ///     This allows the ad to serve on Right column on desktop computers, Mobile Feed and the Audience Network.
        /// </summary>
        [FacebookName("rightcolumn-and-mobile-and-external")]
        RightColumnAndMobileAndExternal = 11
    }
}