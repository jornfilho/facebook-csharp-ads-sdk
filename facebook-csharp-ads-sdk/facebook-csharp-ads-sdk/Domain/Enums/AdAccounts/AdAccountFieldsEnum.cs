using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// Available ad account fields
    /// </summary>
    public enum AdAccountFieldsEnum
    {
        /// <summary>
        /// <para>Container for the ID, name, and status of the account's account groups</para>
        /// </summary>
        [FacebookName("account_groups")]
        [IsParentObject(true)]
        AccountGroups,

        /// <summary>
        /// <para>The ID of the ad account</para> 
        /// </summary>
        [FacebookName("account_id")]
        AccountId,

        /// <summary>
        /// <para>Status of the account.</para>
        /// </summary>
        [FacebookName("account_status")]
        AdAccountStatus,

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        [FacebookName("age")]
        Age,

        /// <summary>
        /// <para>Details of the agency advertising on behalf of this client account, if applicable.</para>
        /// </summary>
        [FacebookName("agency_client_declaration")]
        [IsParentObject(true)]
        AgencyClientDeclaration,

        /// <summary>
        /// <para>Current total amount spent by the account. This can be reset.</para>
        /// </summary>
        [FacebookName("amount_spent")]
        AmountSpent,

        /// <summary>
        /// <para>Bill amount due</para>
        /// </summary>
        [FacebookName("balance")]
        Balance,

        /// <summary>
        /// <para>City for business address</para>
        /// </summary>
        [FacebookName("business_city")]
        BusinessCity,

        /// <summary>
        /// <para>Country code for the business address</para>
        /// </summary>
        [FacebookName("business_country_code")]
        BusinessCountryCode,

        /// <summary>
        /// <para>The business name for the account</para>
        /// </summary>
        [FacebookName("business_name")]
        BusinessName,

        /// <summary>
        /// <para>State abbreviation for business address</para>
        /// </summary>
        [FacebookName("business_state")]
        BusinessState,

        /// <summary>
        /// <para>First line of the business street address for the account</para>
        /// </summary>
        [FacebookName("business_street")]
        BusinessStreet,

        /// <summary>
        /// <para>Second line of the business street address for the account</para>
        /// </summary>
        [FacebookName("business_street2")]
        BusinessStreet2,

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        [FacebookName("business_zip")]
        BusinessZip,

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        [FacebookName("capabilities")]
        Capabilities,

        /// <summary>
        /// <para>The currency used for the account, based on the corresponding value in the account settings.</para>
        /// <para>The list of supported currencies can be found at https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
        /// </summary>
        [FacebookName("currency")]
        Currency,

        /// <summary>
        /// <para>The account's limit for daily spend, based on the corresponding value in the account settings</para>
        /// </summary>
        [FacebookName("daily_spend_limit")]
        DailySpendLimit,

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [FacebookName("end_advertiser")]
        EndAdvertiser,

        /// <summary>
        /// <para>ID of the funding source</para>
        /// </summary>
        [FacebookName("funding_source")]
        FundingSource,

        /// <summary>
        /// <para>The details of funding source</para>
        /// </summary>
        [FacebookName("funding_source_details")]
        FundingSourceDetails,

        /// <summary>
        /// <para>The string act_{ad_account_id}</para>
        /// </summary>
        [FacebookName("id")]
        Id,

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        [FacebookName("is_personal")]
        IsPersonal,

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [FacebookName("media_agency")]
        MediaAgency,

        /// <summary>
        /// <para>Name of the account; note that many accounts are unnamed, so this field may be empty</para>
        /// </summary>
        [FacebookName("name")]
        Name,

        /// <summary>
        /// <para>Indicates whether the offsite pixel Terms Of Service contract was signed</para>
        /// </summary>
        [FacebookName("offsite_pixels_tos_accepted")]
        OffsitePixelsTosAccepted,

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [FacebookName("partner")]
        Partner,

        /// <summary>
        /// <para>The maximum that can be spent by this account after which campaigns will be paused.</para>
        /// <para>A value of 0 signifies no spending-cap and setting a new spend cap only applies to spend AFTER the time at which you set it.</para>
        /// <para>Value specified in basic unit of the currency, e.g. dollars for USD</para>
        /// </summary>
        [FacebookName("spend_cap")]
        SpendCap,

        /// <summary>
        /// <para>ID for the timezone. See at https://fbcdn-dragon-a.akamaihd.net/hphotos-ak-prn1/851565_362033717242167_978236896_n.txt </para>
        /// </summary>
        [FacebookName("timezone_id")]
        TimezoneId,

        /// <summary>
        /// <para>Name for the time zone</para>
        /// </summary>
        [FacebookName("timezone_name")]
        TimezoneName,

        /// <summary>
        /// <para>Time Zone difference from UTC</para>
        /// </summary>
        [FacebookName("timezone_offset_hours_utc")]
        TimezoneOffsetHoursUtc,

        /// <summary>
        /// <para>IDs of Terms of Service contracts signed</para>
        /// </summary>
        [FacebookName("tos_accepted")]
        TosAccepted,

        /// <summary>
        /// <para>Container for the user ID, permissions, and role</para>
        /// </summary>
        [IsParentObject(true)]
        [FacebookName("users")]
        Users,

        /// <summary>
        /// <para>Vat status code for the account. </para>
        /// </summary>
        [FacebookName("tax_id_status")]
        TaxStatus
    }
}
