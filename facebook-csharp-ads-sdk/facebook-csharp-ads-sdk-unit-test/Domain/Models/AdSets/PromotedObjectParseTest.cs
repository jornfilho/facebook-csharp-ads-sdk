using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    /// <summary>
    ///     Unit test of the promoted post object parse
    /// </summary>
    [TestClass]
    public class PromotedObjectParseTest
    {
        private long adSetID = 6021520552388;
        private Mock<IAdSetRepository> mockAdSetRepository;
        private string objectStoreUrl = "www.facebook.com";

        [TestInitialize]
        public void Initialize()
        {
            mockAdSetRepository = new Mock<IAdSetRepository>();
        }

        [TestMethod]
        public void ShouldBeParsePromotedObjectCorretlyIfObjectIdIsApplicationId()
        {
            long appId = 60215206546231;

            string facebookResponse = "{'id':'" + adSetID + "', 'promoted_object': {'application_id' : '" + appId +
                                      "', 'object_store_url': '" + objectStoreUrl + "'}}";
            AdSet adSet = new AdSet(this.mockAdSetRepository.Object);

            adSet.ParseReadSingleResponse(facebookResponse);

            Assert.IsNotNull(adSet);
            Assert.AreEqual(adSetID, adSet.Id);
            Assert.IsNotNull(adSet.PromotedObject);
            Assert.IsNotNull(adSet.PromotedObject.ApplicationId);
            Assert.AreEqual(appId, adSet.PromotedObject.ApplicationId);
            Assert.IsNotNull(adSet.PromotedObject.ObjectStoreUrl);
            Assert.AreEqual(objectStoreUrl, adSet.PromotedObject.ObjectStoreUrl);

            Assert.IsNull(adSet.PromotedObject.PixelId);
            Assert.IsNull(adSet.PromotedObject.PageId);
        }

        [TestMethod]
        public void ShouldBeParsePromotedObjectCorretlyIfObjectIdIsOfferId()
        {
            long offerId = 60215206546231;

            string facebookResponse = "{'id':'" + adSetID + "', 'promoted_object': {'offer_id' : '" + offerId + "'}}";
            AdSet adSet = new AdSet(this.mockAdSetRepository.Object);

            adSet.ParseReadSingleResponse(facebookResponse);

            Assert.IsNotNull(adSet);
            Assert.AreEqual(adSetID, adSet.Id);
            Assert.IsNotNull(adSet.PromotedObject);
            Assert.IsNotNull(adSet.PromotedObject.OfferId);
            Assert.AreEqual(offerId, adSet.PromotedObject.OfferId);

            Assert.IsNull(adSet.PromotedObject.ObjectStoreUrl);
            Assert.IsNull(adSet.PromotedObject.PixelId);
            Assert.IsNull(adSet.PromotedObject.PageId);
            Assert.IsNull(adSet.PromotedObject.ApplicationId);
        }

        [TestMethod]
        public void ShouldBeParsePromotedObjectCorretlyIfObjectIdIsPageId()
        {
            long pageId = 60215206546231;

            string facebookResponse = "{'id':'" + adSetID + "', 'promoted_object': {'page_id' : '" + pageId + "'}}";
            AdSet adSet = new AdSet(this.mockAdSetRepository.Object);

            adSet.ParseReadSingleResponse(facebookResponse);

            Assert.IsNotNull(adSet);
            Assert.AreEqual(adSetID, adSet.Id);
            Assert.IsNotNull(adSet.PromotedObject);
            Assert.IsNotNull(adSet.PromotedObject.PageId);
            Assert.AreEqual(pageId, adSet.PromotedObject.PageId);

            Assert.IsNull(adSet.PromotedObject.ObjectStoreUrl);
            Assert.IsNull(adSet.PromotedObject.PixelId);
            Assert.IsNull(adSet.PromotedObject.OfferId);
        }

        [TestMethod]
        public void ShouldBeParsePromotedObjectCorretlyIfObjectIdIsPixelId()
        {
            long pixelId = 60215206546231;

            string facebookResponse = "{'id':'" + adSetID + "', 'promoted_object': {'pixel_id' : '" + pixelId + "'}}";
            AdSet adSet = new AdSet(this.mockAdSetRepository.Object);

            adSet.ParseReadSingleResponse(facebookResponse);

            Assert.IsNotNull(adSet);
            Assert.AreEqual(adSetID, adSet.Id);
            Assert.IsNotNull(adSet.PromotedObject);
            Assert.IsNotNull(adSet.PromotedObject.PixelId);
            Assert.AreEqual(pixelId, adSet.PromotedObject.PixelId);
            Assert.IsNull(adSet.PromotedObject.ObjectStoreUrl);
            Assert.IsNull(adSet.PromotedObject.PageId);
            Assert.IsNull(adSet.PromotedObject.OfferId);
        }
    }
}