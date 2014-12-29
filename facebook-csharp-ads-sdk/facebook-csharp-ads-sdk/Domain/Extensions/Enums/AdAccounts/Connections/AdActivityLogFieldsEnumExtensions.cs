using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts.Connections
{
    /// <summary>
    /// Extensoes do enum de log de atividades AdActivityLogFieldsEnum
    /// </summary>
    public static class AdActivityLogFieldsEnumExtensions
    {
        /// <summary>
        /// Get ad activity log field enum from facebook name
        /// </summary>
        public static AdActivityLogFieldsEnum GetAdActivityLogFieldsEnum(this string facebookName)
        {
            if (String.IsNullOrEmpty(facebookName))
                return AdActivityLogFieldsEnum.Undefined;

            foreach (AdActivityLogFieldsEnum field in Enum.GetValues(typeof(AdActivityLogFieldsEnum)))
                if (field.GetFacebookName() == facebookName)
                    return field;

            return AdActivityLogFieldsEnum.Undefined;
        }

        /// <summary>
        /// Get list of default ad activity log fields
        /// </summary>
        public static IList<AdActivityLogFieldsEnum> GetDefaultsAdActivityLogFieldsList()
        {
            return new List<AdActivityLogFieldsEnum>
            {
                AdActivityLogFieldsEnum.EventType,
                AdActivityLogFieldsEnum.EventTime
            };
        }

        /// <summary>
        /// Get a list of available ad activity fields
        /// </summary>
        public static IList<AdActivityLogFieldsEnum> GetAllAdActivityLogFieldsList()
        {
            IList<AdActivityLogFieldsEnum> result = new List<AdActivityLogFieldsEnum>();
            foreach (AdActivityLogFieldsEnum field in Enum.GetValues(typeof(AdActivityLogFieldsEnum)))
                if (field != AdActivityLogFieldsEnum.Undefined)
                    result.Add(field);

            return result;
        }

        /// <summary>
        /// Get facebook name from AdActivityLogFieldsEnum enum
        /// </summary>
        public static string GetFacebookName(this AdActivityLogFieldsEnum adActivityLogField)
        {
            return adActivityLogField == AdActivityLogFieldsEnum.Undefined
                ? null
                : adActivityLogField.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }

        /// <summary>
        /// Converte lista de campos do log de atividades em lista de nomes do facebook dos campos
        /// </summary>
        public static IList<string> GetFacebookNamesList(this IList<AdActivityLogFieldsEnum> fields)
        {
            IList<string> result = new List<string>();

            if (fields == null || !fields.Any())
                return result;

            var fieldsCount = fields.Count();
            for (var fieldIndex = 0; fieldIndex < fieldsCount; fieldIndex++)
            {
                var facebookName = fields[fieldIndex].GetFacebookName();
                if (String.IsNullOrEmpty(facebookName))
                    continue;

                result.Add(facebookName);
            }

            return result;
        }
    }
}
