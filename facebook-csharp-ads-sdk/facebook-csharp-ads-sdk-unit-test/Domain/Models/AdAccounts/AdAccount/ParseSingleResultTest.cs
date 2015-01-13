using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class ParseSingleResultTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRepository(new FacebookSessionRepository());
        readonly IAdStatisticsRepository adStatisticsRepository = new AdStatisticsRepository(new FacebookSessionRepository());

        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository, adStatisticsRepository);
        }

        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_1()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse1);
            Assert.IsFalse(model.IsValid);

        }

        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_2()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse2);
            Assert.IsFalse(model.IsValid);

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookErrorResponse()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse3);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
            Assert.IsNotNull(model.ApiErrorResponseData);

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookResponse_allFields_1()
        {
            model.ParseSingleResult(ValidAdAccountSingleResultResponse1);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
            Assert.IsNull(model.ApiErrorResponseData);

        }
    }
}
