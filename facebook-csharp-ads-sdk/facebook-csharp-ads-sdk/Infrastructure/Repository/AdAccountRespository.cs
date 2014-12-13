using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
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
    public class AdAccountRespository : IAccountRepository
    {
        #region Properties
        
        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
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

            this._facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        ///     Read a account by id
        /// </summary>
        /// <param name="id"> Id of the account </param>
        /// <returns> Account with id and accountId fields </returns>
        public async Task<AdAccount> Read(long id)
        {
            IList<AdAccountFieldsEnum> fields = AdAccountFieldsExtensions.GetDefaultsAdAccountFieldsList();
            var accountResult = await this.Read(id, fields);
            return accountResult;
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Read a account by id and fields
        /// </summary>
        /// <param name="id"> Id of the account </param>
        /// <param name="fields"> List of fields </param>
        /// <returns> Account has passed fields, or null if there are problems </returns>
        public async Task<AdAccount> Read(long id, IList<AdAccountFieldsEnum> fields)
        {
            this._facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
                fields = AdAccountFieldsExtensions.GetDefaultsAdAccountFieldsList();

            string fieldNames = fields.GetAdAccountFieldsName();
            string accountEndpoint = this._facebookSession.GetFacebookAdsApiConfiguration().AdAccountEndpoint;
            accountEndpoint = string.Format(accountEndpoint, id, this._facebookSession.GetUserAccessToken(), fieldNames);

            IRequest webRequest = new Request();
            var getRequest = await webRequest.GetAsync(accountEndpoint);
            var account = new AdAccount(this);
            account.ParseReadSingleesponse(getRequest);
            return account;
        }
    }
}
