using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class ParseSingleResultTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_1()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse1);
            Assert.IsNull(model);

        }

        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_2()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse2);
            Assert.IsNull(model);

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookErrorResponse()
        {
            model.ParseSingleResult(InvalidAdAccountSingleResultResponse3);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
            Assert.IsNotNull(model.GetApiErrorResonse());

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookResponse_allFields_1()
        {
            model.ParseSingleResult(ValidAdAccountSingleResultResponse1);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.IsNull(model.GetApiErrorResonse());

        }
    }
}
