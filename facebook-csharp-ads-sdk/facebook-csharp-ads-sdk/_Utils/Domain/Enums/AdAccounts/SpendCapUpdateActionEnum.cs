using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// Update ad account spend cap enum options
    /// </summary>
    public enum SpendCapUpdateActionEnum
    {
        /// <summary>
        /// Undefined update option
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Sets the amount_spent back to 0
        /// </summary>
        [FacebookName("reset")]
        Reset = 1,

        /// <summary>
        /// Removes the spend_cap from the account
        /// </summary>
        [FacebookName("delete")]
        Delete = 2
    }
}
