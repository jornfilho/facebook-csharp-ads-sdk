using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdSet
{
    public static class AdSetBidTypeEnumExtension
    {
        /// <summary>
        ///     Get ad set bid type enum by facebook bid type
        /// </summary>
        /// <param name="bidType"> Bid type </param>
        /// <returns> Enum with name </returns>
        public static AdSetBidTypeEnum GetAdSetBidType(this string bidType)
        {
            if (String.IsNullOrEmpty(bidType))
            {
                return AdSetBidTypeEnum.Undefined;
            }

            foreach (AdSetBidTypeEnum objectiveEnum in Enum.GetValues(typeof(AdSetBidTypeEnum)))
            {
                if (objectiveEnum == AdSetBidTypeEnum.Undefined)
                {
                    continue;
                }

                string facebookName = objectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (facebookName == bidType)
                {
                    return objectiveEnum;
                }
            }

            return AdSetBidTypeEnum.Undefined;
        }

        /// <summary>
        ///     Get Facebook name of the bid type enum
        /// </summary>
        /// <param name="campaignObjectiveEnum"> Bid type enum </param>
        /// <returns> Facebook name </returns>
        public static string GetBidTypeFacebookName(this AdSetBidTypeEnum campaignObjectiveEnum)
        {
            return campaignObjectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}
