using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Targetings
{
    /// <summary>
    ///     Targeting site category enum
    /// </summary>
    public enum SiteCategoryEnum
    {
        [FacebookName("")]
        Undefined = 0,

        [FacebookName("feature_phones")]
        FeaturePhones = 1
    }
}