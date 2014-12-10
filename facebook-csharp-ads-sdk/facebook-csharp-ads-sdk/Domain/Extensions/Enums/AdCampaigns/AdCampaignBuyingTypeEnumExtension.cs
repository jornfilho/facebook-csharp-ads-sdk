using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Extension of the buying type
    /// </summary>
    public static class AdCampaignBuyingTypeEnumExtension
    {
        /// <summary>
        ///     Get the buying type enum by facebook name
        /// </summary>
        /// <param name="buyingTypeName"> Buying type name </param>
        /// <returns> Enum with name corresponding name </returns>
        public static AdCampaignBuyingTypeEnum GetBuyingTypeEnum(this string buyingTypeName)
        {
            if (String.IsNullOrEmpty(buyingTypeName))
            {
                return AdCampaignBuyingTypeEnum.Undefined;
            }

            foreach (AdCampaignBuyingTypeEnum buyingTypeEnum in Enum.GetValues(typeof (AdCampaignBuyingTypeEnum)))
            {
                if (buyingTypeEnum == AdCampaignBuyingTypeEnum.Undefined)
                {
                    continue;
                }

                string facebookName = buyingTypeEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();

                if (facebookName == buyingTypeName)
                {
                    return buyingTypeEnum;
                }
            }

            return AdCampaignBuyingTypeEnum.Undefined;
        }

        /// <summary>
        ///     Get Facebook name of the buying type enum
        /// </summary>
        /// <param name="buyingTypeEnum"> Buying tupe enum </param>
        /// <returns> Facebook name </returns>
        public static string GetBuyingTypeFacebookName(this AdCampaignBuyingTypeEnum buyingTypeEnum)
        {
            return buyingTypeEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}