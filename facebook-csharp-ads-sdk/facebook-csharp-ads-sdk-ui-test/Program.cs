using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

namespace facebook_csharp_ads_sdk_ui_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IFacebookSession facebookSession = new FacebookSessionRepository();
            facebookSession.SetAccessToken("a");


            
        }
    }
}