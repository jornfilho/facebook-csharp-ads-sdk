﻿using System;
using System.Collections.Generic;
using System.Linq;
using DevUtils.Enum;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Unit teste for the ad campaign create method
    /// </summary>
    [TestClass]
    public class AdCampaignCreateTest
    {
        private Mock<ICampaignRepository> mockCampaignRepository;
        private long accountId = 123456789;
        private string campaignName = "Campaign 1";
        private AdCampaignBuyingTypeEnum? campaignBuyingType = AdCampaignBuyingTypeEnum.Auction;
        private AdCampaignObjectiveEnum? campaignObjective = AdCampaignObjectiveEnum.None;
        private AdCampaignStatusEnum campaignStatus = AdCampaignStatusEnum.Active;
        private IList<ExecutionOptionsEnum> executionOptions = null;

        [TestInitialize]
        public void Initialize()
        {
            this.mockCampaignRepository = new Mock<ICampaignRepository>();
        }

        [TestMethod]
        public void ShouldReturnErrorIfCampaignIdInvalidToSetCreationData()
        {
            this.accountId = -1;
            var campaign = new AdCampaign(mockCampaignRepository.Object);
            campaign.SetCreateData(accountId, campaignName, campaignBuyingType, campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void ShouldReturnErrorIfCampaignNameEmptyToSetCreationData()
        {
            this.campaignName = string.Empty;
            var campaign = new AdCampaign(mockCampaignRepository.Object);
            campaign.SetCreateData(accountId, campaignName, campaignBuyingType, campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void ShouldReturnErrorIfCampaignStatusUndefinedToSetCreationData()
        {
            this.campaignStatus = AdCampaignStatusEnum.Undefined;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void ShouldReturnErrorIfCampaignStatusArchivedToSetCreationData()
        {
            this.campaignStatus = AdCampaignStatusEnum.Archived;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void ShouldReturnErrorIfCampaignStatusDeleteToSetCreationData()
        {
            this.campaignStatus = AdCampaignStatusEnum.Delete;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void MustAssignAdCampaignBuyingTypeNullIfParemeterUndefined()
        {
            this.campaignBuyingType = AdCampaignBuyingTypeEnum.Undefined;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.IsNull(campaign.BuyingType);
            Assert.IsTrue(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void MustAssignAdCampaignObjectiveNullIfParemeterUndefined()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.Undefined;

            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.IsNull(campaign.Objective);
            Assert.IsTrue(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void ShouldNotCreateAdCampaignIfModelNotValidToCreate()
        {
            campaignName = string.Empty;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            AdCampaign campaignCreated = campaign.Create();

            mockCampaignRepository.Verify(m => m.Create(It.IsAny<AdCampaign>()), Times.Never);

            Assert.AreEqual(0, campaignCreated.Id);
            Assert.IsFalse(campaignCreated.IsValid);
        }

        [TestMethod]
        public void MustCorrectlyReturnTheAttributesForCreation()
        {
            executionOptions = new List<ExecutionOptionsEnum> { ExecutionOptionsEnum.ValidateOnly };
            string executionOptionsQueryString = String.Format("[{0}]",
                string.Join(",",
                    executionOptions.Select(
                        u => "\"" + u.ToEnum<ExecutionOptionsEnum>().GetExecutionOptionsFacebookName() + "\"")));

            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(accountId, campaignName, campaignBuyingType,
                   campaignObjective, campaignStatus, executionOptions);

            Dictionary<string, string> dictionaryWithParams = campaign.GetSingleCreateParams();
            Assert.IsNotNull(dictionaryWithParams);
            Assert.AreEqual(5, dictionaryWithParams.Count);

            Assert.IsTrue(dictionaryWithParams.Contains(new KeyValuePair<string, string>("name", campaignName)));
            Assert.IsTrue(dictionaryWithParams.Contains(new KeyValuePair<string, string>("objective", ((AdCampaignObjectiveEnum)campaignObjective).GetCampaignObjectiveFacebookName())));
            Assert.IsTrue(dictionaryWithParams.Contains(new KeyValuePair<string, string>("campaign_group_status", campaignStatus.GetCampaignStatusFacebookName())));
            Assert.IsTrue(dictionaryWithParams.Contains(new KeyValuePair<string, string>("buying_type", ((AdCampaignBuyingTypeEnum)campaignBuyingType).GetBuyingTypeFacebookName())));
            Assert.IsTrue(dictionaryWithParams.Contains(new KeyValuePair<string, string>("execution_options", executionOptionsQueryString)));
        }
    }
}
