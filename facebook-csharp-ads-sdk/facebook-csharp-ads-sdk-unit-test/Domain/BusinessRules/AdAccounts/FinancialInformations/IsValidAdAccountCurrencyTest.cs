using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.AdAccounts.FinancialInformations
{
    [TestClass]
    public class IsValidAdAccountCurrencyTest
    {
        private CurrenciesEnum? _nullableInvalid1;
        private CurrenciesEnum? _nullableInvalid2;
        private CurrenciesEnum _notNullInvalid;
        private CurrenciesEnum? _nullableValid;
        private CurrenciesEnum _notNullValid;

        [TestInitialize]
        public void Initialize()
        {
            _nullableInvalid1 = CurrenciesEnum.UND;
            _nullableInvalid2 = null;
            _notNullInvalid = CurrenciesEnum.UND;
            _nullableValid = CurrenciesEnum.AED;
            _notNullValid = CurrenciesEnum.AED;
        }

        [TestMethod]
        public void CanTestIfNullableInvalidCurrencyHasAValidValue_1()
        {
            var isValid = _nullableInvalid1.IsValidAdAccountCurrency();
            
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableInvalidCurrencyHasAValidValue_2()
        {
            var isValid = _nullableInvalid2.IsValidAdAccountCurrency();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableInvalidCurrencyHasAValidValue()
        {
            var isValid = _notNullInvalid.IsValidAdAccountCurrency();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfNullableValidCurrencyHasAValidValue()
        {
            var isValid = _nullableValid.IsValidAdAccountCurrency();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CanTestIfNotNullableValidCurrencyHasAValidValue()
        {
            var isValid = _notNullValid.IsValidAdAccountCurrency();

            Assert.IsTrue(isValid);
        }
    }
}
