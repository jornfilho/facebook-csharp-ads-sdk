using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Extension of the ad campaign objective enum
    /// </summary>
    public static class AdCampaignObjectiveEnumExtension
    {
        /// <summary>
        ///     Get ad objective enum by objective name
        /// </summary>
        /// <param name="objectiveName"> Objective name </param>
        /// <returns> Enum with name </returns>
        public static AdCampaignObjectiveEnum GetAdCampaignObjective(this string objectiveName)
        {
            if (String.IsNullOrEmpty(objectiveName))
            {
                return AdCampaignObjectiveEnum.Undefined;
            }

            foreach (AdCampaignObjectiveEnum objectiveEnum in Enum.GetValues(typeof(AdCampaignObjectiveEnum)))
            {
                if (objectiveEnum == AdCampaignObjectiveEnum.Undefined)
                {
                    continue;
                }

                string facebookName = objectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();

                if (facebookName == objectiveName)
                {
                    return objectiveEnum;
                }
            }

            return AdCampaignObjectiveEnum.Undefined;
        }
    }
}
