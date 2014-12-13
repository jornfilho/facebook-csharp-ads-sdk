using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountAgencyDeclarationTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetNullAgencyClientDeclarationOnAdAccountData()
        {
            model.SetAdAccountAgencyDeclaration(null);
            Assert.IsNotNull(model);
            Assert.IsNull(model.AgencyClientDeclaration);
        }

        [TestMethod]
        public void CantSetInvalidAgencyClientDeclarationOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AgencyClientDeclaration();
            model.SetAdAccountAgencyDeclaration(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AgencyClientDeclaration);
        }

        [TestMethod]
        public void CantSetAgencyClientDeclarationOnAdAccountData()
        {
            model.SetAdAccountAgencyDeclaration(ValidAgencyClientDeclaration);
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AgencyClientDeclaration);
            Assert.AreEqual(model.AgencyClientDeclaration, ValidAgencyClientDeclaration);
            Assert.IsTrue(model.IsValid);
        }
    }
}
