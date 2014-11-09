using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk.Infrastructure.Parsers.ApiErrors;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Infrastructure.Parsers.AdAccounts
{
    public static class AdAccountData
    {
        public static AdAccount SingleAdAccount(string stringData, IList<AdAccountFieldsEnum> adAccountFields)
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
                var result = new AdAccount();

                var errorModel = ErrorData.ParseV22(ref jsonResult);
                result.SetApiErrorResonse(errorModel);
                
                return result;
            } 
            #endregion

            if (adAccountFields == null)
                adAccountFields = AdAccountFieldsExtensions.GetDefaultsAdAccountFieldsList();

            var accountData = jsonResult["data"];
            
            return AdAccount(accountData, adAccountFields);
        }

        public static AdAccount AdAccount(JToken adAccountData, IList<AdAccountFieldsEnum> adAccountFields)
        {
            var result = new AdAccount();

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
                        var adAccountGroups = AccountGroups(adAccountData);
                        if (adAccountGroups == null || !adAccountGroups.Any())
                            break;

                        var groupCount = adAccountGroups.Count;
                        for (var groupIndex = 0; groupIndex < groupCount; groupIndex++)
                        {
                            var currentGroup = adAccountGroups[groupIndex];
                            if (!currentGroup.IsValidData())
                                continue;

                            result.SetAdAccountGroup(currentGroup);
                        }
                            

                        break; 
                        #endregion

                    case AdAccountFieldsEnum.AgencyClientDeclaration:
                        #region Parse Agency Client Declaration
                        var agency = AgencyClientDeclaration(adAccountData);
                        if (agency == null || !agency.IsValidData())
                            break;

                        result.SetAdAccountAgencyDeclaration(agency);
                        break; 
                        #endregion

                    case AdAccountFieldsEnum.Users:
                        #region Parse Users
                        if(adAccountData["users"] == null || adAccountData["users"].Type != JTokenType.Array)
                            break;

                        var usersCount = adAccountData["users"].Count();
                        if(usersCount < 0)
                            break;

                        for (var userIndex = 0; userIndex < usersCount; userIndex++)
                        {
                            var currentUser = adAccountData["users"][userIndex];
                            if (currentUser == null || currentUser.Type != JTokenType.Object)
                                continue;

                            var userData = new User().ParseApiResponse(currentUser);
                            if(!userData.IsValidData())
                                continue;

                            result.SetAdAccountUser(userData);
                        }
                        #endregion
                }
            }

            var businesInformations = new BusinessInformations().ParseApiResponse(adAccountData);
            if (businesInformations != null && businesInformations.IsValidData())
                result.SetAdAccountBusinessInformations(businesInformations);
            
            var timezoneInformations = new TimezoneInformations().ParseApiResponse(adAccountData);
            if (timezoneInformations != null && timezoneInformations.IsValidData())
                result.SetAdAccountTimezoneInformations(timezoneInformations);

            var financialInformations = new FinancialInformations().ParseApiResponse(adAccountData);
            if (financialInformations != null && financialInformations.IsValidData())
                result.SetAdAccountFinancialInformations(financialInformations);
            
            BasicData(adAccountData, ref result);
            
            return result;
        }

        private static IList<AdAccountGroup> AccountGroups(JToken jsonResult)
        {
            throw new NotImplementedException();
        }

        private static AdAccountGroup AccountGroup(JToken jsonResult)
        {
            throw new NotImplementedException();
        }

        private static AgencyClientDeclaration AgencyClientDeclaration(JToken jsonResult)
        {
            throw new NotImplementedException();
        }

        private static void BasicData(JToken jsonResult, ref AdAccount adAccount)
        {
            throw new NotImplementedException();
        }
        
    }
}