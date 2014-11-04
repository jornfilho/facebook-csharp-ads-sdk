using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.AdAccounts.FinancialInformations
{
    [TestClass]
    public class IsValidAdAccountFundingSourceTest
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
        public void CanTestIfNullableInvalidFundingSourceIdHasAValidValue_1()
        {
            var isValid = _nullableInvalidValue1.IsValidAdAccountFundingSourceId();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableInvalidFundingSourceIdHasAValidValue_2()
        {
            var isValid = _nullableInvalidValue2.IsValidAdAccountFundingSourceId();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableValidFundingSourceIdHasAValidValue()
        {
            var isValid = _nullableValidValue.IsValidAdAccountFundingSourceId();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidFundingSourceIdHasAValidValue_1()
        {
            var isValid = _notNullableInvalidValue1.IsValidAdAccountFundingSourceId();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidFundingSourceIdHasAValidValue_2()
        {
            var isValid = _notNullableInvalidValue2.IsValidAdAccountFundingSourceId();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableValidFundingSourceIdHasAValidValue()
        {
            var isValid = _notNullableValidValue.IsValidAdAccountFundingSourceId();

            Assert.IsTrue(isValid);
        }
    }
}
