using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.AdAccounts.FinancialInformations
{
    [TestClass]
    public class IsValidAdAccountBalanceTest
    {
        private long? _nullableInvalidValue1;
        private long? _nullableInvalidValue2;
        private long? _nullableValidValue;
        private long _notNullableInvalidValue1;
        private long _notNullableInvalidValue2;
        private long _notNullableValidValue;

        [TestInitialize]
        public void Initialize()
        {
            _nullableInvalidValue1 = -1;
            _nullableInvalidValue2 = 0;
            _nullableValidValue = 1;
            _notNullableInvalidValue1 = -1;
            _notNullableInvalidValue2 = 0;
            _notNullableValidValue = 1;
        }

        [TestMethod]
        public void CanTestIfNullableInvalidBalanceHasAValidValue_1()
        {
            var isValid = _nullableInvalidValue1.IsValidAdAccountBalance();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableInvalidBalanceHasAValidValue_2()
        {
            var isValid = _nullableInvalidValue2.IsValidAdAccountBalance();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableValidBalanceHasAValidValue()
        {
            var isValid = _nullableValidValue.IsValidAdAccountBalance();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidBalanceHasAValidValue_1()
        {
            var isValid = _notNullableInvalidValue1.IsValidAdAccountBalance();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidBalanceHasAValidValue_2()
        {
            var isValid = _notNullableInvalidValue2.IsValidAdAccountBalance();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableValidBalanceHasAValidValue()
        {
            var isValid = _notNullableValidValue.IsValidAdAccountBalance();

            Assert.IsTrue(isValid);
        }
    }
}
