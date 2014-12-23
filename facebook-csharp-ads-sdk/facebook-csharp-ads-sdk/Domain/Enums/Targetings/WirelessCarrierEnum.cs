using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.Targetings
{
    /// <summary>
    ///     Targeting wireless carrier options enum
    /// </summary>
    public enum WirelessCarrierEnum
    {
        [FacebookName("")]
        Undefined = 0,

        [FacebookName("Wifi")]
        Wifi = 1
    }
}