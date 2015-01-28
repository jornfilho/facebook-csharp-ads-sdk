using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPageLinkAdTest : TestBase
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
            _model.SetPageLinkAd(InvalidPageId, null, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetPageLinkObjectIfLinkIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, InvalidSpecLink, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetPageLinkObjectIfLinkIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, null, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfMessageIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, InvalidSpecMessage, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfMessageIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetPageLinkObjectIfNameIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, InvalidSpecName, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetPageLinkObjectIfNameIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, null, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfCaptionIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, InvalidSpecCaption, null, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfCaptionIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, null, null, null, null, CallToActionTypeEnum.Undefined, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfDescriptionIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, InvalidSpecDescription, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageLinkObjectIfDescriptionIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, null, null, null, CallToActionTypeEnum.Undefined, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfPictureAndImageHashIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, InvalidSpecPicture, InvalidSpecImageHash, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfPictureAndImageHashIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfPictureIsInvalidAndImageHashIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, InvalidSpecPicture, null, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageLinkObjectIfPictureIsNullAndImageHashIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, InvalidSpecImageHash, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCallToActionTypeException))]
        public void MustThrowExceptionToSetPageLinkObjectIfCallToActionIsUndefined()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.Undefined, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageCropsException))]
        public void MustThrowExceptionToSetPageLinkObjectIfImageCropsIsInvalid()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, InvalidSpecImageCrops);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageCropsException))]
        public void MustThrowExceptionToSetPageLinkObjectIfImageCropsIsNull()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, null);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPageLinkAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, ValidSpecImageCrops);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.PageId, ValidAdCreativePageId);
            Assert.AreEqual(_model.Link, ValidSpecLink);
            Assert.AreEqual(_model.Message, ValidSpecMessage);
            Assert.AreEqual(_model.Name, ValidSpecName);
            Assert.AreEqual(_model.Caption, ValidSpecCaption);
            Assert.AreEqual(_model.Description, ValidSpecDescription);
            Assert.IsNull(_model.Picture);
            Assert.AreEqual(_model.ImageHash, ValidSpecImageHash);
            Assert.AreEqual(_model.CallToAction, CallToActionTypeEnum.OpenLink);
            Assert.AreEqual(_model.ImageCrops, ValidSpecImageCrops);
        }
    }
}
