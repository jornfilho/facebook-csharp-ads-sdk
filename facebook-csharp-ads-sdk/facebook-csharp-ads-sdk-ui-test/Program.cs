using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

namespace facebook_csharp_ads_sdk_ui_test
{
    class Program : PersonalData
    {
        static void Main(string[] args)
        {

            IFacebookSession facebookSession = new FacebookSessionRepository()
                .SetUserAccessToken("a");

            var api = new facebook_csharp_ads_sdk.Api.Api(facebookSession);

            var adAccount = api.AdAccount().Read(1, new List<AdAccountFieldsEnum>()).Result;
        }
    }
}