using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountTimezoneInformationsTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantSetNullTimezoneInformationsOnAdAccountData()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountTimezoneInformations(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidTimezoneInformationsAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.TimezoneInformations();

            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountTimezoneInformations(invalidData);
        }

        [TestMethod]
        public void CantSetTimezoneInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountTimezoneInformations(ValidTimezoneInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.TimezoneInformations);
            Assert.AreEqual(model.TimezoneInformations, ValidTimezoneInformations);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
