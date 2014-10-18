using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using Newtonsoft.Json;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/adaccount#read
    /// </summary>
    public class AdAccount
    {
        #region Params
        /// <summary>
        /// <para>The string act_{ad_account_id}</para>
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// <para>The ID of the ad account</para> 
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// <para>Name of the account; note that many accounts are unnamed, so this field may be empty</para>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// <para>Status of the account.</para>
        /// </summary>
        public AdAccountStatusEnum AccountStatus { get; private set; }

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        public float Age { get; private set; }

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        [JsonProperty("is_personal")]
        public bool IsPersonal { get; private set; }

        /// <summary>
        /// Business account information
        /// </summary>
        public BusinessInformations BusinessInformations { get; private set; }

        /// <summary>
        /// Account timezone informations
        /// </summary>
        public TimezoneInformations TimezoneInformations { get; private set; }
        
        /// <summary>
        /// <para>Container for the ID, name, and status of the account's account groups</para>
        /// </summary>
        public IList<AdAccountGroup> AccountGroups { get; private set; }

        /// <summary>
        /// Financial account informations
        /// </summary>
        public FinancialInformations FinancialInformations { get; private set; }

        /// <summary>
        /// <para>Details of the agency advertising on behalf of this client account, if applicable.</para>
        /// </summary>
        public AgencyClientDeclaration AgencyClientDeclaration { get; private set; }

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        public IList<CapabilitiesEnum> Capabilities { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        public long EndAdvertiser { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        public long MediaAgency { get; private set; }

        /// <summary>
        /// <para>Indicates whether the offsite pixel Terms Of Service contract was signed</para>
        /// </summary>
        public bool OffsitePixelsTosAccepted { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        public long Partner { get; private set; }

        /// <summary>
        /// <para>IDs of Terms of Service contracts signed</para>
        /// </summary>
        public IList<long> TosAccepted { get; private set; }

        /// <summary>
        /// <para>Container for the user ID, permissions, and role</para>
        /// </summary>
        public IList<User> Users { get; private set; }

        /// <summary>
        /// <para>Vat status code for the account. </para>
        /// </summary>
        public TaxStatusEnum TaxStatus { get; private set; } 
        #endregion
    }
}
