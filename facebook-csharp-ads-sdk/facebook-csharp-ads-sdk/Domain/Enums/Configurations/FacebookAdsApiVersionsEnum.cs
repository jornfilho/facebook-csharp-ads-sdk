﻿using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Configurations
{
    /// <summary>
    /// Available Facebook Ads Api verions
    /// </summary>
    public enum FacebookAdsApiVersionsEnum
    {
        /// <summary>
        /// Version 2.2 of Facebook Ads Api
        /// </summary>
        [FacebookName("v2.1")]
        V21,

        /// <summary>
        /// Version 2.2 of Facebook Ads Api
        /// </summary>
        [FacebookName("v2.2")]
        V22
    }
}
