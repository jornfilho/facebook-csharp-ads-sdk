using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Utils
{
    public static class RepositoryUtils
    {
        /// <summary>
        ///     Get the query string of chosen fields to read
        /// </summary>
        /// <param name="fields"> Chosen fields to read </param>
        /// <returns> String with field name chose separate by comma </returns>
        public static string GetFieldNameQueryString<T>(IList<T> fields) where T : struct, IConvertible
        {
            if (fields == null || !fields.Any())
            {
                return string.Empty;
            }

            string nameList = string.Empty;
            foreach (var adCampaignFieldsEnum in fields)
            {
                string fieldName = adCampaignFieldsEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (String.IsNullOrEmpty(fieldName))
                {
                    continue;
                }

                if (String.IsNullOrEmpty(nameList))
                {
                    nameList = fieldName;
                    continue;
                }

                nameList += "," + fieldName;
            }

            return nameList;
        }
    }
}
