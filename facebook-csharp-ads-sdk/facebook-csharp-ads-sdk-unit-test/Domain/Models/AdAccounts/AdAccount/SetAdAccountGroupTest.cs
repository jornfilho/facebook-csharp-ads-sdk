using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountGroupTest : TestBase
    {
        [TestMethod]
        public void CantSetNullAdAccountGroupOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountGroup(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountGroupOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccountGroup();
            
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountGroup(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetSingleAdAccountGroupOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountGroup(ValidAdAccountGroup);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AccountGroups);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.AccountGroups.Count, 1);
        }

        [TestMethod]
        public void CantSetMultipleAdAccountGroupOnAdAccountData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccount()
                .SetAdAccountGroup(ValidAdAccountGroup)
                .SetAdAccountGroup(ValidAdAccountGroup);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AccountGroups);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.AccountGroups.Count, 2);
        }
    }
}
