using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Ad campaign create data 
    /// </summary>
    public class AdCampaignCreateData
    {
        /// <summary>
        ///     Id of the ad account
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        ///     Buying type of the ad campaign
        /// </summary>
        public AdCampaignBuyingTypeEnum? BuyingType { get; set; }
        
        /// <summary>
        ///     Name of the ad campaign
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Objective of the ad campaign
        /// </summary>
        public AdCampaignObjectiveEnum? Objective { get; set; }

        /// <summary>
        ///     Status of the ad campaign
        /// </summary>
        public AdCampaignStatusEnum Status { get; set; }
    }
}