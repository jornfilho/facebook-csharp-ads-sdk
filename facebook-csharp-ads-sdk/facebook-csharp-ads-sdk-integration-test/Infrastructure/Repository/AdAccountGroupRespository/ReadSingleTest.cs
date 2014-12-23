using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using facebook_csharp_ads_sdk_integration_test._personalInformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_integration_test.Infrastructure.Repository.AdAccountGroupRespository
{
    [TestClass]
    public class ReadSingleTest : AdAccountGroup
    {
        private IAccountGroupRepository _accountGroupRepository;
        private IFacebookSession _facebookSession;
        private IList<AdAccountGroupFieldsEnum> _fields;

        [TestInitialize]
        public void Initialize()
        {
            _facebookSession = new FacebookSessionRepository()
                .SetUserAccessToken(FacebookToken);

            _accountGroupRepository = new facebook_csharp_ads_sdk
                .Infrastructure
                .Repository
                .AdAccountGroupRespository(_facebookSession);

            _fields = AdAccountGroupFieldsEnumExtensions.GetDefaultsAdAccountGroupFieldsList();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessToken))]
        public void CantGetSingleAccountGroupIfFacebookSessionHasInvalidFacebookToken()
        {
            _facebookSession = new FacebookSessionRepository()
                .SetUserAccessToken("");

            _accountGroupRepository = new facebook_csharp_ads_sdk
                .Infrastructure
                .Repository
                .AdAccountGroupRespository(_facebookSession);

            _accountGroupRepository.ReadSingle(1, _fields);
        }

        [TestMethod]
        public void CanGetSingleAccountGroup()
        {
            var data = _accountGroupRepository.ReadSingle(AdAccountGroupId, _fields);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.IsValid);
        }
    }
}
