using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdAccountRespository : IAdAccount
    {
        private IFacebookSession FacebookSession { get; set; }

        public AdAccountRespository(IFacebookSession facebookSession)
        {
            if(facebookSession == null)
                throw new ArgumentNullException();

            FacebookSession = facebookSession;
        }

        public async Task<AdAccount> Read(long accountId, IList<AdAccountFieldsEnum> fields)
        {
            throw new NotImplementedException();
        }
    }
}
