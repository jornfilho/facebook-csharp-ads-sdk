using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FundingSourceDetail
{
    [TestClass]
    public class FundingSourceDetailTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidFundingSourceCuponAmmount_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    InvalidFundingSourceCuponAmmount1,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmmount
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidFundingSourceCuponAmmount_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    InvalidFundingSourceCuponAmmount2,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmmount
                );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]
        public void CantSetInvalidFundingSourceCuponCurrency_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmmount,
                    InvalidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmmount
                );
        }
        
        [TestMethod]
        public void CanSetAllPropertiesData_AllValidData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmmount
                );
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Ammount, ValidFundingSourceCuponAmmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.AreEqual(model.DisplayAmount, ValidFundingSourceCuponDisplayAmmount);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidExpitationDate()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmmount,
                    ValidFundingSourceCuponCurrency,
                    InvalidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmmount
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Ammount, ValidFundingSourceCuponAmmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.IsNull(model.Expiration);
            Assert.AreEqual(model.DisplayAmount, ValidFundingSourceCuponDisplayAmmount);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidDisplayAmmount_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    InvalidFundingSourceCuponDisplayAmmount1
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Ammount, ValidFundingSourceCuponAmmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.IsNull(model.DisplayAmount);
        }

        [TestMethod]
        public void CanSetAllPropertiesData_InvalidDisplayAmmount_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidFundingSourceCuponAmmount,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    InvalidFundingSourceCuponDisplayAmmount2
                );

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Ammount, ValidFundingSourceCuponAmmount);
            Assert.AreEqual(model.Currency, ValidFundingSourceCuponCurrency);
            Assert.AreEqual(model.Expiration, ValidFundingSourceCuponExpirationDate);
            Assert.AreEqual(model.DisplayAmount, InvalidFundingSourceCuponDisplayAmmount2);
        }

        [TestMethod]
        public void CantValidateData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FundingSourceCupon();
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmmount, ValidFundingSourceCuponCurrency, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmmount, ValidFundingSourceCuponCurrency, ValidFundingSourceCuponExpirationDate, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetFundingSourceCuponData(ValidFundingSourceCuponAmmount, ValidFundingSourceCuponCurrency, null, ValidFundingSourceCuponDisplayAmmount);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceCupon model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FundingSourceCupon();
            Assert.IsFalse(model.IsValidData());
        }
    }
}
