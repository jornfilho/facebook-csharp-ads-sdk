namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    public enum TaxStatusEnum
    {
        Undefined,
        Unknown = 0,
        VatNotRequiredUsCa = 1,
        VarInformationRequired = 2,
        VatInformationSubmitted = 3,
        OfflineVatValidationFailed = 4,
        AccountIsAPersonalAccount = 5
    }
}
