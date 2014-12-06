using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
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
                "token";

            IFacebookSession facebookSession = new FacebookSessionRepository().SetUserAccessToken(token);
            IAccountRepository accountRepository = new AdAccountRespository(facebookSession);

            var account = new AdAccount(accountRepository).ReadSingle(100690260075287);


            

            ICampaignRepository campaignRepository = new CampaignRepository(facebookSession);

            var campaign = new AdCampaign(campaignRepository).ReadSingle(6015077391188);

        }
    }
}