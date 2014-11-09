using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for AdAccountGroupsStatusEnum enum
    /// </summary>
    public static class AdAccountGroupsStatusEnumExtensions
    {
        /// <summary>
        /// Get ad account group status enum from status code
        /// </summary>
        public static AdAccountGroupsStatusEnum GetAdAccountGroupsStatusEnum(this int statusCode)
        {
            foreach (AdAccountGroupsStatusEnum status in Enum.GetValues(typeof(AdAccountGroupsStatusEnum)))
                if ((int)status == statusCode)
                    return status;

            return AdAccountGroupsStatusEnum.Undefined;
        }
    }
}
