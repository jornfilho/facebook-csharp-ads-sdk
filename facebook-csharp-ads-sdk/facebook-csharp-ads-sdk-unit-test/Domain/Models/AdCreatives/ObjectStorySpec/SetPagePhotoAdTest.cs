using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPagePhotoAdTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativePageIdException))]
        public void MustThrowExceptionToSetPageLinkObjectIfPageIdIsInvalid()
        {
            _model.SetPagePhotoAd(InvalidPageId, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfUrlAndImageHashIsInvalid()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, InvalidSpecUrl, InvalidSpecImageHash, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfUrlIsInvalidAndImageHashIsNull()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, InvalidSpecUrl, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfUrlIsNullAndImageHashIsInvalid()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, null, InvalidSpecImageHash, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfUrlAndImageHashIsNull()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfCaptionIsInvalid()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, ValidSpecUrl, null, InvalidSpecCaption);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfCaptionIsNull()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, ValidSpecUrl, null, null);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPagePhotoAd(ValidAdCreativePageId, ValidSpecUrl, null, ValidSpecCaption);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.PageId, ValidAdCreativePageId);
            Assert.AreEqual(_model.Url, ValidSpecUrl);
            Assert.IsNull(_model.ImageHash);
            Assert.AreEqual(_model.Caption, ValidSpecCaption);
        }

    }
}
