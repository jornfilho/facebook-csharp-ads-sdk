using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdSet
{
    public static class AdSetStatusEnumExtension
    {
        /// <summary>
        ///     Get ad set status enum
        /// </summary>
        /// <param name="status"> Ad set status </param>
        /// <returns> Enum with name </returns>
        public static AdSetStatusEnum GetAdSetStatus(this string status)
        {
            if (String.IsNullOrEmpty(status))
            {
                return AdSetStatusEnum.Undefined;
            }

            foreach (AdSetStatusEnum objectiveEnum in Enum.GetValues(typeof (AdSetStatusEnum)))
            {
                if (objectiveEnum == AdSetStatusEnum.Undefined)
                {
                    continue;
                }

                string facebookName = objectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (facebookName == status)
                {
                    return objectiveEnum;
                }
            }

            return AdSetStatusEnum.Undefined;
        }

        /// <summary>
        ///     Get Facebook name of the ad status
        /// </summary>
        /// <param name="campaignObjectiveEnum"> Ad status enum </param>
        /// <returns> Facebook name </returns>
        public static string GetAdSetStatusFacebookName(this AdSetStatusEnum campaignObjectiveEnum)
        {
            return campaignObjectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}