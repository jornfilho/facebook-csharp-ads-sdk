using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountFinancialInformationsTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantSetNullFinancialInformationsOnAdAccountData()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountFinancialInformations(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidFinancialInformationsOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FinancialInformations();

            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountFinancialInformations(invalidData);
        }

        [TestMethod]
        public void CantSetFinancialInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountFinancialInformations(ValidFinancialInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.FinancialInformations);
            Assert.AreEqual(model.FinancialInformations, ValidFinancialInformations);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
