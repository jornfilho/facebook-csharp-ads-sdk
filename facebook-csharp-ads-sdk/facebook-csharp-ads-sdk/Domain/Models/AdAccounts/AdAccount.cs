using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Newtonsoft.Json.Linq;

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
        public AdAccount SetAdAccountBusinessInformations(BusinessInformations businessInformations)
        {
            if (businessInformations == null || !businessInformations.IsValidData())
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
            if (timezoneInformations == null || !timezoneInformations.IsValidData())
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
            if (financialInformations == null || !financialInformations.IsValidData())
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
            if (agencyClientDeclaration == null || !agencyClientDeclaration.IsValidData())
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

            if (!accountGroup.IsValidData())
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

            if (!user.IsValidData())
                return this;

            if (Users == null)
                Users = new List<User>();

            Users.Add(user);

            SetValid();

            return this;
        }

        #region Parser
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringData"></param>
        /// <param name="adAccountFields"></param>
        /// <returns></returns>
        public AdAccount ParseSingleResult(string stringData, IList<AdAccountFieldsEnum> adAccountFields)
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

            if (adAccountFields == null)
                adAccountFields = AdAccountFieldsExtensions.GetDefaultsAdAccountFieldsList();

            var adAccountData = jsonResult;

            var fieldsCount = adAccountFields.Count;
            for (var index = 0; index < fieldsCount; index++)
            {
                var currentField = adAccountFields[index];

                if (currentField.IsAdAccountFieldPrimitive())
                    continue;

                switch (currentField)
                {
                    case AdAccountFieldsEnum.AccountGroups:
                        #region Parse Ad Account Groups
                        if (adAccountData["account_groups"] == null || adAccountData["account_groups"].Type != JTokenType.Array)
                            break;

                        var groupsCount = adAccountData["account_groups"].Count();
                        if (groupsCount < 0)
                            break;

                        for (var groupIndex = 0; groupIndex < groupsCount; groupIndex++)
                        {
                            var currentGroup = adAccountData["account_groups"][groupIndex];
                            if (currentGroup == null || currentGroup.Type != JTokenType.Object)
                                continue;

                            var groupData = new AdAccountGroup().ParseApiResponse(currentGroup);
                            if (!groupData.IsValidData())
                                continue;

                            this.SetAdAccountGroup(groupData);
                        }

                        break;
                        #endregion

                    case AdAccountFieldsEnum.AgencyClientDeclaration:
                        #region Parse Agency Client Declaration
                        if (adAccountData["agency_client_declaration"] == null || adAccountData["agency_client_declaration"].Type != JTokenType.Object)
                            break;

                        var agency = new AgencyClientDeclaration().ParseApiResponse(adAccountData["agency_client_declaration"]);
                        if (!agency.IsValidData())
                            continue;

                        this.SetAdAccountAgencyDeclaration(agency);

                        break;
                        #endregion

                    case AdAccountFieldsEnum.Users:
                        #region Parse Users
                        if (adAccountData["users"] == null || adAccountData["users"].Type != JTokenType.Array)
                            break;

                        var usersCount = adAccountData["users"].Count();
                        if (usersCount < 0)
                            break;

                        for (var userIndex = 0; userIndex < usersCount; userIndex++)
                        {
                            var currentUser = adAccountData["users"][userIndex];
                            if (currentUser == null || currentUser.Type != JTokenType.Object)
                                continue;

                            var userData = new User().ParseApiResponse(currentUser);
                            if (!userData.IsValidData())
                                continue;

                            this.SetAdAccountUser(userData);
                        }

                        break;
                        #endregion
                }
            }

            var businesInformations = new BusinessInformations().ParseApiResponse(adAccountData);
            if (businesInformations != null && businesInformations.IsValidData())
                this.SetAdAccountBusinessInformations(businesInformations);

            var timezoneInformations = new TimezoneInformations().ParseApiResponse(adAccountData);
            if (timezoneInformations != null && timezoneInformations.IsValidData())
                this.SetAdAccountTimezoneInformations(timezoneInformations);

            var financialInformations = new FinancialInformations().ParseApiResponse(adAccountData);
            if (financialInformations != null && financialInformations.IsValidData())
                this.SetAdAccountFinancialInformations(financialInformations);

            this.ParseBasicDataResponse(adAccountData);

            return this;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        private void ParseBasicDataResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return;

            string id = null, name = null;
            long accountId = 0;
            long? endAdvertiser = null, mediaAgency = null, partner = null;
            float? age = null;
            bool? isPersonal = null, offsitePixelsTosAccepted = null;
            AdAccountStatusEnum? accountStatus = AdAccountStatusEnum.Undefined;
            TaxStatusEnum? taxStatus = null;
            IList<CapabilitiesEnum> capabilities = null;
            IList<long> tosAccepted = null;

            if (jsonResult["id"] != null && jsonResult["id"].Type == JTokenType.String)
                id = jsonResult["id"].ToString();

            if (jsonResult["account_id"] != null && jsonResult["account_id"].Type == JTokenType.Integer)
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

            if (jsonResult["end_advertiser"] != null && jsonResult["end_advertiser"].Type == JTokenType.Integer)
                endAdvertiser = jsonResult["end_advertiser"].ToString().TryParseLong();

            if (jsonResult["media_agency"] != null && jsonResult["media_agency"].Type == JTokenType.Integer)
                mediaAgency = jsonResult["media_agency"].ToString().TryParseLong();

            if (jsonResult["offsite_pixels_tos_accepted"] != null && jsonResult["offsite_pixels_tos_accepted"].Type == JTokenType.Boolean)
                offsitePixelsTosAccepted = jsonResult["offsite_pixels_tos_accepted"].ToString().TryParseBool();

            if (jsonResult["partner"] != null && jsonResult["partner"].Type == JTokenType.Integer)
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
        #endregion
    }
}
