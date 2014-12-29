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
    /// Extensoes do enum de tipos de evento de log de atividades AdActivityLogEventTypesEnumExtensions
    /// </summary>
    public static class AdActivityLogEventTypesEnumExtensions
    {
        /// <summary>
        /// Get ad activity log field enum from facebook name
        /// </summary>
        public static AdActivityLogEventTypesEnum GetAdActivityLogEventEnum (this string facebookName)
        {
            if (String.IsNullOrEmpty(facebookName))
                return AdActivityLogEventTypesEnum.Undefined;

            foreach (AdActivityLogEventTypesEnum eventType in Enum.GetValues(typeof(AdActivityLogEventTypesEnum)))
                if (eventType.GetFacebookName() == facebookName)
                    return eventType;

            return AdActivityLogEventTypesEnum.Undefined;
        }

        /// <summary>
        /// Get a list of available ad activity event types
        /// </summary>
        public static IList<AdActivityLogEventTypesEnum> GetAllAdActivityLogEventTypesList()
        {
            IList<AdActivityLogEventTypesEnum> result = new List<AdActivityLogEventTypesEnum>();
            foreach (AdActivityLogEventTypesEnum field in Enum.GetValues(typeof(AdActivityLogEventTypesEnum)))
                if (field != AdActivityLogEventTypesEnum.Undefined)
                    result.Add(field);

            return result;
        }

        /// <summary>
        /// Get facebook name from AdActivityLogEventTypesEnum enum
        /// </summary>
        public static string GetFacebookName(this AdActivityLogEventTypesEnum adActivityEventTypeField)
        {
            return adActivityEventTypeField == AdActivityLogEventTypesEnum.Undefined
                ? null
                : adActivityEventTypeField.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }

        /// <summary>
        /// Converte lista tipos de eventos do log de atividades em lista de nomes do facebook dos campos
        /// </summary>
        public static IList<string> GetFacebookNamesList(this IList<AdActivityLogEventTypesEnum> eventTypes)
        {
            IList<string> result = new List<string>();

            if (eventTypes == null || !eventTypes.Any())
                return result;

            var eventsCount = eventTypes.Count();
            for (var eventIndex = 0; eventIndex < eventsCount; eventIndex++)
            {
                var facebookName = eventTypes[eventIndex].GetFacebookName();
                if (String.IsNullOrEmpty(facebookName))
                    continue;

                result.Add(facebookName);
            }

            return result;
        }
    }
}
