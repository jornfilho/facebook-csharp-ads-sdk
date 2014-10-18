namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// List of available user permission
    /// </summary>
    public enum UserRoleEnum
    {
        /// <summary>
        /// Undefined permission
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// 1001, administrator access
        /// </summary>
        Administrator = 1001,

        /// <summary>
        /// 1002, advertiser (ad manager) access
        /// </summary>
        Advertiser = 1002,

        /// <summary>
        /// 1003, analyst access
        /// </summary>
        Analyst = 1003
    }
}
