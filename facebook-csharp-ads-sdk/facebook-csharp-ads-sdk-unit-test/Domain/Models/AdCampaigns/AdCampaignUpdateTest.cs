using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Unit teste for the ad campaign update method
    /// </summary>
    [TestClass]
    public class AdCampaignUpdateTest
    {
        private Mock<ICampaignRepository> mockCampaignRepository;
        private long accountId = 123456789;
        private long campaignId = 9879789789;
        private string campaignName = "Campaign 1";
        private AdCampaignObjectiveEnum? campaignObjective = AdCampaignObjectiveEnum.None;
        private AdCampaignStatusEnum? campaignStatus = AdCampaignStatusEnum.Active;
        private IList<ExecutionOptionsEnum> executionOptions = null;

        [TestInitialize]
        public void Initialize()
        {
            this.mockCampaignRepository = new Mock<ICampaignRepository>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void ShouldReturnErrorIfCampaignIdInvalidToSetUpdateData()
        {
            this.accountId = -1;
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(accountId, campaignName, campaignObjective, campaignStatus, executionOptions);
        }

        [TestMethod]
        public void ShouldSetUpdateModelIsReadyFalseIfNeitherParameterIsUpdated()
        {
            campaignName = null;
            campaignObjective = null;
            campaignStatus = null;
            executionOptions = null;

            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(accountId, campaignName,
                campaignObjective, campaignStatus, executionOptions);

            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.UpdateModelIsReady);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCampaignObjectiveException))]
        public void ShouldReturnErrorIfCampaignObjectiveIsUndefinedToSetUpdateData()
        {
            campaignObjective = AdCampaignObjectiveEnum.Undefined;
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(accountId, campaignName, campaignObjective, campaignStatus, executionOptions);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCampaingStatusException))]
        public void ShouldReturnErrorIfCampaignStatusIsUndefinedToSetUpdateData()
        {
            campaignStatus = AdCampaignStatusEnum.Undefined;
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(accountId, campaignName, campaignObjective, campaignStatus, executionOptions);
        }

        [TestMethod]
        public void ShouldReturnErrorIfAnUnexpectedExceptionOccurWhenCallingRepository()
        {
            string facebookResponseGetAdCampaign = "{'id': '546546546'}";
            var campaign = new AdCampaign(mockCampaignRepository.Object);
            campaign.ParseReadSingleResponse(facebookResponseGetAdCampaign);

            mockCampaignRepository.Setup(m => m.Update(It.IsAny<AdCampaign>())).Throws<Exception>();
            campaign.SetUpdateData(accountId, campaignName, campaignObjective, campaignStatus, executionOptions);

            campaign = campaign.Update(campaignId);
            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.AtLeastOnce);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorIfUpdateModelIsNotReady()
        {
            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(32132131, string.Empty, null, null, null);
            campaign = campaign.Update(campaignId);

            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.Never);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorIfAdCampaignIdIsInvalid()
        {
            campaignId = -1;

            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(accountId, campaignName,
                campaignObjective, campaignStatus, executionOptions);

            campaign = campaign.Update(campaignId);

            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.Never);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }
    }
}
