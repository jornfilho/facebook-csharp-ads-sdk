using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.FacebookConfig;
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

        /// <summary>
        /// Validate Facebook Session according received requirements
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidAccessToken"></exception>
        /// <exception cref="InvalidAppSecret"></exception>
        /// <exception cref="InvalidAppId"></exception>
        private void ValidateFacebookSession(ICollection<RequiredOnFacebookSessionEnum> requirements)
        {
            if (FacebookSession == null)
                throw new NullReferenceException();

            if(!requirements.Any())
                return;

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AccessToken) &&
                !FacebookSession.GetAccessToken().IsValidAccessToken())
                throw new InvalidAccessToken();

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AppSecret) &&
                !FacebookSession.GetAppSecret().IsValidAppSecret())
                throw new InvalidAppSecret();

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AppId) &&
                !FacebookSession.GetAppId().IsValidAppId())
                throw new InvalidAppId();
        }

        public async Task<AdAccount> Read(long accountId, IList<AdAccountFieldsEnum> fields)
        {
            ValidateFacebookSession(new[] { RequiredOnFacebookSessionEnum.AccessToken });

            IRequest webRequest = new Request();
            



            throw new NotImplementedException();
        }
    }

    
}
