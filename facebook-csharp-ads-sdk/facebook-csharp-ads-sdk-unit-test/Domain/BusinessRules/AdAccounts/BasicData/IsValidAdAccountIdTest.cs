using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.AdAccounts.BasicData
{
    [TestClass]
    public class IsValidAdAccountIdTest : TestBase
    {
        [TestMethod]
        public void CanTestIfAdAccountIdHasAValidValueWithNotNullableValue()
        {
            var result = ValidAdAccountId.IsValidAdAccountId();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountIdHasAValidValueWithNullableValue()
        {
            long? validAdAccountIdNullable = ValidAdAccountId;
            var result = validAdAccountIdNullable.IsValidAdAccountId();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountIdHasAnInvalidValueWithNotNullableValue()
        {
            var result = InvalidAdAccountId.IsValidAdAccountId();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountIdHasAnInvalidValueWithNullableValue()
        {
            long? invalidAdAccountIdNullable = InvalidAdAccountId;
            var result = invalidAdAccountIdNullable.IsValidAdAccountId();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountStrIdHasAValidValue()
        {
            var result = ValidAdAccountStrId.IsValidAdAccountId(ValidAdAccountId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountStrIdHasAnInvalidValue_1()
        {
            var result = ValidAdAccountStrId.IsValidAdAccountId(InvalidAdAccountId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountStrIdHasAnInvalidValue_2()
        {
            var result = InvalidAdAccountStrId1.IsValidAdAccountId(ValidAdAccountId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanTestIfAdAccountStrIdHasAnInvalidValue_3()
        {
            var result = InvalidAdAccountStrId2.IsValidAdAccountId(ValidAdAccountId);
            Assert.IsFalse(result);
        }
    }
}
