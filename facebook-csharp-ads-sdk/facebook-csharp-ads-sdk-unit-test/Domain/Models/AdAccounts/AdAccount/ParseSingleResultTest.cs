using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class ParseSingleResultTest : TestBase
    {
        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .ParseSingleResult(InvalidAdAccountSingleResultResponse1);

            Assert.IsNull(model);

        }

        [TestMethod]
        public void CantParseInvalidSingleAdAccountFacebookResponse_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .ParseSingleResult(InvalidAdAccountSingleResultResponse2);

            Assert.IsNull(model);

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookErrorResponse()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .ParseSingleResult(InvalidAdAccountSingleResultResponse3);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
            Assert.IsNotNull(model.GetApiErrorResonse());

        }

        [TestMethod]
        public void CanParseSingleAdAccountFacebookResponse_allFields_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .ParseSingleResult(ValidAdAccountSingleResultResponse1);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.IsNull(model.GetApiErrorResonse());

        }
    }
}
