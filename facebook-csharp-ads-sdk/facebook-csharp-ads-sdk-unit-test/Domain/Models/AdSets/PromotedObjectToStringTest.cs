using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class PromotedObjectToStringTest
    {
        private AdCampaignObjectiveEnum campaignObjective;
        private long objectId;
        private string objectStoreUrl = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            this.objectStoreUrl = "www.objectStoreUrl.com";
            objectId = 1056489897789740;
            campaignObjective = AdCampaignObjectiveEnum.WebsiteConversions;
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsCanvasAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppEngagement;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{application_id: " + objectId + ",object_store_url: " + this.objectStoreUrl + "}",
                promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsCanvasAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppInstalls;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{application_id: " + objectId + ",object_store_url: " + this.objectStoreUrl + "}",
                promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsMobileAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppEngagement;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{application_id: " + objectId + ",object_store_url: " + this.objectStoreUrl + "}",
                promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsMobileAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppInstalls;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{application_id: " + objectId + ",object_store_url: " + this.objectStoreUrl + "}",
                promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsOfferClaims()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.OfferClaims;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{offer_id: " + objectId + "}", promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsPageLikes()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.PageLikes;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{page_id: " + objectId + "}", promotedObject.ToString());
        }

        [TestMethod]
        public void MustReturnStringRepresentationCorretlyIfObjectiveIsWebsiteConversions()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.WebsiteConversions;
            PromotedObject promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId,
                objectStoreUrl);
            Assert.AreEqual("{pixel_id: " + objectId + "}", promotedObject.ToString());
        }
    }
}