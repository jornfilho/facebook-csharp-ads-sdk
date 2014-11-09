using System.Collections.Generic;
using System.IO;
using System.Net;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Michel_Test.Domain;
using facebook_csharp_ads_sdk.Michel_Test.Interface.Repository;

namespace facebook_csharp_ads_sdk.Michel_Test.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IFacebookSession facebookSession;

        public AccountRepository(IFacebookSession facebookSession)
        {
            this.facebookSession = facebookSession;
        }

        public AdAccount Read(long accountId)
        {
            IList<AdAccountFieldsEnum> fields = new List<AdAccountFieldsEnum>();
            fields.Add(AdAccountFieldsEnum.Id);
            fields.Add(AdAccountFieldsEnum.AccountId);

            facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            var fieldNames = fields.GetAdAccountFieldsName();

            var endpoint = facebookSession.GetFacebookAdsApiConfiguration().AdAccountEndpoint;
            endpoint = string.Format(endpoint, accountId, facebookSession.GetUserAccessToken(), fieldNames);

            var getRequest = WebRequest.Create(endpoint);
            getRequest.Timeout = 10000;
            var objStream = getRequest.GetResponse().GetResponseStream();
            
            string result = string.Empty;
            if (objStream != null)
            {
                var objReader = new StreamReader(objStream);
                result = objReader.ReadToEnd();
            }
            
            return new AdAccount().ParseFacebookResponse(result);
        }
    }
}
