using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for AdAccountStatusEnum enum
    /// </summary>
    public static class AdAccountStatusEnumExtensions
    {
        /// <summary>
        /// Get ad account status enum from ad account status code
        /// </summary>
        public static AdAccountStatusEnum GetAdAccountStatusEnum(this int statusCode)
        {
            foreach (AdAccountStatusEnum status in Enum.GetValues(typeof(AdAccountStatusEnum)))
                if ((int)status == statusCode)
                    return status;

            return AdAccountStatusEnum.Undefined;
        }
    }
}
