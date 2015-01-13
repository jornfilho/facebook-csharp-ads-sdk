using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Unit test of the ad campaign delete method 
    /// </summary>
    [TestClass]
    public class AdCampaignDeleteTest
    {
        private Mock<ICampaignRepository> mockCampaignRepository;
        private Mock<IAdStatisticsRepository> mockAdStatisticsRepository; 

        [TestInitialize]
        public void Initialize()
        {
            mockCampaignRepository = new Mock<ICampaignRepository>();
            mockAdStatisticsRepository = new Mock<IAdStatisticsRepository>();
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteWithParameterIfIdInvalid()
        {
            var campaign = new AdCampaign(mockCampaignRepository.Object, mockAdStatisticsRepository.Object);

            bool successDelete = campaign.Delete(0);
            mockCampaignRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.Never);
            Assert.IsFalse(successDelete);
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteWithoutParameterIfIdInvalid()
        {
            var campaign = new AdCampaign(mockCampaignRepository.Object, mockAdStatisticsRepository.Object);
            campaign.ParseReadSingleResponse("{'id': '0'}");

            bool successDelete = campaign.Delete();
            mockCampaignRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.Never);
            Assert.IsFalse(successDelete);
        }
    }
}