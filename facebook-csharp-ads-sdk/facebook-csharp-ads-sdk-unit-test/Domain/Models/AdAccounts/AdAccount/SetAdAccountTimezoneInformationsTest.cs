using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountTimezoneInformationsTest : TestBase
    {
        [TestMethod]
        public void CantSetNullTimezoneInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountTimezoneInformations(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.TimezoneInformations);
        }

        [TestMethod]
        public void CantSetInvalidTimezoneInformationsAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.TimezoneInformations();

            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountTimezoneInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.TimezoneInformations);
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
