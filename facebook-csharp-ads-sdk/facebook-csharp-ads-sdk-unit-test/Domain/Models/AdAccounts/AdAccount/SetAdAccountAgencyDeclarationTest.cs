using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountAgencyDeclarationTest : TestBase
    {
        [TestMethod]
        public void CantSetNullAgencyClientDeclarationOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountAgencyDeclaration(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AgencyClientDeclaration);
        }

        [TestMethod]
        public void CantSetInvalidAgencyClientDeclarationOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AgencyClientDeclaration();

            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountAgencyDeclaration(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AgencyClientDeclaration);
        }

        [TestMethod]
        public void CantSetAgencyClientDeclarationOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountAgencyDeclaration(ValidAgencyClientDeclaration);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AgencyClientDeclaration);
            Assert.AreEqual(model.AgencyClientDeclaration, ValidAgencyClientDeclaration);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
