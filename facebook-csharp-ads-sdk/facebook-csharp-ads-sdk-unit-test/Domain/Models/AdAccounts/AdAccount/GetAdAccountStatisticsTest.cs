using System;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class GetAdAccountStatisticsTest : TestBase
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
        public void CanGetStatistics()
        {
            var startDate = DateTime.UtcNow.AddDays(-7);
            var EndDate = DateTime.UtcNow;
            var stats = model.GetStatistics(startDate, EndDate);
            Assert.IsTrue(stats.Result.IsValid);
        }

        [TestMethod]
        public void CantGetStatisticsWithInvalidDateTime()
        {
            var startDate = DateTime.Now.AddDays(-7);
            var EndDate = DateTime.Now;
            
            try
            {
                var stats = model.GetStatistics(startDate, EndDate);
                Assert.Fail("Expected ArgumentException to be thrown.");
            }
            catch (ArgumentException ae)
            {
                Assert.IsNotNull(ae);
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }
    }
}
