using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdAccountRespository : IAdAccount
    {
        private IFacebookSession FacebookSession { get; set; }

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public AdAccountRespository(IFacebookSession facebookSession)
        {
            if(facebookSession == null)
                throw new ArgumentNullException();

            FacebookSession = facebookSession;
        }

        public async Task<AdAccount> Read(long accountId, IList<AdAccountFieldsEnum> fields)
        {
            FacebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });

            IRequest webRequest = new Request();
            



            throw new NotImplementedException();
        }
    }

    
}
