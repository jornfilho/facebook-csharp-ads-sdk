using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    /// <summary>
    /// Implement Facebook AdAccount interface methods
    /// </summary>
    public class AdAccountRespository : IAdAccount
    {
        #region Properties
        private readonly IFacebookSession _facebookSession; 
        #endregion

        #region Constructor
        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public AdAccountRespository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            _facebookSession = facebookSession;
        } 
        #endregion

        public async Task<AdAccount> Read(long accountId, IList<AdAccountFieldsEnum> fields)
        {
            _facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });

            if (fields == null)
                fields = AdAccountFieldsExtensions.GetAllAdAccountFieldsList();

            if(!fields.Any())
                fields = AdAccountFieldsExtensions.GetAllAdAccountFieldsList();

            var fieldNames = fields.GetAdAccountFieldsName();
            
            var getEndpoint = _facebookSession.GetFacebookAdsApiConfiguration().AdAccountEndpoint;
            getEndpoint = string.Format(getEndpoint, accountId, _facebookSession.GetUserAccessToken(), fieldNames);

            IRequest webRequest = new Request();
            var getRequest = await webRequest.GetAsync(getEndpoint);
            



            throw new NotImplementedException();
        }
    }

    
}
