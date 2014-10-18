using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.Accounts;
using Newtonsoft.Json;

namespace facebook_csharp_ads_sdk.Domain.Models.Accounts
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/adaccount#read
    /// </summary>
    [Serializable]
    public class Account
    {
        #region Params
        /// <summary>
        /// <para>Container for the ID, name, and status of the account's account groups</para>
        /// </summary>
        [JsonProperty("account_groups")]
        public IList<AccountGroup> AccountGroups { get; private set; }

        /// <summary>
        /// <para>The ID of the ad account</para> 
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; private set; }

        /// <summary>
        /// <para>Status of the account.</para>
        /// </summary>
        [JsonProperty("account_status")]
        public AccountStatus AccountStatus { get; private set; }

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        [JsonProperty("age")]
        public float Age { get; private set; }

        /// <summary>
        /// <para>Details of the agency advertising on behalf of this client account, if applicable.</para>
        /// </summary>
        [JsonProperty("agency_client_declaration")]
        public AgencyClientDeclaration AgencyClientDeclaration { get; private set; }

        /// <summary>
        /// <para>Current total amount spent by the account. This can be reset.</para>
        /// </summary>
        [JsonProperty("amount_spent")]
        public long AmountSpent { get; private set; }

        /// <summary>
        /// <para>Bill amount due</para>
        /// </summary>
        [JsonProperty("balance")]
        public long Balance { get; private set; }

        /// <summary>
        /// <para>City for business address</para>
        /// </summary>
        [JsonProperty("business_city")]
        public string BusinessCity { get; private set; }

        /// <summary>
        /// <para>Country code for the business address</para>
        /// </summary>
        [JsonProperty("business_country_code")]
        public string BusinessCountryCode { get; private set; }

        /// <summary>
        /// <para>The business name for the account</para>
        /// </summary>
        [JsonProperty("business_name")]
        public string BusinessName { get; private set; }

        /// <summary>
        /// <para>State abbreviation for business address</para>
        /// </summary>
        [JsonProperty("business_state")]
        public string BusinessState { get; private set; }

        /// <summary>
        /// <para>First line of the business street address for the account</para>
        /// </summary>
        [JsonProperty("business_street")]
        public string BusinessStreet { get; private set; }

        /// <summary>
        /// <para>Second line of the business street address for the account</para>
        /// </summary>
        [JsonProperty("business_street2")]
        public string BusinessStreet2 { get; private set; }

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        [JsonProperty("business_zip")]
        public string BusinessZip { get; private set; }

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        [JsonProperty("capabilities")]
        public IList<Capabilities> Capabilities { get; private set; }

        /// <summary>
        /// <para>The currency used for the account, based on the corresponding value in the account settings.</para>
        /// <para>The list of supported currencies can be found at https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
        /// </summary>
        [JsonProperty("currency")]
        public IList<Currency> Currency { get; private set; }

        /// <summary>
        /// <para>The account's limit for daily spend, based on the corresponding value in the account settings</para>
        /// </summary>
        [JsonProperty("daily_spend_limit")]
        public long daily_spend_limit { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [JsonProperty("end_advertiser")]
        public long end_advertiser { get; private set; }

        /// <summary>
        /// <para>ID of the funding source</para>
        /// </summary>
        [JsonProperty("funding_source")]
        public long funding_source { get; private set; }

        /// <summary>
        /// <para>The details of funding source</para>
        /// </summary>
        [JsonProperty("funding_source_details")]
        public IList<FundingSourceDetail> FundingSourceDetails { get; private set; }

        /// <summary>
        /// <para>The string act_{ad_account_id}</para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        [JsonProperty("is_personal")]
        public bool IsPersonal { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [JsonProperty("media_agency")]
        public long MediaAgency { get; private set; }

        /// <summary>
        /// <para>Name of the account; note that many accounts are unnamed, so this field may be empty</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// <para>Indicates whether the offsite pixel Terms Of Service contract was signed</para>
        /// </summary>
        [JsonProperty("offsite_pixels_tos_accepted")]
        public bool OffsitePixelsTosAccepted { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [JsonProperty("partner")]
        public long Partner { get; private set; }

        /// <summary>
        /// <para>The maximum that can be spent by this account after which campaigns will be paused.</para>
        /// <para>A value of 0 signifies no spending-cap and setting a new spend cap only applies to spend AFTER the time at which you set it.</para>
        /// <para>Value specified in basic unit of the currency, e.g. dollars for USD</para>
        /// </summary>
        [JsonProperty("spend_cap")]
        public double SpendCap { get; private set; }

        /// <summary>
        /// <para>ID for the timezone. See at https://fbcdn-dragon-a.akamaihd.net/hphotos-ak-prn1/851565_362033717242167_978236896_n.txt </para>
        /// </summary>
        [JsonProperty("timezone_id")]
        public int TimezoneId { get; private set; }

        /// <summary>
        /// <para>Name for the time zone</para>
        /// </summary>
        [JsonProperty("timezone_name")]
        public string TimezoneName { get; private set; }

        /// <summary>
        /// <para>Time Zone difference from UTC</para>
        /// </summary>
        [JsonProperty("timezone_offset_hours_utc")]
        public int TimezoneOffsetHoursUtc { get; private set; }

        /// <summary>
        /// <para>IDs of Terms of Service contracts signed</para>
        /// </summary>
        [JsonProperty("tos_accepted")]
        public IList<long> TosAccepted { get; private set; }

        /// <summary>
        /// <para>Container for the user ID, permissions, and role</para>
        /// </summary>
        [JsonProperty("users")]
        public IList<User> Users { get; private set; }

        /// <summary>
        /// <para>Vat status code for the account. </para>
        /// </summary>
        [JsonProperty("tax_id_status")]
        public TaxStatus TaxStatus { get; private set; } 
        #endregion
    }

    public class AccountGroup
    {
        #region Params
        [JsonProperty("account_group_id")]
        public long AccountGroupId { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("status")]
        public int Status { get; private set; } 
        #endregion
    }

    public class AgencyClientDeclaration
    {
        #region Params
        /// <summary>
        /// <para>Whether this account is for an agency representing a client</para>
        /// </summary>
        [JsonProperty("agency_representing_client")]
        public long AgencyRepresentingClient { get; private set; }

        /// <summary>
        /// <para>Whether the client is based in France</para>
        /// </summary>
        [JsonProperty("client_based_in_france")]
        public long ClientBasedInFrance { get; private set; }

        /// <summary>
        /// <para>Client's city</para>
        /// </summary>
        [JsonProperty("client_city")]
        public string ClientCity { get; private set; }

        /// <summary>
        /// <para>Client's country code</para>
        /// </summary>
        [JsonProperty("client_country_code")]
        public string ClientCountryCode { get; private set; }

        /// <summary>
        /// <para>Client's email address</para>
        /// </summary>
        [JsonProperty("client_email_address")]
        public string ClientEmailAddress { get; private set; }

        /// <summary>
        /// <para>Name of the client</para>
        /// </summary>
        [JsonProperty("client_name")]
        public string ClientName { get; private set; }

        /// <summary>
        /// <para>Client's postal code</para>
        /// </summary>
        [JsonProperty("client_postal_code")]
        public string ClientPostalCode { get; private set; }

        /// <summary>
        /// <para>Client's province</para>
        /// </summary>
        [JsonProperty("client_province")]
        public string ClientProvince { get; private set; }

        /// <summary>
        /// <para>First line of client's street address</para>
        /// </summary>
        [JsonProperty("client_street")]
        public string ClientStreet { get; private set; }

        /// <summary>
        /// <para>Second line of client's street address</para>
        /// </summary>
        [JsonProperty("client_street2")]
        public string ClientStreet2 { get; private set; }

        /// <summary>
        /// <para>Whether the agency has a written mandate to advertise on behalf of this client</para>
        /// </summary>
        [JsonProperty("has_written_mandate_from_advertiser")]
        public long HasWrittenMandateFromAdvertiser { get; private set; }

        /// <summary>
        /// <para>Whether the client is paying via invoice</para>
        /// </summary>
        [JsonProperty("is_client_paying_invoices")]
        public long IsClientPayingInvoices { get; private set; } 
        #endregion
    }

    public class FundingSourceDetail
    {
        #region Params
        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; private set; }

        //TODO: Know more about this field on Facebook
        [JsonProperty("type")]
        public int Type { get; private set; } 
        #endregion
    }

    public class User
    {
        #region Params
        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("permissions")]
        public IList<int> Permissions { get; private set; }

        [JsonProperty("role")]
        public int Role { get; private set; } 
        #endregion
    }
}
