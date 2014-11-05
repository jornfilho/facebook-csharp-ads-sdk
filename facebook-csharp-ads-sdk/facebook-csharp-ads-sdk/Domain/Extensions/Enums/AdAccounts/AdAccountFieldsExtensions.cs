using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

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
        public static IList<AdAccountFieldsEnum> GetAllAdAccountFieldsList()
        {
            IList<AdAccountFieldsEnum> result = new List<AdAccountFieldsEnum>();
            foreach (AdAccountFieldsEnum field in Enum.GetValues(typeof (AdAccountFieldsEnum)))
            {
                result.Add(field);
            }
            return result;
        }

        /// <summary>
        /// Get list of default ad account fields
        /// </summary>
        public static IList<AdAccountFieldsEnum> GetDefaultsAdAccountFieldsList()
        {
            return new List<AdAccountFieldsEnum>
            {
                AdAccountFieldsEnum.Id,
                AdAccountFieldsEnum.AccountId
            };
        }

        /// <summary>
        /// Get string list of facebook fields name
        /// </summary>
        public static string GetAdAccountFieldsName(this IList<AdAccountFieldsEnum> accountFieldsList)
        {
            if (accountFieldsList == null)
                return null;

            if (!accountFieldsList.Any())
                return null;

            var result = "";

            var accountListCount = accountFieldsList.Count;
            for (var index = 0; index < accountListCount; index++)
            {
                var currentName = accountFieldsList[index].GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (String.IsNullOrEmpty(currentName))
                    continue;

                if (!String.IsNullOrEmpty(result))
                    result += ",";

                result += currentName;
            }

            return result;
        }

        /// <summary>
        /// Test if ad account field is a primitive or object value
        /// </summary>
        public static bool IsAdAccountFieldPrimitive(this AdAccountFieldsEnum accountField)
        {
            return !accountField.GetCustomEnumAttributeValue<IsParentObjectAttribute, bool>();
        }
    }
}
