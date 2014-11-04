using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialCurrencyTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]
        public void CantSetInvalidAdAccountCurrencyToFinancialInformations()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialCurrency(InvalidFinancialInformationsCurrency);
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
