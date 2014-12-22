using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FundingSourceDetail
{
    [TestClass]
    public class SetFundingSourceCuponTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CantSetInvalidFundingSourceCuponToFundingSourceDetailModel_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceCoupon(InvalidFundingSourceDetailCupon1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantSetInvalidFundingSourceCuponToFundingSourceDetailModel_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceCoupon(InvalidFundingSourceDetailCupon2);
        }

        [TestMethod]
        public void CanSetFundingSourceCuponToFundingSourceDetailModel()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceCoupon(ValidFundingSourceDetailCoupon);
            
            Assert.IsTrue(model.IsValid);
        }

    }
}
