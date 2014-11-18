using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountBusinessInformationsTest : TestBase
    {
        [TestMethod]
        public void CantSetNullBusinessInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountBusinessInformations(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.BusinessInformations);
        }

        [TestMethod]
        public void CantSetInvalidBusinessInformationsAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();

            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountBusinessInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.BusinessInformations);
        }

        [TestMethod]
        public void CantSetBusinessInformationsOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountBusinessInformations(ValidBusinessInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.BusinessInformations);
            Assert.AreEqual(model.BusinessInformations, ValidBusinessInformations);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
