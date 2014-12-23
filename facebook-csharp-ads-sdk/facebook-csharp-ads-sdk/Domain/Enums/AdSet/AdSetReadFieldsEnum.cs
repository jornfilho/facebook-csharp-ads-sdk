using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdSet
{
    /// <summary>
    ///     Fields to read a ad set
    /// </summary>
    public enum AdSetReadFieldsEnum
    {
        /// <summary>
        /// <para> Id of the ad set </para>
        /// </summary>
        [FacebookName("id")]
        Id,

        /// <summary>
        /// <para> Name of the ad set </para>
        /// </summary>
        [FacebookName("name")]
        Name,

        /// <summary>
        /// <para> Id of the ad account </para>
        /// </summary>
        [FacebookName("account_id")]
        AccountId,
        
        /// <summary>
        /// <para>  Ad set bid type </para>
        /// </summary>
        [FacebookName("bid_type")]
        BidType,
        
        /// <summary>
        /// <para> Ad set bid info </para>
        /// </summary>
        [FacebookName("bid_info")]
        BidInfo,
        
        /// <summary>
        /// <para> The ad campaign this ad set is a part of </para>
        /// </summary>
        [FacebookName("campaign_group_id")]
        AdCampaignId,
        
        /// <summary>
        /// <para> Ad set status </para>
        /// </summary>
        [FacebookName("campaign_status")]
        Status,
        
        /// <summary>
        /// <para> Ad set start time </para>
        /// </summary>
        [FacebookName("start_time")]
        StartTime,
        
        /// <summary>
        /// <para> Ad set end time </para>
        /// </summary>
        [FacebookName("end_time")]
        EndTime,
        
        /// <summary>
        /// <para> Ad set updated time </para>
        /// </summary>
        [FacebookName("updated_time")]
        UpdatedTime,
        
        /// <summary>
        /// <para> Ad set created time </para>
        /// </summary>
        [FacebookName("created_time")]
        CreateTime,
        
        /// <summary>
        /// <para> The daily budget of the set, defined in your account currency </para>
        /// </summary>
        [FacebookName("daily_budget")]
        DailyBudget,
        
        /// <summary>
        /// <para> The life time budget of the set, defined in your account currency </para>
        /// </summary>
        [FacebookName("lifetime_budget")]
        LifetimeBudget,
        
        /// <summary>
        /// <para> The budget you have left on the set, defined in your account currency </para>
        /// </summary>
        [FacebookName("budget_remaining")]
        BudgetRemaining,
        
        /// <summary>
        /// <para> The targeting specification of this ad set </para>
        /// </summary>
        [FacebookName("targeting")]
        Targeting,
        
        /// <summary>
        /// <para> The object that the ad set is trying to promote and advertise </para>
        /// </summary>
        [FacebookName("promoted_object")]
        PromotedObject,


    }
}
