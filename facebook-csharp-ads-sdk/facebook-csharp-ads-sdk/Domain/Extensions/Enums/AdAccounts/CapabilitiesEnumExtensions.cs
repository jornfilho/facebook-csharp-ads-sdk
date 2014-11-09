using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for CapabilitiesEnum enum
    /// </summary>
    public static class CapabilitiesEnumExtensions
    {
        /// <summary>
        /// Get capability enum from capability name
        /// </summary>
        public static CapabilitiesEnum GetCapabilitiesEnum(this string capabilityName)
        {
            foreach (CapabilitiesEnum capability in Enum.GetValues(typeof(CapabilitiesEnum)))
                if (capability.ToString().Equals(capabilityName, StringComparison.InvariantCultureIgnoreCase))
                    return capability;

            return CapabilitiesEnum.Undefined;
        }
    }
}
