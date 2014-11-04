using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialFundingDetailTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void CantSendNullFundingSourceDetailToSetFinancialFundingDetail()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(InvalidFundingSourceDetail1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSendInvalidFundingSourceDetailToSetFinancialFundingDetail()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(InvalidFundingSourceDetail2);
        }

        [TestMethod]
        public void CanSendSingleValidFundingSourceDetailToSetFinancialFundingDetail()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(ValidFundingSourceDetail);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.FundingSourceDetails);
            Assert.AreEqual(model.FundingSourceDetails.Count, 1);
            Assert.IsTrue(model.IsValidData());
        }

        [TestMethod]
        public void CanSendMultipleValidFundingSourceDetailToSetFinancialFundingDetail()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(ValidFundingSourceDetail)
                .SetFinancialFundingDetail(ValidFundingSourceDetail);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.FundingSourceDetails);
            Assert.AreEqual(model.FundingSourceDetails.Count, 2);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
