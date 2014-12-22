namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// <para>Vat status code for the account. </para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/adaccount/v2.2#read </para>
    /// </summary>
    public enum TaxStatusEnum
    {
        /// <summary>
        /// Undefined tax status
        /// </summary>
        Undefined,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// VAT not required- US/CA
        /// </summary>
        VatNotRequiredUsCa = 1,

        /// <summary>
        /// VAT information required
        /// </summary>
        VarInformationRequired = 2,

        /// <summary>
        /// VAT information submitted
        /// </summary>
        VatInformationSubmitted = 3,

        /// <summary>
        /// Offline VAT validation failed
        /// </summary>
        OfflineVatValidationFailed = 4,

        /// <summary>
        /// Account is a personal account
        /// </summary>
        AccountIsAPersonalAccount = 5
    }
}
