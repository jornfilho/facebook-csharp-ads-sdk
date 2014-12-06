using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountFinancialInformationsTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetNullFinancialInformationsOnAdAccountData()
        {
            model.SetAdAccountFinancialInformations(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.FinancialInformations);
        }

        [TestMethod]
        public void CantSetInvalidFinancialInformationsOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.FinancialInformations();

            model.SetAdAccountFinancialInformations(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.FinancialInformations);
        }

        [TestMethod]
        public void CantSetFinancialInformationsOnAdAccountData()
        {
            model.SetAdAccountFinancialInformations(ValidFinancialInformations);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.FinancialInformations);
            Assert.AreEqual(model.FinancialInformations, ValidFinancialInformations);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
