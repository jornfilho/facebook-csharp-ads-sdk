using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountUserTest : TestBase
    {
        [TestMethod]
        public void CantSetNullAdAccountUserOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountUser(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountUserOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.User();
            
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountUser(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetSingleAdAccountUserOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountUser(ValidAdAccountUser);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Users);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.Users.Count, 1);
        }

        [TestMethod]
        public void CantSetMultipleAdAccountUserOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountUser(ValidAdAccountUser)
                .SetAdAccountUser(ValidAdAccountUser);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Users);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.Users.Count, 2);
        }
    }
}
