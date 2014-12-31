using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Ad campaign update data
    /// </summary>
    public class AdCampaignUpdateData
    {
        /// <summary>
        ///     Id of the ad account
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        ///     <para> Name of the ad campaign </para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Objective of the ad campaign
        /// </summary>
        public AdCampaignObjectiveEnum? Objective { get; set; }

        /// <summary>
        ///     Status of the ad campaign
        /// </summary>
        public AdCampaignStatusEnum? Status { get; set; }
    }
}