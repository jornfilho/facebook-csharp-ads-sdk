using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup
{
    /// <summary>
    /// Extensions for AdAccountGroupFieldsEnum enum
    /// </summary>
    public static class AdAccountGroupFieldsEnumExtensions
    {
        /// <summary>
        /// Get ad account group field enum from facebook name
        /// </summary>
        public static AdAccountGroupFieldsEnum GetAdAccountGroupFieldsEnum(this string facebookName)
        {
            if (String.IsNullOrEmpty(facebookName))
                return AdAccountGroupFieldsEnum.Undefined;

            foreach (AdAccountGroupFieldsEnum field in Enum.GetValues(typeof(AdAccountGroupFieldsEnum)))
                if (field.GetFacebookName() == facebookName)
                    return field;

            return AdAccountGroupFieldsEnum.Undefined;
        }
        
        /// <summary>
        /// Get list of default ad account group fields
        /// </summary>
        public static IList<AdAccountGroupFieldsEnum> GetDefaultsAdAccountGroupFieldsList()
        {
            return new List<AdAccountGroupFieldsEnum>
            {
                AdAccountGroupFieldsEnum.AccountGroupId,
                AdAccountGroupFieldsEnum.Name,
                AdAccountGroupFieldsEnum.Status
            };
        }

        /// <summary>
        /// Get a list of available ad account group fields
        /// </summary>
        public static IList<AdAccountGroupFieldsEnum> GetAllAdAccountGroupFieldsList()
        {
            IList<AdAccountGroupFieldsEnum> result = new List<AdAccountGroupFieldsEnum>();
            foreach (AdAccountGroupFieldsEnum field in Enum.GetValues(typeof(AdAccountGroupFieldsEnum)))
                if (field != AdAccountGroupFieldsEnum.Undefined)
                    result.Add(field);

            return result;
        }

        /// <summary>
        /// Get facebook name from AdAccountGroupFieldsEnum enum
        /// </summary>
        public static string GetFacebookName(this AdAccountGroupFieldsEnum adAccountGroupField)
        {
            return adAccountGroupField == AdAccountGroupFieldsEnum.Undefined
                ? null
                : adAccountGroupField.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }

        /// <summary>
        /// Converte lista de campos do grupo de contas em lista de nomes do facebook dos campos
        /// </summary>
        public static IList<string> GetFacebookNamesList(this IList<AdAccountGroupFieldsEnum> fields)
        {
            IList<string> result = new List<string>();

            if (fields == null || !fields.Any())
                return result;

            var fieldsCount = fields.Count();
            for (var fieldIndex = 0; fieldIndex < fieldsCount; fieldIndex++)
            {
                var facebookName = fields[fieldIndex].GetFacebookName();
                if(String.IsNullOrEmpty(facebookName))
                    continue;

                result.Add(facebookName);
            }

            return result;
        }
    }
}
