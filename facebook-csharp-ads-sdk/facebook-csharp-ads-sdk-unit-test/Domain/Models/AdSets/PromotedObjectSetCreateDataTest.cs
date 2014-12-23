using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class PromotedObjectSetCreateDataTest
    {
        private string objectStoreUrl = string.Empty;
        private long objectId;
        private AdCampaignObjectiveEnum campaignObjective;

        [TestInitialize]
        public void Initialize()
        {
            this.objectStoreUrl = "www.objectStoreUrl.com";
            objectId = 1056489897789740;
            campaignObjective = AdCampaignObjectiveEnum.WebsiteConversions;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidObjectIdException))]
        public void MustThrowExceptionToSetCreateDataIfObjectIdLessThanZero()
        {
            this.objectId = -1;
            new PromotedObject().SetDataToCreate(campaignObjective, objectId, this.objectStoreUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidObjectStoreUrlException))]
        public void MustThrowExceptionToSetCreateDataIfObjectStoreUrlEmptyAndObjectiveMobileAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppInstalls;
            this.objectStoreUrl = string.Empty;

            new PromotedObject().SetDataToCreate(campaignObjective, objectId, this.objectStoreUrl);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidObjectStoreUrlException))]
        public void MustThrowExceptionToSetCreateDataIfObjectStoreUrlEmptyAndObjectiveMobileAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppEngagement;
            this.objectStoreUrl = string.Empty;

            new PromotedObject().SetDataToCreate(campaignObjective, objectId, this.objectStoreUrl);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidObjectStoreUrlException))]
        public void MustThrowExceptionToSetCreateDataIfObjectStoreUrlEmptyAndObjectiveCanvasAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppInstalls;
            this.objectStoreUrl = string.Empty;

            new PromotedObject().SetDataToCreate(campaignObjective, objectId, this.objectStoreUrl);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidObjectStoreUrlException))]
        public void MustThrowExceptionToSetCreateDataIfObjectStoreUrlEmptyAndObjectiveCanvasAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppEngagement;
            this.objectStoreUrl = string.Empty;

            new PromotedObject().SetDataToCreate(campaignObjective, objectId, this.objectStoreUrl);
        }

        [TestMethod]
        public void MustSetPixelIdIfObjectiveIsWebsiteConversions()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.WebsiteConversions;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNotNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNull(promotedObject.ApplicationId);
            Assert.IsNull(promotedObject.ObjectStoreUrl);
            Assert.AreEqual(this.objectId, promotedObject.PixelId);
        }

        [TestMethod]
        public void MustSetPageIdIfObjectiveIsPageLikes()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.PageLikes;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNotNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNull(promotedObject.ApplicationId);
            Assert.IsNull(promotedObject.ObjectStoreUrl);
            Assert.AreEqual(this.objectId, promotedObject.PageId);
        }

        [TestMethod]
        public void MustSetOfferIdIfObjectiveIsOfferClaims()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.OfferClaims;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNotNull(promotedObject.OfferId);
            Assert.IsNull(promotedObject.ApplicationId);
            Assert.IsNull(promotedObject.ObjectStoreUrl);
            Assert.AreEqual(this.objectId, promotedObject.OfferId);
        }

        [TestMethod]
        public void MustSetApplicationIdIfObjectiveIsMobileAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppInstalls;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNotNull(promotedObject.ApplicationId);
            Assert.IsNotNull(promotedObject.ObjectStoreUrl);

            Assert.AreEqual(this.objectId, promotedObject.ApplicationId);
            Assert.AreEqual(this.objectStoreUrl, promotedObject.ObjectStoreUrl);
        }

        [TestMethod]
        public void MustSetApplicationIdIfObjectiveIsMobileAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.MobileAppEngagement;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNotNull(promotedObject.ApplicationId);
            Assert.IsNotNull(promotedObject.ObjectStoreUrl);

            Assert.AreEqual(this.objectId, promotedObject.ApplicationId);
            Assert.AreEqual(this.objectStoreUrl, promotedObject.ObjectStoreUrl);
        }

        [TestMethod]
        public void MustSetApplicationIdIfObjectiveIsCanvasAppInstalls()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppInstalls;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNotNull(promotedObject.ApplicationId);
            Assert.IsNotNull(promotedObject.ObjectStoreUrl);

            Assert.AreEqual(this.objectId, promotedObject.ApplicationId);
            Assert.AreEqual(this.objectStoreUrl, promotedObject.ObjectStoreUrl);
        }

        [TestMethod]
        public void MustSetApplicationIdIfObjectiveIsCanvasAppEngagement()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.CanvasAppEngagement;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNotNull(promotedObject.ApplicationId);
            Assert.IsNotNull(promotedObject.ObjectStoreUrl);

            Assert.AreEqual(this.objectId, promotedObject.ApplicationId);
            Assert.AreEqual(this.objectStoreUrl, promotedObject.ObjectStoreUrl);
        }

        [TestMethod]
        public void MustSetAllAttributesNullIfObjectiveIsNotRequired()
        {
            this.campaignObjective = AdCampaignObjectiveEnum.None;
            var promotedObject = new PromotedObject().SetDataToCreate(campaignObjective, objectId, objectStoreUrl);

            Assert.IsNotNull(promotedObject);
            Assert.IsNull(promotedObject.PixelId);
            Assert.IsNull(promotedObject.PageId);
            Assert.IsNull(promotedObject.OfferId);
            Assert.IsNull(promotedObject.ApplicationId);
            Assert.IsNull(promotedObject.ObjectStoreUrl);
        }
    }
}
