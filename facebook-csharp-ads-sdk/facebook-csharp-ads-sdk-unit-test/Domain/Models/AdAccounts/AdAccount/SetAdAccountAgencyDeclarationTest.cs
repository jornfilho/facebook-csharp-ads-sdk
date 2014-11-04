using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountAgencyDeclarationTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantSetNullAgencyClientDeclarationOnAdAccountData()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountAgencyDeclaration(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidAgencyClientDeclarationOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AgencyClientDeclaration();

            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountAgencyDeclaration(invalidData);
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
