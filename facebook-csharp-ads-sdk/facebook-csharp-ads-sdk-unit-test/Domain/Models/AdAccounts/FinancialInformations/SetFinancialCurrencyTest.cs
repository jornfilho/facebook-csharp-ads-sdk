using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialCurrencyTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidAdAccountCurrencyToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialCurrency(InvalidFinancialInformationsCurrency);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CanSetInvalidAdAccountCurrencyToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialCurrency(ValidFinancialInformationsCurrency);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Currency, ValidFinancialInformationsCurrency);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
