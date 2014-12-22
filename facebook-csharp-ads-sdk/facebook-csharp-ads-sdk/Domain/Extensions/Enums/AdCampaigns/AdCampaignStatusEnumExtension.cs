using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Extension of the enum AdCampaignStatusEnum
    /// </summary>
    public static class AdCampaignStatusEnumExtension
    {
        /// <summary>
        ///     Get AdCampaignStatusEnum enum by status name
        /// </summary>
        /// <param name="statusName"> Status name </param>
        /// <returns> AdCampaignStatusEnum with name passed </returns>
        public static AdCampaignStatusEnum GetCampaignStatus(this string statusName)
        {
            if (String.IsNullOrEmpty(statusName))
            {
                return AdCampaignStatusEnum.Undefined;
            }

            foreach (AdCampaignStatusEnum statusEnum in Enum.GetValues(typeof (AdCampaignStatusEnum)))
            {
                if (statusEnum == AdCampaignStatusEnum.Undefined)
                {
                    continue;
                }

                string facebookName = statusEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();

                if (facebookName == statusName)
                {
                    return statusEnum;
                }
            }

            return AdCampaignStatusEnum.Undefined;
        }

        /// <summary>
        ///     Get Facebook name of the campaign status
        /// </summary>
        /// <param name="campaignStatusEnum"> Campaign status type enum </param>
        /// <returns> Facebook name </returns>
        public static string GetCampaignStatusFacebookName(this AdCampaignStatusEnum campaignStatusEnum)
        {
            return campaignStatusEnum.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();
        }
    }
}