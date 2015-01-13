using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;
using facebook_csharp_ads_sdk.Domain.Contracts.AdStatistics;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/adaccount#read
    /// </summary>
    public class AdAccount : BaseCrudObject<AdAccount>, IAdStatisticsQueryable
    {
        #region Dependencies

        /// <summary>
        ///     Repository of the account interface
        /// </summary>
        private readonly IAccountRepository _repository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="repository"> Implementation of the account interface repository </param>
        public AdAccount(IAccountRepository repository)
        {
            this._repository = repository;
        }

        #endregion Constructor

        #region Properties
        /// <summary>
        /// <para>The string act_{ad_account_id}</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("id")]
        public string Id { get; private set; }

        /// <summary>
        /// <para>The ID of the ad account</para> 
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("account_id")]
        public long AccountId { get; private set; }

        /// <summary>
        /// <para>Name of the account; note that many accounts are unnamed, so this field may be empty</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// <para>Status of the account.</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("account_status")]
        public AdAccountStatusEnum? AccountStatus { get; private set; }

        /// <summary>
        /// <para>Amount of time the ad account has been open, in days</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("age")]
        public float? Age { get; private set; }

        /// <summary>
        /// <para>If this is a personal or business account</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("is_personal")]
        public bool? IsPersonal { get; private set; }

        /// <summary>
        /// Business account information
        /// </summary>
        [DefaultValue(null)]
        public BusinessInformations BusinessInformations { get; private set; }

        /// <summary>
        /// Account timezone informations
        /// </summary>
        [DefaultValue(null)]
        public TimezoneInformations TimezoneInformations { get; private set; }
        
        /// <summary>
        /// <para>Container for the ID, name, and status of the account's account groups</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("account_groups")]
        public IList<AdAccountGroup> AccountGroups { get; private set; }

        /// <summary>
        /// Financial account informations
        /// </summary>
        [DefaultValue(null)]
        public FinancialInformations FinancialInformations { get; private set; }

        /// <summary>
        /// <para>Details of the agency advertising on behalf of this client account, if applicable.</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("agency_client_declaration")]
        public AgencyClientDeclaration AgencyClientDeclaration { get; private set; }

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("capabilities")]
        public IList<CapabilitiesEnum> Capabilities { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("end_advertiser")]
        public long? EndAdvertiser { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("media_agency")]
        public long? MediaAgency { get; private set; }

        /// <summary>
        /// <para>Indicates whether the offsite pixel Terms Of Service contract was signed</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("offsite_pixels_tos_accepted")]
        public bool? OffsitePixelsTosAccepted { get; private set; }

        /// <summary>
        /// <para>The ID of a Facebook Page or Facebook App</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("partner")]
        public long? Partner { get; private set; }

        /// <summary>
        /// <para>IDs of Terms of Service contracts signed</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("tos_accepted")]
        public IList<long> TosAccepted { get; private set; }

        /// <summary>
        /// <para>Container for the user ID, permissions, and role</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("users")]
        public IList<User> Users { get; private set; }

        /// <summary>
        /// <para>Vat status code for the account. </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("tax_id_status")]
        public TaxStatusEnum? TaxStatus { get; private set; } 
        #endregion

        /// <summary>
        /// Set base account data
        /// </summary>
        public AdAccount SetAdAccountBaseData(string id, long accountId, string name, AdAccountStatusEnum? accountStatus, float? age, 
            bool? isPersonal, IList<CapabilitiesEnum> capabilities, long? endAdvertiser, long? mediaAgency, 
            bool? offsitePixelsTosAccepted, long? partner, IList<long> tosAccepted, TaxStatusEnum? taxStatus)
        {
            if (!accountId.IsValidAdAccountId())
                return this;

            if (!id.IsValidAdAccountId(accountId))
                return this;

            if (accountStatus != null && accountStatus.Value.Equals(AdAccountStatusEnum.Undefined))
                return this;

            if (age != null && age.Value <= 0)
                return this;

            if (capabilities != null && capabilities.Any(c => c.Equals(CapabilitiesEnum.Undefined)))
                return this;

            if (endAdvertiser != null && endAdvertiser.Value <= 0)
                return this;

            if (mediaAgency != null && mediaAgency.Value <= 0)
                return this;

            if (partner != null && partner.Value <= 0)
                return this;

            if (tosAccepted != null && tosAccepted.Any(t=> t <= 0))
                return this;

            if (taxStatus != null && taxStatus.Value.Equals(TaxStatusEnum.Undefined))
                return this;

            this.Id = id;
            this.AccountId = accountId;
            this.Name = name;
            this.AccountStatus = accountStatus;
            this.Age = age;
            this.IsPersonal = isPersonal;
            this.Capabilities = capabilities;
            this.EndAdvertiser = endAdvertiser;
            this.MediaAgency = mediaAgency;
            this.OffsitePixelsTosAccepted = offsitePixelsTosAccepted;
            this.Partner = partner;
            this.TosAccepted = tosAccepted;
            this.TaxStatus = taxStatus;

            this.SetValid();
            return this;
        }

        /// <summary>
        /// Set business informations
        /// </summary>
        public AdAccount SetAdAccountBusinessInformations(BusinessInformations businessInformations)
        {
            if (businessInformations == null || !businessInformations.IsValid)
            {
                BusinessInformations = null;
                return this;
            }

            BusinessInformations = businessInformations;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set timezone informations
        /// </summary>
        public AdAccount SetAdAccountTimezoneInformations(TimezoneInformations timezoneInformations)
        {
            if (timezoneInformations == null || !timezoneInformations.IsValid)
            {
                TimezoneInformations = null;
                return this;
            }

            TimezoneInformations = timezoneInformations;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial informations
        /// </summary>
        public AdAccount SetAdAccountFinancialInformations(FinancialInformations financialInformations)
        {
            if (financialInformations == null || !financialInformations.IsValid)
            {
                FinancialInformations = null;
                return this;
            }

            FinancialInformations = financialInformations;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set agency client declaration
        /// </summary>
        public AdAccount SetAdAccountAgencyDeclaration(AgencyClientDeclaration agencyClientDeclaration)
        {
            if (agencyClientDeclaration == null || !agencyClientDeclaration.IsValid)
            {
                AgencyClientDeclaration = null;
                return this;
            }

            AgencyClientDeclaration = agencyClientDeclaration;
            SetValid();

            return this;
        }

        /// <summary>
        /// Add ad account group
        /// </summary>
        public AdAccount SetAdAccountGroup(AdAccountGroup accountGroup)
        {
            if (accountGroup == null)
            {
                AccountGroups = null;
                return this;
            }

            if (!accountGroup.IsValid)
                return this;

            if (AccountGroups == null)
                AccountGroups = new List<AdAccountGroup>();

            AccountGroups.Add(accountGroup);
            SetValid();

            return this;
        }

        /// <summary>
        /// Add user model
        /// </summary>
        public AdAccount SetAdAccountUser(User user)
        {
            if (user == null)
            {
                Users = null;
                return this;
            }

            if (!user.IsValid)
                return this;

            if (Users == null)
                Users = new List<User>();

            Users.Add(user);

            SetValid();

            return this;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public AdAccount ParseSingleResult(string stringData)
        {
            #region Test result and parse json

            if (String.IsNullOrEmpty(stringData))
                return null;

            var jsonResult = JObject.Parse(stringData);
            if (jsonResult == null)
                return null;
            #endregion

            #region Api error
            if (jsonResult["error"] != null)
            {
                var errorModel = new ApiErrorModelV22().ParseApiResponse(jsonResult);
                this.SetInvalid();
                this.SetApiErrorResonse(errorModel);

                return this;
            }
            this.SetApiErrorResonse(null);
            #endregion

            var adAccountData = jsonResult;

            #region Parse Ad Account Groups
            if (adAccountData["account_groups"] != null &&
                    adAccountData["account_groups"].Type == JTokenType.Array &&
                    adAccountData["account_groups"].Any())
            {
                var groupsCount = adAccountData["account_groups"].Count();
                for (var groupIndex = 0; groupIndex < groupsCount; groupIndex++)
                {
                    var currentGroup = adAccountData["account_groups"][groupIndex];
                    if (currentGroup == null || currentGroup.Type != JTokenType.Object)
                        continue;

                    var groupData = new AdAccountGroup();
                    groupData.ParseReadSingleResponse(currentGroup);

                    if (!groupData.IsValid)
                        continue;

                    this.SetAdAccountGroup(groupData);
                }
            } 
            #endregion

            #region Parse Agency Client Declaration
            if (adAccountData["agency_client_declaration"] != null &&
                    adAccountData["agency_client_declaration"].Type == JTokenType.Object)
            {
                var agency = new AgencyClientDeclaration().ParseApiResponse(adAccountData["agency_client_declaration"]);
                if (agency.IsValid)
                    this.SetAdAccountAgencyDeclaration(agency);
            } 
            #endregion

            #region Parse Users
            if (adAccountData["users"] != null &&
                    adAccountData["users"].Type != JTokenType.Array &&
                    adAccountData["users"].Any())
            {
                var usersCount = adAccountData["users"].Count();
                for (var userIndex = 0; userIndex < usersCount; userIndex++)
                {
                    var currentUser = adAccountData["users"][userIndex];
                    if (currentUser == null || currentUser.Type != JTokenType.Object)
                        continue;

                    var userData = new User().ParseApiResponse(currentUser);
                    if (!userData.IsValid)
                        continue;

                    this.SetAdAccountUser(userData);
                }
            } 
            #endregion

            var businesInformations = new BusinessInformations().ParseApiResponse(adAccountData);
            if (businesInformations != null && businesInformations.IsValid)
                this.SetAdAccountBusinessInformations(businesInformations);

            var timezoneInformations = new TimezoneInformations().ParseApiResponse(adAccountData);
            if (timezoneInformations != null && timezoneInformations.IsValid)
                this.SetAdAccountTimezoneInformations(timezoneInformations);

            var financialInformations = new FinancialInformations().ParseApiResponse(adAccountData);
            if (financialInformations != null && financialInformations.IsValid)
                this.SetAdAccountFinancialInformations(financialInformations);

            this.ParseBasicDataResponse(adAccountData);
            return this;
        }
        
        /// <summary>
        ///     Read a account by id and fields
        /// </summary>
        /// <param name="id"> Id of the account </param>
        /// <param name="fields"> List of fields </param>
        /// <returns> Account has passed fields, or null if there are problems </returns>
        public AdAccount Read(long id, IList<AdAccountFieldsEnum> fields)
        {
            try
            {
                if (!id.IsValidAdAccountId())
                {
                    return this;
                }

                return this._repository.Read(id, fields).Result;
            }
            catch (Exception)
            {
                return this;
            }
        }

        public override AdAccount Create()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetSingleCreateParams()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Read a account by id
        /// </summary>
        /// <param name="id"> Id of the account </param>
        /// <returns> Account with id and accountId fields </returns>
        public override AdAccount ReadSingle(long id)
        {
            try
            {
                return !id.IsValidAdAccountId() ? this : this._repository.Read(id).Result;
            }
            catch (Exception)
            {
                return this;
            }
        }

        public override AdAccount Update()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetSingleUpdateParams()
        {
            throw new NotImplementedException();
        }

        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        /////     Parse Facebook response to Model
        ///// </summary>
        ///// <param name="response"> Facebook response </param>
        ///// <returns> Instance with fields from Facebook response </returns>
        //public override AdAccount ParseReadSingleesponse(string response)
        //{
        //    var jsonResult = JObject.Parse(response);
        //    this.ParseBasicDataResponse(jsonResult);
        //    return this;
        //}

        #region Private methods

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        private void ParseBasicDataResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return;

            string id = null;
            string name = null;
            long accountId = 0;
            long? endAdvertiser = null;
            long? mediaAgency = null;
            long? partner = null;
            float? age = null;
            bool? isPersonal = null;
            bool? offsitePixelsTosAccepted = null;
            AdAccountStatusEnum? accountStatus = null;
            TaxStatusEnum? taxStatus = null;
            IList<CapabilitiesEnum> capabilities = null;
            IList<long> tosAccepted = null;

            if (jsonResult["id"] != null && jsonResult["id"].Type == JTokenType.String)
                id = jsonResult["id"].ToString();

            if (jsonResult["account_id"] != null && (jsonResult["account_id"].Type == JTokenType.Integer || jsonResult["account_id"].Type == JTokenType.String))
                accountId = jsonResult["account_id"].ToString().TryParseLong();

            if (jsonResult["name"] != null && jsonResult["name"].Type == JTokenType.String)
                name = jsonResult["name"].ToString();

            if (jsonResult["account_status"] != null && jsonResult["account_status"].Type == JTokenType.Integer)
                accountStatus = jsonResult["account_status"].ToString().TryParseInt().GetAdAccountStatusEnum();

            if (jsonResult["age"] != null && jsonResult["age"].Type == JTokenType.Float)
                age = jsonResult["age"].ToString().TryParseFloat();

            if (jsonResult["is_personal"] != null && jsonResult["is_personal"].Type == JTokenType.Integer)
                isPersonal = jsonResult["is_personal"].ToString().TryParseInt() == 1;

            if (jsonResult["capabilities"] != null &&
                jsonResult["capabilities"].Type == JTokenType.Array &&
                jsonResult["capabilities"].Any())
            {
                var capabilitiesCount = jsonResult["capabilities"].Count();
                for (var capabilitiesIndex = 0; capabilitiesIndex < capabilitiesCount; capabilitiesIndex++)
                {
                    if (jsonResult["capabilities"][capabilitiesIndex] == null)
                        continue;

                    var currentCapabilities = jsonResult["capabilities"][capabilitiesIndex]
                        .ToString()
                        .GetCapabilitiesEnum();

                    if (currentCapabilities == CapabilitiesEnum.Undefined)
                        continue;

                    if (capabilities == null)
                        capabilities = new List<CapabilitiesEnum>();

                    capabilities.Add(currentCapabilities);
                }
            }

            if (jsonResult["end_advertiser"] != null && (jsonResult["end_advertiser"].Type == JTokenType.Integer || jsonResult["end_advertiser"].Type == JTokenType.String))
                endAdvertiser = jsonResult["end_advertiser"].ToString().TryParseLong();

            if (jsonResult["media_agency"] != null && (jsonResult["media_agency"].Type == JTokenType.Integer || jsonResult["media_agency"].Type == JTokenType.String))
                mediaAgency = jsonResult["media_agency"].ToString().TryParseLong();

            if (jsonResult["offsite_pixels_tos_accepted"] != null && jsonResult["offsite_pixels_tos_accepted"].Type == JTokenType.Boolean)
                offsitePixelsTosAccepted = jsonResult["offsite_pixels_tos_accepted"].ToString().TryParseBool();

            if (jsonResult["partner"] != null && (jsonResult["partner"].Type == JTokenType.Integer || jsonResult["partner"].Type == JTokenType.String))
                partner = jsonResult["partner"].ToString().TryParseLong();

            if (jsonResult["tos_accepted"] != null &&
                jsonResult["tos_accepted"].Type == JTokenType.Object)
            {
                var tosObject = jsonResult["tos_accepted"].Value<JObject>();
                tosAccepted = tosObject.Properties()
                    .Where(
                        p =>
                            p.Value != null && !String.IsNullOrEmpty(p.Value.ToString()) &&
                            p.Value.ToString().TryParseInt() == 1)
                    .Where(
                        p =>
                            p.Name != null && !String.IsNullOrEmpty(p.Name.ToString(CultureInfo.InvariantCulture)) &&
                            p.Name.ToString(CultureInfo.InvariantCulture).TryParseLong() > 0)
                    .Select(p => p.Name.ToString(CultureInfo.InvariantCulture).TryParseLong())
                    .ToList();
            }

            if (jsonResult["tax_id_status"] != null && jsonResult["tax_id_status"].Type == JTokenType.Integer)
                taxStatus = jsonResult["tax_id_status"].ToString().TryParseInt().GetTaxStatusEnum();

            this.SetAdAccountBaseData(id, accountId, name, accountStatus, age, isPersonal, capabilities, endAdvertiser,
                mediaAgency, offsitePixelsTosAccepted, partner, tosAccepted, taxStatus);
        }

        #endregion Private methods
    }
}
