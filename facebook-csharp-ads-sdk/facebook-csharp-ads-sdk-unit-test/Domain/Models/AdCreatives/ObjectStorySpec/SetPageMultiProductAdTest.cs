using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPageMultiProductAdTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec _model;
        private IList<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments> _validChildAttachments;
        private IList<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments> _invalidChildAttachments1;
        private IList<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments> _invalidChildAttachments2;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec();
            _validChildAttachments = new List<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments>
            {
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription)
            };

            _invalidChildAttachments1 = new List<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments>
            {
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
            };

            _invalidChildAttachments2 = new List<facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments>
            {
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription),
                new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments().SetData(ValidSpecLink, ValidSpecPicture, ValidSpecImageHash, ValidSpecName, ValidSpecDescription)
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativePageIdException))]
        public void MustThrowExceptionToSetPageMultiProductObjectIfPageIdIsInvalid()
        {
            _model.SetPageMultiProductAd(InvalidPageId, null, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfLinkIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, InvalidSpecLink, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfLinkIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, null, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfMessageIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, InvalidSpecMessage, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfMessageIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, null, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfNameIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, InvalidSpecName, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfNameIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, null, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfCaptionIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, InvalidSpecCaption, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCaptionException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfCaptionIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, null, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfDescriptionIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, InvalidSpecDescription, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfDescriptionIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, null, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfPictureAndImageHashIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, InvalidSpecPicture, InvalidSpecImageHash, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfPictureAndImageHashIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfPictureIsInvalidAndImageHashIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, InvalidSpecPicture, null, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfPictureIsNullAndImageHashIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, InvalidSpecImageHash, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCallToActionTypeException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfCallToActionIsUndefined()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.Undefined, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageCropsException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfImageCropsIsInvalid()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, InvalidSpecImageCrops, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageCropsException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfImageCropsIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeChildAttachmentsException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfChildAttachmentsIsInvalid1()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, ValidSpecImageCrops, _invalidChildAttachments1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeChildAttachmentsException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfChildAttachmentsIsInvalid2()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, ValidSpecImageCrops, _invalidChildAttachments2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeChildAttachmentsException))]
        public void MustThrowExceptionToSetPageMultiProductObjectObjectIfChildAttachmentsIsNull()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, ValidSpecImageCrops, null);
        }
        
        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPageMultiProductAd(ValidAdCreativePageId, ValidSpecLink, ValidSpecMessage, ValidSpecName, ValidSpecCaption, ValidSpecDescription, null, ValidSpecImageHash, CallToActionTypeEnum.OpenLink, ValidSpecImageCrops, _validChildAttachments);
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
            Assert.AreEqual(_model.ChildAttachments, _validChildAttachments);
        }

    }
}
