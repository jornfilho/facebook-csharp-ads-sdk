using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountUserTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetNullAdAccountUserOnAdAccountData()
        {
            model.SetAdAccountUser(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountUserOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.User();
            
            model.SetAdAccountUser(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetSingleAdAccountUserOnAdAccountData()
        {
            model.SetAdAccountUser(ValidAdAccountUser);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Users);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.Users.Count, 1);
        }

        [TestMethod]
        public void CantSetMultipleAdAccountUserOnAdAccountData()
        {
            model.SetAdAccountUser(ValidAdAccountUser)
                .SetAdAccountUser(ValidAdAccountUser);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Users);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.Users.Count, 2);
        }
    }
}
