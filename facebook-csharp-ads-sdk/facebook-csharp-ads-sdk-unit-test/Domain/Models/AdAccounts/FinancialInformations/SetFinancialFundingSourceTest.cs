using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialFundingSourceTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidFundingSourceIdToFinancialInformations_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingSource(InvalidAdAccountFundingSourceId1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidFundingSourceIdToFinancialInformations_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingSource(InvalidAdAccountFundingSourceId2);
        }

        [TestMethod]
        public void CanSetFundingSourceIdToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingSource(ValidAdAccountFundingSourceId);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.FundingSourceId, ValidAdAccountFundingSourceId);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
