using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountTimezoneInformationsTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetNullTimezoneInformationsOnAdAccountData()
        {
            model.SetAdAccountTimezoneInformations(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.TimezoneInformations);
        }

        [TestMethod]
        public void CantSetInvalidTimezoneInformationsAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.TimezoneInformations();

            model.SetAdAccountTimezoneInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.TimezoneInformations);
        }

        [TestMethod]
        public void CantSetTimezoneInformationsOnAdAccountData()
        {
            model.SetAdAccountTimezoneInformations(ValidTimezoneInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.TimezoneInformations);
            Assert.AreEqual(model.TimezoneInformations, ValidTimezoneInformations);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
