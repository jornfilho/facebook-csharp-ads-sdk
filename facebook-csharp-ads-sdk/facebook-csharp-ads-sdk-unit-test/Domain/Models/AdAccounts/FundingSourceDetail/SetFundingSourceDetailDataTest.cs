using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FundingSourceDetail
{
    [TestClass]
    public class SetFundingSourceDetailDataTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidFundingDetailId_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    InvalidFundingSourceDetailId1,
                    ValidFundingSourceDetailDisplayString,
                    ValidFundingSourceDetailType
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidFundingDetailId_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    InvalidFundingSourceDetailId2,
                    ValidFundingSourceDetailDisplayString,
                    ValidFundingSourceDetailType
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidFundingDetailDisplayString_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    InvalidFundingSourceDetailDisplayString1,
                    ValidFundingSourceDetailType
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.DisplayString, InvalidFundingSourceDetailDisplayString1);
        }

        [TestMethod]
        public void CantSetInvalidFundingDetailDisplayString_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    InvalidFundingSourceDetailDisplayString2,
                    ValidFundingSourceDetailType
                );

            Assert.IsNull(model.DisplayString);
        }

        [TestMethod]
        public void CantSetInvalidFundingDetailType_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    ValidFundingSourceDetailDisplayString,
                    InvalidFundingSourceDetailType1
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidFundingDetailType_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    ValidFundingSourceDetailDisplayString,
                    InvalidFundingSourceDetailType2
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }
        
        [TestMethod]
        public void CanSetAllPropertiesData_AllValidData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    ValidFundingSourceDetailDisplayString,
                    ValidFundingSourceDetailType
                );
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id, ValidFundingSourceDetailId);
            Assert.AreEqual(model.DisplayString, ValidFundingSourceDetailDisplayString);
            Assert.AreEqual(model.Type, ValidFundingSourceDetailType);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CantValidateData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceDetail();
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);

            model.SetFundingSourceDetailData(ValidFundingSourceDetailId, InvalidFundingSourceDetailDisplayString1, ValidFundingSourceDetailType);
            Assert.IsTrue(model.IsValid);
            RenewModel(out model);

            model.SetFundingSourceDetailData(ValidFundingSourceDetailId, InvalidFundingSourceDetailDisplayString2, ValidFundingSourceDetailType);
            Assert.IsTrue(model.IsValid);
            RenewModel(out model);

            model.SetFundingSourceDetailData(ValidFundingSourceDetailId, ValidFundingSourceDetailDisplayString, ValidFundingSourceDetailType);
            Assert.IsTrue(model.IsValid);
            RenewModel(out model);
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceDetail model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceDetail();
            Assert.IsFalse(model.IsValid);
        }
    }
}
