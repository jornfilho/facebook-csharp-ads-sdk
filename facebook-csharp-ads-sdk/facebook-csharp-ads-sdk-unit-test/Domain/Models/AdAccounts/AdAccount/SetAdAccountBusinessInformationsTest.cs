using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountBusinessInformationsTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetNullBusinessInformationsOnAdAccountData()
        {
            model.SetAdAccountBusinessInformations(null);
            Assert.IsNotNull(model);
            Assert.IsNull(model.BusinessInformations);
        }

        [TestMethod]
        public void CantSetInvalidBusinessInformationsAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            model.SetAdAccountBusinessInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.BusinessInformations);
        }

        [TestMethod]
        public void CantSetBusinessInformationsOnAdAccountData()
        {
            model.SetAdAccountBusinessInformations(ValidBusinessInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.BusinessInformations);
            Assert.AreEqual(model.BusinessInformations, ValidBusinessInformations);
            Assert.IsTrue(model.IsValid);
        }
    }
}
