using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountFinancialInformationsTest : TestBase
    {
        [TestMethod]
        public void CantSetNullFinancialInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountFinancialInformations(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.FinancialInformations);
        }

        [TestMethod]
        public void CantSetInvalidFinancialInformationsOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FinancialInformations();

            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountFinancialInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.FinancialInformations);
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
