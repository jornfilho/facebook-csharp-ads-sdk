using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.App.BasicData
{
    [TestClass]
    public class IsValidAppIdTest : TestBase
    {
        [TestMethod]
        public void CanTestIfAppIdHasAValidValueWithNotNullableValue()
        {
            var result = ValidAppId.IsValidAppId();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAppIdHasAValidValueWithNullableValue()
        {
            long? validAppIdNullable = ValidAppId;
            var result = validAppIdNullable.IsValidAppId();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAppIdHasAInvalidValueWithNotNullableValue()
        {
            var result = InvalidAppId.IsValidAppId();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAppIdHasAInvalidValueWithNullableValue()
        {
            long? invalidAppIdNullable = InvalidAppId;
            var result = invalidAppIdNullable.IsValidAppId();
            Assert.IsFalse(result);
        }
    }
}
