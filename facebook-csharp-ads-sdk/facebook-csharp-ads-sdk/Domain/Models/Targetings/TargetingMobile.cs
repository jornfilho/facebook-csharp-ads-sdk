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
        ///     Devices listed here must match the value specified in user_os
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

        /// <summary>
        ///     Set attributes to create a targeting mobile
        /// </summary>
        /// <param name="siteCategory"> Targeting site category </param>
        /// <param name="userDevice"> Devices listed here must match the value specified in user_os </param>
        /// <param name="userOs"> User operating system mobile </param>
        /// <param name="wirelessCarrier"> Targeting wireless carrier </param>
        /// <returns> This instance </returns>
        public TargetingMobile SetAttributesToCreate(IList<SiteCategoryEnum> siteCategory, IList<TargetingUserDevice> userDevice,
                               OsOptionsEnum userOs, IList<WirelessCarrierEnum> wirelessCarrier)
        {
            this.SiteCategory = siteCategory;
            this.UserDevice = userDevice;
            this.UserOs = userOs;
            this.WirelessCarrier = wirelessCarrier;

            return this;
        }
    }
}
