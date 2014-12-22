using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup
{
    /// <summary>
    /// Available ad account fields
    /// </summary>
    public enum AdAccountGroupFieldsEnum
    {
        /// <summary>
        /// Undefined fields
        /// </summary>
        Undefined,
        
        /// <summary>
        /// The account group ID, required for updating an account group
        /// </summary>
        [FacebookName("account_group_id")]
        AccountGroupId,

        /// <summary>
        /// Name for the account group, and required when creating an account group; need not be unique; can be changed
        /// </summary>
        [FacebookName("name")]
        Name,

        /// <summary>
        /// Determines whether the account has a status of active (1) or deleted (2)
        /// </summary>
        [FacebookName("status")]
        Status
    }
}
