using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for AdAccountFieldsEnum enum
    /// </summary>
    public static class AdAccountFieldsExtensions
    {
        /// <summary>
        /// Get a list of available ad account fields
        /// </summary>
        public static IList<AdAccountFieldsEnum> GetAdAccountFieldsList()
        {
            IList<AdAccountFieldsEnum> result = new List<AdAccountFieldsEnum>();
            foreach (AdAccountFieldsEnum field in Enum.GetValues(typeof (AdAccountFieldsEnum)))
            {
                result.Add(field);
            }
            return result;
        }
    }
}
