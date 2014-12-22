using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for TaxStatusEnum enum
    /// </summary>
    public static class TaxStatusEnumExtensions
    {
        /// <summary>
        /// Get tax status enum from tax status code
        /// </summary>
        public static TaxStatusEnum GetTaxStatusEnum(this int taxStatusCode)
        {
            foreach (TaxStatusEnum taxStatus in Enum.GetValues(typeof(TaxStatusEnum)))
                if ((int)taxStatus == taxStatusCode)
                    return taxStatus;

            return TaxStatusEnum.Undefined;
        }
    }
}
