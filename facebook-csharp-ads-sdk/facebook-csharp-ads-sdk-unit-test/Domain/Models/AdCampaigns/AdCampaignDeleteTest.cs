using System;
using System.Threading.Tasks;
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

        [TestInitialize]
        public void Initialize()
        {
            mockCampaignRepository = new Mock<ICampaignRepository>();
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteWithParameterIfIdInvalid()
        {
            var campaign = new AdCampaign(mockCampaignRepository.Object);

            bool successDelete = campaign.Delete(0);
            mockCampaignRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.Never);
            Assert.IsFalse(successDelete);
        }

        [TestMethod]
        public void ShouldSetInvalidAdCampaignToUpdateToDeleteAdSet()
        {
            this.mockCampaignRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(Task.FromResult(true));
            var campaign = new AdCampaign(this.mockCampaignRepository.Object);

            bool successDelete = campaign.Delete(10);
            this.mockCampaignRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.AtLeastOnce);
            Assert.IsTrue(successDelete);
            Assert.IsFalse(campaign.UpdateModelIsReady);
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteAdSetIfIdAnExceptionThrow()
        {
            this.mockCampaignRepository.Setup(m => m.Delete(It.IsAny<long>())).Throws(new Exception());
            var campaign = new AdCampaign(this.mockCampaignRepository.Object);

            bool successDelete = campaign.Delete(10);
            this.mockCampaignRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.AtLeastOnce);
            Assert.IsFalse(successDelete);
        }
    }
}