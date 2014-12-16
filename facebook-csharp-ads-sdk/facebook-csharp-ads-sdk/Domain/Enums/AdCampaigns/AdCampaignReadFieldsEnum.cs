using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns
{
    public enum AdCampaignReadFieldsEnum
    {
        /// <summary>
        /// <para> Id of the ad campaign </para>
        /// </summary>
        [FacebookName("id")]
        Id,

        /// <summary>
        /// <para> Id of the account </para>
        /// </summary>
        [FacebookName("account_id")]
        AccountId,

        /// <summary>
        /// <para> Objective of the ad campaign </para>
        /// </summary>
        [FacebookName("objective")]
        Objective,

        /// <summary>
        /// <para> Name of the ad campaign </para>
        /// </summary>
        [FacebookName("name")]
        Name,

        /// <summary>
        /// <para> Adgroups owned by this ad campaign </para>
        /// </summary>
        [FacebookName("adgroups")]
        Adgroups,

        /// <summary>
        /// <para> Status of the ad campaign </para>
        /// </summary>
        [FacebookName("campaign_group_status")]
        Status,

        /// <summary>
        /// <para> Buying type of the ad campaign </para>
        /// </summary>
        [FacebookName("buying_type")]
        BuyingType
    }
}
