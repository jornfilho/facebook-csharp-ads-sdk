﻿using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountGroupTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRepository(new FacebookSessionRepository());
        readonly IAdStatisticsRepository adStatisticsRepository = new AdStatisticsRepository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository, adStatisticsRepository);
        }

        [TestMethod]
        public void CantSetNullAdAccountGroupOnAdAccountData()
        {
            model.SetAdAccountGroup(null);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountGroupOnAdAccountData()
        {
            var invalidData = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup();
            
            model.SetAdAccountGroup(invalidData);

            Assert.IsNotNull(model);
            Assert.IsNull(model.AccountGroups);
        }

        [TestMethod]
        public void CantSetSingleAdAccountGroupOnAdAccountData()
        {
            model.SetAdAccountGroup(ValidAdAccountGroup);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AccountGroups);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.AccountGroups.Count, 1);
        }

        [TestMethod]
        public void CantSetMultipleAdAccountGroupOnAdAccountData()
        {
            model.SetAdAccountGroup(ValidAdAccountGroup)
                .SetAdAccountGroup(ValidAdAccountGroup);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.AccountGroups);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.AccountGroups.Count, 2);
        }
    }
}
