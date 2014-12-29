using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     <para> Targeting mobile model </para>
    ///     <para> https://developers.facebook.com/docs/reference/ads-api/targeting-specs/#mobile </para>
    /// </summary>
    public class TargetingMobile
    {
        /// <summary>
        ///     User operating system mobile
        /// </summary>
        [FacebookName("user_os")]
        [DefaultValue(OsOptionsEnum.Undefined)]
        public OsOptionsEnum UserOs { get; private set; }

        /// <summary>
        ///     Devices listed here must match the value specified in user_os. 
        /// </summary>
        [FacebookName("user_device")]
        [DefaultValue(null)]
        public IList<TargetingUserDevice> UserDevice { get; private set; }
        
        /// <summary>
        ///     Targeting wireless carrier
        /// </summary>
        [FacebookName("wireless_carrier")]
        [DefaultValue(null)]
        public IList<WirelessCarrierEnum> WirelessCarrier { get; private set; }

        /// <summary>
        ///     Targeting site category
        /// </summary>
        [FacebookName("site_category")]
        [DefaultValue(null)]
        public IList<SiteCategoryEnum> SiteCategory { get; private set; }
    }
}
