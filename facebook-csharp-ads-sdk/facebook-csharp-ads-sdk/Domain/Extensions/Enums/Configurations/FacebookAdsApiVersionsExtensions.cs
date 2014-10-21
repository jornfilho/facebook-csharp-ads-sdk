using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.Configurations
{
    /// <summary>
    /// Extensions for FacebookAdsApiVersionsEnum enum
    /// </summary>
    public static class FacebookAdsApiVersionsExtensions
    {
        /// <summary>
        /// Get Facebook attribute name from enum option
        /// </summary>
        public static string GetFacebookName(this FacebookAdsApiVersionsEnum version)
        {
            return version.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}
