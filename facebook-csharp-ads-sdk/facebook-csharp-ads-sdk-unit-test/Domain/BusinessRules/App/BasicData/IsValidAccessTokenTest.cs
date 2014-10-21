using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.App.BasicData
{
    [TestClass]
    public class IsValidAccessTokenTest : TestBase
    {
        [TestMethod]
        public void CanTestIfAccessTokenHasAValidValue()
        {
            var result = ValidAccessToken.IsValidAppSecret();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAccessTokenHasAInvalidValue_1()
        {
            var result = InvalidAccessToken1.IsValidAccessToken();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAccessTokenHasAInvalidValue_2()
        {
            var result = InvalidAccessToken1.IsValidAccessToken();
            Assert.IsFalse(result);
        }
    }
}
