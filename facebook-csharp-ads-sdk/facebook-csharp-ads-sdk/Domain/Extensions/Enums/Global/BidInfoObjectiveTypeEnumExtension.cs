using System;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global
{
    /// <summary>
    ///     Extension for the enum BidInfoObjectiveTypeEnum
    /// </summary>
    public static class BidInfoObjectiveTypeEnumExtension
    {
        /// <summary>
        ///     Get ad set bid type enum by facebook bid type
        /// </summary>
        /// <param name="bidInfoType"> Bid type </param>
        /// <returns> Enum with name </returns>
        public static BidInfoObjectiveTypeEnum GetBidInfoType(this string bidInfoType)
        {
            if (String.IsNullOrEmpty(bidInfoType))
            {
                return BidInfoObjectiveTypeEnum.Undefined;
            }

            foreach (BidInfoObjectiveTypeEnum objectiveEnum in Enum.GetValues(typeof (BidInfoObjectiveTypeEnum)))
            {
                if (objectiveEnum == BidInfoObjectiveTypeEnum.Undefined)
                {
                    continue;
                }

                string facebookName = objectiveEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
                if (facebookName == bidInfoType)
                {
                    return objectiveEnum;
                }
            }

            return BidInfoObjectiveTypeEnum.Undefined;
        }
    }
}