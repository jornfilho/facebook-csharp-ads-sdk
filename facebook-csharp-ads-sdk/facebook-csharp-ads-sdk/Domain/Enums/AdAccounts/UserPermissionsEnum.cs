namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// List of available user permission
    /// </summary>
    public enum UserPermissionsEnum
    {
        /// <summary>
        /// Undefined permission
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// ACCOUNT_ADMIN: modify the set of users associated with the given account.
        /// </summary>
        AccountAdmin = 1,

        /// <summary>
        /// ADMANAGER_READ: view campaigns and ads
        /// </summary>
        AdManagerRead = 2,

        /// <summary>
        /// ADMANAGER_WRITE: manage campaigns and ads
        /// </summary>
        AdManagerWrite = 3,

        /// <summary>
        /// BILLING_READ: view account billing information
        /// </summary>
        BillingRead = 4,

        /// <summary>
        /// BILLING_WRITE: modify the account billing information
        /// </summary>
        BillingWrite = 5,

        /// <summary>
        /// REPORTS: run reports
        /// </summary>
        Reports = 7
    }
}
