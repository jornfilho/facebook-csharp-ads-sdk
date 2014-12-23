using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     Targeting mobile model
    /// </summary>
    public class TargetingMobile
    {
        /// <summary>
        ///     User operating system mobile
        /// </summary>
        [FacebookName("user_os")]
        [DefaultValue(null)]
        public OsOptionsEnum UserOs { get; private set; }

        // todo: user_device

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
