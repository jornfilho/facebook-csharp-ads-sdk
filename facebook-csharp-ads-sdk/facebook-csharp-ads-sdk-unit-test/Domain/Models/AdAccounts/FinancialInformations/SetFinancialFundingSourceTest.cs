using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialFundingSourceTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidFundingSourceIdToFinancialInformations_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingSource(InvalidAdAccountFundingSourceId1);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.FundingSourceId, InvalidAdAccountFundingSourceId1 > 0 
                ? InvalidAdAccountFundingSourceId1 
                : default(long));
        }

        [TestMethod]
        public void CantSetInvalidFundingSourceIdToFinancialInformations_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingSource(InvalidAdAccountFundingSourceId2);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.FundingSourceId, InvalidAdAccountFundingSourceId2 > 0
                ? InvalidAdAccountFundingSourceId2
                : default(long));
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
