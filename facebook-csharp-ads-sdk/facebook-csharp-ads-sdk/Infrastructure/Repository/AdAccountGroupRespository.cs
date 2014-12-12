using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup;
using facebook_csharp_ads_sdk._Utils.Parser;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    /// <summary>
    /// Implement Facebook AdAccount interface methods
    /// </summary>
    public class AdAccountGroupRespository : IAccountGroupRepository
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
        public AdAccountGroupRespository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            this._facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        /// Método para pegar os dados de um grupo de contas
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"></exception>
        public AdAccountGroup ReadSingle(long accountGroupId, IList<AdAccountGroupFieldsEnum> fields)
        {
            this._facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
                fields = AdAccountGroupFieldsEnumExtensions.GetDefaultsAdAccountGroupFieldsList();

            string fieldNames = string.Join(",", fields.GetFacebookNamesList());
            string accountEndpoint = this._facebookSession.GetFacebookAdsApiConfiguration().AdAccountGroupSingleEndpoint;
            accountEndpoint = string.Format(accountEndpoint, accountGroupId, this._facebookSession.GetUserAccessToken(), fieldNames);

            IRequest webRequest = new Request();
            var getRequest = webRequest.Get(accountEndpoint);
            var accountGroup = new AdAccountGroup();
            accountGroup.ParseReadSingleesponse(getRequest);
            return accountGroup;
        }

        /// <summary>
        /// Método para leitura de todos os grupos de conta de um token
        /// </summary>
        public IList<AdAccountGroup> ReadAll(IList<AdAccountGroupFieldsEnum> fields)
        {
            this._facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
                fields = AdAccountGroupFieldsEnumExtensions.GetDefaultsAdAccountGroupFieldsList();

            string fieldNames = string.Join(",", fields.GetFacebookNamesList());
            string accountEndpoint = this._facebookSession.GetFacebookAdsApiConfiguration().AdAccountGroupAllEndpoint;
            accountEndpoint = string.Format(accountEndpoint, this._facebookSession.GetUserAccessToken(), fieldNames);

            IRequest webRequest = new Request();
            var accountGroups = new List<AdAccountGroup>();
            var adAccountGroupModel = new AdAccountGroup();
            
            while (true)
            {
                var getRequest = webRequest.Get(accountEndpoint);
                if(String.IsNullOrEmpty(getRequest))
                    break;

                var groupsList = adAccountGroupModel.ParseMultipleResponse(getRequest);
                if (groupsList == null)
                    break;

                accountGroups.AddRange(groupsList.Data);

                var nextPage = getRequest.GetNextPage();
                if (String.IsNullOrEmpty(nextPage) || nextPage.Equals(accountEndpoint))
                    break;

                accountEndpoint = nextPage;
            }
            
            return accountGroups;
        }
    }
}
