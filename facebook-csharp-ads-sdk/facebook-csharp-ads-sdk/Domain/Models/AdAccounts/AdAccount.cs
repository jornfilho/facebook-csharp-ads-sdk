using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using Newtonsoft.Json;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/adaccount#read
    /// </summary>
    public class AdAccount : ValidData
    {
        #region Properties
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
        public AdAccountStatusEnum? AccountStatus { get; private set; }

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        public float? Age { get; private set; }

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        [JsonProperty("is_personal")]
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
        /// Set base account data
        /// </summary>
        /// <exception cref="InvalidAdAccountId">id or accountId has an invalid value</exception>
        /// <exception cref="InvalidEnumArgumentException">accountStatus, capabilities or taxStatus has an invalid value</exception>
        /// <exception cref="ArgumentOutOfRangeException">age, endAdvertiser, mediaAgency, partner or tosAccepted has an invalid value</exception>
        public AdAccount SetAdAccountBaseData(string id, long accountId, string name, AdAccountStatusEnum? accountStatus, float? age, 
            bool? isPersonal, IList<CapabilitiesEnum> capabilities, long? endAdvertiser, long? mediaAgency, 
            bool? offsitePixelsTosAccepted, long? partner, IList<long> tosAccepted, TaxStatusEnum? taxStatus)
        {
            if (!accountId.IsValidAdAccountId())
                throw new InvalidAdAccountId();

            if (!id.IsValidAdAccountId(accountId))
                throw new InvalidAdAccountId();

            if(accountStatus != null && accountStatus.Value == AdAccountStatusEnum.Undefined)
                throw new InvalidEnumArgumentException();

            if (age != null && age.Value < 0)
                throw new ArgumentOutOfRangeException();

            if(capabilities != null && capabilities.Any(c=> c == CapabilitiesEnum.Undefined))
                throw new InvalidEnumArgumentException();

            if (endAdvertiser != null && endAdvertiser.Value < 0)
                throw new ArgumentOutOfRangeException();

            if (mediaAgency != null && mediaAgency.Value < 0)
                throw new ArgumentOutOfRangeException();

            if (partner != null && partner.Value < 0)
                throw new ArgumentOutOfRangeException();

            if (tosAccepted != null && tosAccepted.Any(t=> t < 0))
                throw new ArgumentOutOfRangeException();

            if(taxStatus != null && taxStatus.Value == TaxStatusEnum.Undefined)
                throw new InvalidEnumArgumentException();

            Id = id;
            AccountId = accountId;
            
            if(!String.IsNullOrEmpty(name))
                Name = name;

            AccountStatus = accountStatus;
            Age = age;
            IsPersonal = isPersonal;
            Capabilities = capabilities;
            EndAdvertiser = endAdvertiser;
            MediaAgency = mediaAgency;
            OffsitePixelsTosAccepted = offsitePixelsTosAccepted;
            Partner = partner;
            TosAccepted = tosAccepted;
            TaxStatus = taxStatus;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set business informations
        /// </summary>
        /// <exception cref="ArgumentNullException">businessInformations is null</exception>
        /// <exception cref="ArgumentException">businessInformations has invalid data</exception>
        public AdAccount SetAdAccountBusinessInformations(BusinessInformations businessInformations)
        {
            if (businessInformations == null)
                throw new ArgumentNullException();

            if (!businessInformations.IsValidData())
                throw new ArgumentException();

            BusinessInformations = businessInformations;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set timezone informations
        /// </summary>
        /// <exception cref="ArgumentNullException">timezoneInformations is null</exception>
        /// <exception cref="ArgumentException">timezoneInformations has invalid data</exception>
        public AdAccount SetAdAccountTimezoneInformations(TimezoneInformations timezoneInformations)
        {
            if (timezoneInformations == null)
                throw new ArgumentNullException();

            if (!timezoneInformations.IsValidData())
                throw new ArgumentException();

            TimezoneInformations = timezoneInformations;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial informations
        /// </summary>
        /// <exception cref="ArgumentNullException">financialInformations is null</exception>
        /// <exception cref="ArgumentException">financialInformations has invalid data</exception>
        public AdAccount SetAdAccountFinancialInformations(FinancialInformations financialInformations)
        {
            if (financialInformations == null)
                throw new ArgumentNullException();

            if (!financialInformations.IsValidData())
                throw new ArgumentException();

            FinancialInformations = financialInformations;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set agency client declaration
        /// </summary>
        /// <exception cref="ArgumentNullException">agencyClientDeclaration is null</exception>
        /// <exception cref="ArgumentException">agencyClientDeclaration has invalid data</exception>
        public AdAccount SetAdAccountAgencyDeclaration(AgencyClientDeclaration agencyClientDeclaration)
        {
            if (agencyClientDeclaration == null)
                throw new ArgumentNullException();

            if (!agencyClientDeclaration.IsValidData())
                throw new ArgumentException();

            AgencyClientDeclaration = agencyClientDeclaration;

            SetValid();

            return this;
        }

        /// <summary>
        /// Add ad account group
        /// </summary>
        /// <exception cref="ArgumentNullException">accountGroup is null</exception>
        /// <exception cref="ArgumentException">accountGroup has invalid data</exception>
        public AdAccount SetAdAccountGroup(AdAccountGroup accountGroup)
        {
            if (accountGroup == null)
                throw new ArgumentNullException();

            if (!accountGroup.IsValidData())
                throw new ArgumentException();


            if (AccountGroups == null)
                AccountGroups = new List<AdAccountGroup>();

            AccountGroups.Add(accountGroup);

            SetValid();

            return this;
        }

        /// <summary>
        /// Add user model
        /// </summary>
        /// <exception cref="ArgumentNullException">user is null</exception>
        /// <exception cref="ArgumentException">user has invalid data</exception>
        public AdAccount SetAdAccountUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if(!user.IsValidData())
                throw new ArgumentException();

            if (Users == null)
                Users = new List<User>();

            Users.Add(user);

            SetValid();

            return this;
        }
    }
}
