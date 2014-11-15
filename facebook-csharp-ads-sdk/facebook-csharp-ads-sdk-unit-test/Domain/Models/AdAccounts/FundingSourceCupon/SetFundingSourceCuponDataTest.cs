using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FundingSourceCupon
{
    [TestClass]
    public class SetFundingSourceCuponDataTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidFundingSourceCuponAmount_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    InvalidFundingSourceCuponAmount1,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantSetInvalidFundingSourceCuponAmount_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    InvalidFundingSourceCuponAmount2,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantSetInvalidFundingSourceCuponCurrency_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmount,
                    InvalidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }
        
        [TestMethod]
        public void CanSetAllPropertiesData_AllValidData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Amount, ValidFundingSourceCuponAmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.AreEqual(model.DisplayAmount, ValidFundingSourceCuponDisplayAmount);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidExpitationDate()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmount,
                    ValidFundingSourceCuponCurrency,
                    InvalidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Amount, ValidFundingSourceCuponAmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.IsNull(model.Expiration);
            Assert.AreEqual(model.DisplayAmount, ValidFundingSourceCuponDisplayAmount);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidDisplayAmount_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    InvalidFundingSourceCuponDisplayAmount1
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Amount, ValidFundingSourceCuponAmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.AreEqual(model.DisplayAmount, InvalidFundingSourceCuponDisplayAmount1);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidDisplayAmount_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    InvalidFundingSourceCuponDisplayAmount2
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Amount, ValidFundingSourceCuponAmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.AreEqual(model.DisplayAmount, InvalidFundingSourceCuponDisplayAmount2);
        }

        [TestMethod]
        public void CanValidateData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCoupon();
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmount, ValidFundingSourceCuponCurrency, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmount, ValidFundingSourceCuponCurrency, ValidFundingSourceCuponExpirationDate, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmount, ValidFundingSourceCuponCurrency, null, ValidFundingSourceCuponDisplayAmount);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceCoupon model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceCoupon();
            Assert.IsFalse(model.IsValidData());
        }
    }
}
