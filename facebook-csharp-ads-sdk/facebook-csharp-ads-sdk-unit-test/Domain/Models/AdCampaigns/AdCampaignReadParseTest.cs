using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     Test class of the AdCampaign model
    /// </summary>
    [TestClass]
    public class AdCampaignReadParseTest
    {
        private CampaignRepository campaignRepository;
        private const string FacebookError = "{\"error\":{\"message\":\"Invalid OAuth access token.\",\"type\":\"OAuthException\",\"code\":190}}";

        long campaignIdExpected = 11111111111;
        private const string CampaignNameExpected = "campaign 1";
        private const long AccountIdExpected = 99999999;
        private const long AdGroupId1Expected = 123;
        private const long AdGroupId2Expected = 456;
        private const long AdGroupId3Expected = 789;
        private const AdCampaignBuyingTypeEnum BuyingTypeExpected = AdCampaignBuyingTypeEnum.Auction;
        private const AdCampaignObjectiveEnum ObjectiveExpected = AdCampaignObjectiveEnum.None;
        private const AdCampaignStatusEnum CampaignStatusExpected = AdCampaignStatusEnum.Paused;
        string facebookResponseGetAdCampaign = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            IFacebookSession facebookSession = new FacebookSessionRepository();
            campaignRepository = new CampaignRepository(facebookSession);
        }

        [TestMethod]
        public void MustSetErrorIfFacebookReturnError()
        {
            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(FacebookError);
            Assert.AreEqual(0, campaign.Id);
            Assert.IsFalse(campaign.IsValid);
            Assert.IsNotNull(campaign.ApiErrorResponseData);
            Assert.AreEqual(campaign.ApiErrorResponseData.Code, 190);
        }

        [TestMethod]
        public void MustMakeTheCorrectParseIfFacebookDoesNotReturnError()
        {
            this.SetFacebookResponseOkWithAllFields();
            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);

            Assert.IsTrue(campaign.IsValid);
            Assert.IsNull(campaign.ApiErrorResponseData);
            
            Assert.AreEqual(campaignIdExpected, campaign.Id);
            Assert.AreEqual(CampaignNameExpected, campaign.Name);
            Assert.AreEqual(AccountIdExpected, campaign.AccountId);

            Assert.AreEqual(3, campaign.AdGroups.Count);
            Assert.IsTrue(campaign.AdGroups.Contains(AdGroupId1Expected));
            Assert.IsTrue(campaign.AdGroups.Contains(AdGroupId2Expected));
            Assert.IsTrue(campaign.AdGroups.Contains(AdGroupId3Expected));
            
            Assert.AreEqual(BuyingTypeExpected, campaign.BuyingType);
            Assert.AreEqual(ObjectiveExpected, campaign.Objective);
            Assert.AreEqual(CampaignStatusExpected, campaign.Status);
        }

        [TestMethod]
        public void MustSetInvalidDataIfAdCampaignIdInvalid()

        {
            this.campaignIdExpected = 0;
            this.SetFacebookResponseOkWithAllFields();

            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void MustSetInvalidDataIfFacebookResponseIsNull()
        {
            this.facebookResponseGetAdCampaign = null;
            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void MustSetInvalidDataIfFacebookResponseIsEmpty()
        {
            this.facebookResponseGetAdCampaign = string.Empty;
            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);
            Assert.IsFalse(campaign.IsValid);
        }

        [TestMethod]
        public void ThereMustSetAdIdListIfFieldDataDoesNotExist()
        {
            this.facebookResponseGetAdCampaign = "{'id': '" + this.campaignIdExpected + "', " +
                                                 "'adgroups': {" +
                                                 "'paging': {'cursors': {'before': 'NjAxOTA5MTc1NDE4OA==', 'after': 'NjAxNjE3MDE4MDE4OA=='}}}}";

            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);
            Assert.IsTrue(campaign.IsValid);
            Assert.AreEqual(this.campaignIdExpected, campaign.Id);
            Assert.IsNull(campaign.AdGroups);
        }

        [TestMethod]
        public void ThereMustSetAdIdListIfFieldDataDoesNotArray()
        {
            this.facebookResponseGetAdCampaign = "{'id': '" + this.campaignIdExpected +
                                                 "', 'adgroups': {'data': " +
                                                 "{'id': '" + AdGroupId1Expected + "'}," +
                                                 "'paging': {'cursors': {'before': 'NjAxOTA5MTc1NDE4OA==', 'after': 'NjAxNjE3MDE4MDE4OA=='}}}}";

            var campaign = new AdCampaign(campaignRepository);
            campaign.ParseReadSingleesponse(facebookResponseGetAdCampaign);
            Assert.IsTrue(campaign.IsValid);
            Assert.AreEqual(this.campaignIdExpected, campaign.Id);
            Assert.IsNull(campaign.AdGroups);
        }

        #region Private methods
        
        /// <summary>
        ///     Set correct Facebook response 
        /// </summary>
        private void SetFacebookResponseOkWithAllFields()
        {
            this.facebookResponseGetAdCampaign = "{'id': '" + this.campaignIdExpected +
                                            "', 'name': '" + CampaignNameExpected +
                                            "', 'account_id': '" + AccountIdExpected +
                                            "', 'adgroups': {'data': " +
                                            "[{'id': '" + AdGroupId1Expected + "'}," +
                                            "{'id': '" + AdGroupId2Expected + "'}," +
                                            "{'id': '" + AdGroupId3Expected + "'}], " +
                                            "'paging': {'cursors': {'before': 'NjAxOTA5MTc1NDE4OA==', 'after': 'NjAxNjE3MDE4MDE4OA=='}}}," +
                                            "'buying_type': '" + BuyingTypeExpected.GetBuyingTypeFacebookName() + "', " +
                                            "'objective': '" + ObjectiveExpected.GetCampaignObjectiveFacebookName() + "', " +
                                            "'campaign_group_status': '" +
                                            CampaignStatusExpected.GetCampaignStatusFacebookName() + "' }";
        }

        #endregion Private methods
    }
}
