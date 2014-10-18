using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

namespace facebook_csharp_ads_sdk_ui.test
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