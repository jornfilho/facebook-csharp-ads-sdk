using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.AdAccounts.FinancialInformations
{
    [TestClass]
    public class IsValidAdAccountSpendCapTest
    {
        private double? _nullableInvalidValue1;
        private double? _nullableInvalidValue2;
        private double? _nullableValidValue;
        private double _notNullableInvalidValue1;
        private double _notNullableInvalidValue2;
        private double _notNullableValidValue;

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
        public void CanTestIfNullableInvalidSpendCapHasAValidValue_1()
        {
            var isValid = _nullableInvalidValue1.IsValidAdAccountSpendCap();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableInvalidSpendCapHasAValidValue_2()
        {
            var isValid = _nullableInvalidValue2.IsValidAdAccountSpendCap();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableValidSpendCapHasAValidValue()
        {
            var isValid = _nullableValidValue.IsValidAdAccountSpendCap();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidSpendCapHasAValidValue_1()
        {
            var isValid = _notNullableInvalidValue1.IsValidAdAccountSpendCap();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidSpendCapHasAValidValue_2()
        {
            var isValid = _notNullableInvalidValue2.IsValidAdAccountSpendCap();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableValidSpendCapHasAValidValue()
        {
            var isValid = _notNullableValidValue.IsValidAdAccountSpendCap();

            Assert.IsTrue(isValid);
        }
    }
}
