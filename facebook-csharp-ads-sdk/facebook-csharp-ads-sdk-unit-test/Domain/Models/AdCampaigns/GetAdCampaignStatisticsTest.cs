using System;
using System.Collections.Generic;
using System.Linq;
using DevUtils.Enum;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    [TestClass]
    public class GetAdCampaignStatisticsTest : TestBase
    {
        private Mock<ICampaignRepository> mockCampaignRepository;
        private Mock<IAdStatisticsRepository> mockAdStatisticsRepository; 

        [TestInitialize]
        public void Initialize()
        {
            this.mockCampaignRepository = new Mock<ICampaignRepository>();
            this.mockAdStatisticsRepository = new Mock<IAdStatisticsRepository>();
        }

        [TestMethod]
        public void CanGetStatistics()
        {
            var campaign = new AdCampaign(mockCampaignRepository.Object, mockAdStatisticsRepository.Object);
            var startDate = DateTime.UtcNow.AddDays(-7);
            var EndDate = DateTime.UtcNow;
            var stats = campaign.GetStatistics(startDate, EndDate);
            Assert.IsTrue(stats.Result.IsValid);
        }

        [TestMethod]
        public void CantGetStatisticsWithInvalidDateTime()
        {
            var campaign = new AdCampaign(mockCampaignRepository.Object, mockAdStatisticsRepository.Object);
            var startDate = DateTime.Now.AddDays(-7);
            var EndDate = DateTime.Now;
            
            try
            {
                var stats = campaign.GetStatistics(startDate, EndDate);
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
