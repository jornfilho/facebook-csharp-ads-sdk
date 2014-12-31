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
        private AdCampaignUpdateData updateData;

        private long accountId = 123456789;
        private long campaignId = 9879789789;
        private string campaignName;
        private AdCampaignObjectiveEnum? campaignObjective;
        private AdCampaignStatusEnum? campaignStatus;
        private IList<ExecutionOptionsEnum> executionOptions;

        [TestInitialize]
        public void Initialize()
        {
            this.mockCampaignRepository = new Mock<ICampaignRepository>();

            campaignName = "Campaign 1";
            campaignObjective = AdCampaignObjectiveEnum.None;
            campaignStatus = AdCampaignStatusEnum.Active;
            executionOptions = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void ShouldReturnErrorIfCampaignIdInvalidToSetUpdateData()
        {
            this.accountId = -1;
            this.InitializeUpdateData();
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, executionOptions);
        }

        [TestMethod]
        public void ShouldSetUpdateModelIsReadyFalseIfNeitherParameterIsUpdated()
        {
            campaignName = null;
            campaignObjective = null;
            campaignStatus = null;
            executionOptions = null;

            this.InitializeUpdateData();
            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, executionOptions);

            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.UpdateModelIsReady);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCampaignObjectiveException))]
        public void ShouldReturnErrorIfCampaignObjectiveIsUndefinedToSetUpdateData()
        {
            campaignObjective = AdCampaignObjectiveEnum.Undefined;
            this.InitializeUpdateData();
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, executionOptions);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCampaingStatusException))]
        public void ShouldReturnErrorIfCampaignStatusIsUndefinedToSetUpdateData()
        {
            campaignStatus = AdCampaignStatusEnum.Undefined;
            this.InitializeUpdateData();
            new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, executionOptions);
        }

        [TestMethod]
        public void ShouldReturnErrorIfAnUnexpectedExceptionOccurWhenCallingRepository()
        {
            string facebookResponseGetAdCampaign = "{'id': '546546546'}";
            var campaign = new AdCampaign(mockCampaignRepository.Object);
            campaign.ParseReadSingleResponse(facebookResponseGetAdCampaign);

            mockCampaignRepository.Setup(m => m.Update(It.IsAny<AdCampaign>())).Throws<Exception>();
            this.InitializeUpdateData();
            campaign.SetUpdateData(this.updateData, executionOptions);

            campaign = campaign.Update(campaignId);
            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.AtLeastOnce);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorIfUpdateModelIsNotReady()
        {
            this.campaignName = string.Empty;
            campaignObjective = null;
            campaignStatus = null;
            executionOptions = null;

            this.InitializeUpdateData();
            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, null);
            campaign = campaign.Update(campaignId);

            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.Never);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorIfAdCampaignIdIsInvalid()
        {
            campaignId = -1;

            this.InitializeUpdateData();
            AdCampaign campaign = new AdCampaign(mockCampaignRepository.Object).SetUpdateData(this.updateData, executionOptions);

            campaign = campaign.Update(campaignId);

            mockCampaignRepository.Verify(m => m.Update(It.IsAny<AdCampaign>()), Times.Never);
            Assert.IsNotNull(campaign);
            Assert.IsFalse(campaign.IsValid);
        }

        #region private methods

        private void InitializeUpdateData()
        {
            this.updateData = new AdCampaignUpdateData
                              {
                                  AccountId = this.accountId,
                                  Name = this.campaignName,
                                  Objective = this.campaignObjective,
                                  Status = this.campaignStatus
                              };
        }

        #endregion private methods
    }
}
