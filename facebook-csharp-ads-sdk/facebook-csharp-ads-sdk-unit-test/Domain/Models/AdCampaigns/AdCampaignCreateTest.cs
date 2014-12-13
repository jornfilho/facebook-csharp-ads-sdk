using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    [TestClass]
    public class AdCampaignCreateTest
    {
        private Mock<ICampaignRepository> mockCampaignRepository;

        private string campaignName = "Campaign 1";
        private AdCampaignBuyingTypeEnum? campaignBuyingType = AdCampaignBuyingTypeEnum.Auction;
        private AdCampaignObjectiveEnum? campaignObjective = AdCampaignObjectiveEnum.None;
        private AdCampaignStatusEnum campaignStatus = AdCampaignStatusEnum.Active;
        private ExecutionOptionsEnum? executionOptions = null;

        [TestInitialize]
        public void Initialize()
        {
            this.mockCampaignRepository = new Mock<ICampaignRepository>();
        }

        [TestMethod]
        public void DeveRetornarErroSeAoSetarDadosDeCriacaoSeNomeDaCampanhaVazio()
        {
            this.campaignName = string.Empty;
            var campaign = new AdCampaign(mockCampaignRepository.Object);
            campaign.SetCreateData(campaignName, campaignBuyingType, campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void DeveRetornarErroSeAoSetarDadosDeCriacaoSeSetarStatusUndefined()
        {
            this.campaignStatus = AdCampaignStatusEnum.Undefined;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void DeveAtribuirBuyingTypeNuloSePassarUndefined()
        {
            this.campaignBuyingType = AdCampaignBuyingTypeEnum.Undefined;
            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.IsNull(campaign.BuyingType);
            Assert.IsTrue(campaign.CreateModelIsReady);
        }

        [TestMethod]
        public void DeveAtribuirObjectiveNuloSePassarUndefined()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.Undefined;

            var campaign = new AdCampaign(mockCampaignRepository.Object).SetCreateData(campaignName, campaignBuyingType,
                campaignObjective, campaignStatus, executionOptions);

            Assert.IsNull(campaign.Objective);
            Assert.IsTrue(campaign.CreateModelIsReady);
        }
    }
}
