using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections
{
    /// <summary>
    /// Possible event_type by object
    /// </summary>
    public enum AdActivityLogEventTypesEnum
    {
        /// <summary>
        /// Undefined fields
        /// </summary>
        Undefined,

        #region ad account
        /// <summary>
        /// <para> update the spend limit of an ad account </para>
        /// </summary>
        [FacebookName("ad_account_update_spend_limit")]
        AdAccountUpdateSpendLimit,
        
        /// <summary>
        /// <para> reset the spend limit of an ad account </para>
        /// </summary>
        [FacebookName("ad_account_reset_spend_limt")]
        AdAccountResetSpendLimt,

        /// <summary>
        /// <para> remove the spend limit of an ad account. You would have unlimited spend limit if you remove spend limit </para>
        /// </summary>
        [FacebookName("ad_account_remove_spend_limit")]
        AdAccountRemoveSpendLimit,

        /// <summary>
        /// <para> set business information for this ad account </para>
        /// </summary>
        [FacebookName("ad_account_set_business_information")]
        AdAccountSetBusinessInformation,

        /// <summary>
        /// <para> update account status, includes: disabled, active, test, unsettled, pending closure, closed, pending risk review, in grace period </para>
        /// </summary>
        [FacebookName("ad_account_update_status")]
        AdAccountUpdateStatus,

        /// <summary>
        /// <para> add user to ad account </para>
        /// </summary>
        [FacebookName("ad_account_add_user_to_role")]
        AdAccountAddUserToRole,

        /// <summary>
        /// <para> remove user from ad account </para>
        /// </summary>
        [FacebookName("ad_account_remove_user_from_role")]
        AdAccountRemoveUserFromRole,

        /// <summary>
        /// <para> add an image to ad account image library </para>
        /// </summary>
        [FacebookName("add_images")]
        AddImages,

        /// <summary>
        /// <para> edit an image in ad account image library </para>
        /// </summary>
        [FacebookName("edit_images")]
        EditImages,
        #endregion

        #region billing
        /// <summary>
        /// <para> charge ad account </para>
        /// </summary>
        [FacebookName("ad_account_billing_charge")]
        AdAccountBillingCharge,

        /// <summary>
        /// <para> undo the charging on ad account per bank's instructions </para>
        /// </summary>
        [FacebookName("ad_account_billing_charge_back")]
        AdAccountBillingChargeBack,

        /// <summary>
        /// <para> reapply the undone charging </para>
        /// </summary>
        [FacebookName("ad_account_billing_charge_back_reversal")]
        AdAccountBillingChargeBackReversal,

        /// <summary>
        /// <para> billings was declined </para>
        /// </summary>
        [FacebookName("ad_account_billing_decline")]
        AdAccountBillingDecline,

        /// <summary>
        /// <para> refund on ad account </para>
        /// </summary>
        [FacebookName("ad_account_billing_refund")]
        AdAccountBillingRefund,

        /// <summary>
        /// <para> add funding source to ad account </para>
        /// </summary>
        [FacebookName("add_funding_source")]
        AddFundingSource,

        /// <summary>
        /// <para> remove funding source from ad account </para>
        /// </summary>
        [FacebookName("remove_funding_source")]
        RemoveFundingSource,
        #endregion

        #region campaign
        /// <summary>
        /// <para> create campaign </para>
        /// </summary>
        [FacebookName("create_campaign")]
        CreateCampaign,

        /// <summary>
        /// <para> update campaign friendly name </para>
        /// </summary>
        [FacebookName("update_campaign_name")]
        UpdateCampaignName,

        /// <summary>
        /// <para> update campaign run status </para>
        /// </summary>
        [FacebookName("update_campaign_run_status")]
        UpdateCampaignRunStatus,
        #endregion

        #region ad set
        /// <summary>
        /// <para> create ad set </para>
        /// </summary>
        [FacebookName("create_ad_set")]
        CreateAdSet,

        /// <summary>
        /// <para> update ad set friendly name </para>
        /// </summary>
        [FacebookName("update_ad_set_name")]
        UpdateAdSetName,

        /// <summary>
        /// <para> update ad set run status </para>
        /// </summary>
        [FacebookName("update_ad_set_run_status")]
        UpdateAdSetRunStatus,

        /// <summary>
        /// <para> update ad set budget </para>
        /// </summary>
        [FacebookName("update_ad_sets_budget")]
        UpdateAdSetsBudget,

        /// <summary>
        /// <para> update ad set duration </para>
        /// </summary>
        [FacebookName("update_ad_sets_duration")]
        UpdateAdSetsDuration,
        #endregion

        #region ad group
        /// <summary>
        /// <para> create ad </para>
        /// </summary>
        [FacebookName("create_ad")]
        CreateAd,

        /// <summary>
        /// <para> update creative of ad, including image/title/text change. </para>
        /// </summary>
        [FacebookName("update_ad_creative")]
        UpdateAdCreative,

        /// <summary>
        /// <para> update bid information </para>
        /// </summary>
        [FacebookName("update_ad_bid_info")]
        UpdateAdBidInfo,

        /// <summary>
        /// <para> update bid type </para>
        /// </summary>
        [FacebookName("update_ad_bid_type")]
        UpdateAdBidType,

        /// <summary>
        /// <para> update adgroup run status </para>
        /// </summary>
        [FacebookName("update_ad_run_status")]
        UpdateAdRunStatus,

        /// <summary>
        /// <para> update adgroup friendly name </para>
        /// </summary>
        [FacebookName("update_ad_friendly_name")]
        UpdateAdFriendlyName,

        /// <summary>
        /// <para> update adgroup targeting </para>
        /// </summary>
        [FacebookName("update_ad_targets_spec")]
        UpdateAdTargetsSpec,

        /// <summary>
        /// <para> ad review was approved </para>
        /// </summary>
        [FacebookName("ad_review_approved")]
        AdReviewApproved,

        /// <summary>
        /// <para> ad review was not approved </para>
        /// </summary>
        [FacebookName("ad_review_declined")]
        AdReviewDeclined,
        #endregion

        #region other
        /// <summary>
        /// <para> create custom audience </para>
        /// </summary>
        [FacebookName("create_audience")]
        CreateAudience,

        /// <summary>
        /// <para> delete custom audience </para>
        /// </summary>
        [FacebookName("delete_audience")]
        DeleteAudience
        #endregion
    }
}
