using System;
using System.Collections.Generic;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Michel_Test.Interface.Repository;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Michel_Test.Domain
{
    /// <summary>
    ///     Facebook Ad Account
    /// </summary>
    public class AdAccount : BaseObject<AdAccount>
    {
        #region Dependencies
        
        /// <summary>
        ///     Interface of ad account repository
        /// </summary>
        private readonly IAccountRepository accountRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="accountRepository"> Interface of ad account repository </param>
        public AdAccount(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public AdAccount()
        {
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// <para>The string act_{ad_account_id}</para>
        /// </summary>
        [FacebookName("id")]
        public string Id { get; private set; }

        /// <summary>
        /// <para>The ID of the ad account</para> 
        /// </summary>
        [FacebookName("account_id")]
        public long AccountId { get; private set; }

        /// <summary>
        /// <para>Name of the account; note that many accounts are unnamed, so this field may be empty</para>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// <para>Status of the account.</para>
        /// </summary>
        public AdAccountStatusEnum? AccountStatus { get; private set; }

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        public float? Age { get; private set; }

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        public bool? IsPersonal { get; private set; }

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
        public long? EndAdvertiser { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        public long? MediaAgency { get; private set; }

        /// <summary>
        /// <para>Indicates whether the offsite pixel Terms Of Service contract was signed</para>
        /// </summary>
        public bool? OffsitePixelsTosAccepted { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        public long? Partner { get; private set; }

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
        public TaxStatusEnum? TaxStatus { get; private set; }

        #endregion

        /// <summary>
        ///     Read a ad account by id
        /// </summary>
        /// <param name="accountId"> Account id </param>
        /// <returns> New object of adAccount </returns>
        public override AdAccount Read(long accountId)
        {
            return this.accountRepository.Read(accountId);
        }

        public override AdAccount ParseFacebookResponse(string response)
        {
            JObject facebookResponse = JObject.Parse(response);

            string facebookNameId = ((FacebookNameAttribute) Attribute.GetCustomAttribute(this.GetType().GetProperty("Id"), typeof (FacebookNameAttribute))).Value;
            if (facebookResponse[facebookNameId] != null)
            {
                this.Id = facebookResponse[facebookNameId].ToString();
            }

            string facebookAccountNameId = ((FacebookNameAttribute)Attribute.GetCustomAttribute(this.GetType().GetProperty("AccountId"), typeof(FacebookNameAttribute))).Value;
            if (facebookResponse[facebookAccountNameId] != null)
            {
                this.AccountId = facebookResponse[facebookAccountNameId].ToString().TryParseLong();
            }

            return this;
        }
    }
}
