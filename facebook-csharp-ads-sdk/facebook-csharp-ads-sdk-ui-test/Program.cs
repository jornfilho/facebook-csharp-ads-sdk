using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

namespace facebook_csharp_ads_sdk_ui_test
{
    public class Program //: PersonalData.PersonalData
    {
        static void Main(string[] args)
        {
            //IFacebookSession facebookSession = new FacebookSessionRepository()
            //    .SetUserAccessToken(UserToken);

            //var api = new facebook_csharp_ads_sdk.Api.Api(facebookSession);

            //var adAccount = api.AdAccount().Read(AccountId, new List<AdAccountFieldsEnum>()).Result;

            string token =
                "CAADMSrKzEFUBAIpm5GqBA4fNNXNYdTZBqJtKxks0QSBt3k3ZBUsPLQhZB7DFvVKLZA4mZCjOTzIsJ7wx4rCZBs6ZAWrbn6GrqmMeTJZC24C46fYG764KzHAyqBQoc7PSW4SUgKFOdm8h8pdvhBwN3FLyLuqfxQhtfMndeWPl4JEOw2ZBZC426GfQuV22KPGPQJsaAL3m1i8yDH2fhVS3UAIHXe";

            IFacebookSession facebookSession = new FacebookSessionRepository().SetUserAccessToken(token);
            IAccountRepository accountRepository = new AdAccountRespository(facebookSession);

            var account = new AdAccount(accountRepository).Read(100690260075287);


        }
    }
}