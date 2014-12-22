using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialFundingDetailTest : TestBase
    {
        [TestMethod]
        public void CantSendNullFundingSourceDetailToSetFinancialFundingDetail()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(InvalidFundingSourceDetail1);

            Assert.IsNotNull(model);
            if (InvalidFundingSourceDetail1 == null)
            {
                Assert.IsNull(model.FundingSourceDetails);
                return;
            }

            if (!InvalidFundingSourceDetail1.IsValid)
                return;

            Assert.AreEqual(model.FundingSourceDetails.FirstOrDefault(), InvalidFundingSourceDetail1);
        }

        [TestMethod]
        public void CantSendInvalidFundingSourceDetailToSetFinancialFundingDetail()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialFundingDetail(InvalidFundingSourceDetail2);

            Assert.IsNotNull(model);
            if (InvalidFundingSourceDetail2 == null)
            {
                Assert.IsNull(model.FundingSourceDetails);
                return;
            }

            if (!InvalidFundingSourceDetail2.IsValid)
                return;

            Assert.AreEqual(model.FundingSourceDetails.FirstOrDefault(), InvalidFundingSourceDetail2);
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
            Assert.IsTrue(model.IsValid);
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
            Assert.IsTrue(model.IsValid);
        }
    }
}
