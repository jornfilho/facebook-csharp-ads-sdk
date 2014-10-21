using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.App.BasicData
{
    [TestClass]
    public class IsValidAppSecretTest : TestBase
    {
        [TestMethod]
        public void CanTestIfAppSecretHasAValidValue()
        {
            var result = ValidAppSecret.IsValidAppSecret();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAppSecretHasAInvalidValue_1()
        {
            var result = InvalidAppSecret1.IsValidAppSecret();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAppSecretHasAInvalidValue_2()
        {
            var result = InvalidAppSecret2.IsValidAppSecret();
            Assert.IsFalse(result);
        }
    }
}
