using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPageVideoAdTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativePageIdException))]
        public void MustThrowExceptionToSetPageVideoObjectIfPageIdIsInvalid()
        {
            _model.SetPageVideoAd(InvalidPageId, ValidSpecVideoId, null, null, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeVideoIdException))]
        public void MustThrowExceptionToSetPageVideoObjectIfVideoIdIsInvalid()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, InvalidSpecVideoId, null, null, null, null, CallToActionTypeEnum.Undefined);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetPageVideoObjectIfTitleIsInvalid()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, InvalidSpecTitle, null, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetPageVideoObjectIfTitleIsNull()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, null, null, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageVideoObjectIfDescriptionIsInvalid()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, InvalidSpecDescription, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetPageVideoObjectIfDescriptionIsNull()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, null, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageVideoObjectIfImageUrlIsInvalid()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, InvalidSpecImageUrl, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageVideoObjectIfImageUrlIsNull()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, null, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageVideoObjectIfImageHashIsInvalid()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, ValidSpecImageUrl, InvalidSpecImageHash, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageVideoObjectIfImageHashIsNull()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, ValidSpecImageUrl, null, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCallToActionTypeException))]
        public void MustThrowExceptionToSetPageVideoObjectIfCallToActionIsUndefined()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, ValidSpecImageUrl, ValidSpecImageHash, CallToActionTypeEnum.Undefined);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPageVideoAd(ValidAdCreativePageId, ValidSpecVideoId, ValidSpecTitle, ValidSpecDescription, ValidSpecImageUrl, ValidSpecImageHash, CallToActionTypeEnum.WatchVideo);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.PageId, ValidAdCreativePageId);
            Assert.AreEqual(_model.VideoId, ValidSpecVideoId);
            Assert.AreEqual(_model.Title, ValidSpecTitle);
            Assert.AreEqual(_model.Description, ValidSpecDescription);
            Assert.AreEqual(_model.ImageUrl, ValidSpecImageUrl);
            Assert.AreEqual(_model.ImageHash, ValidSpecImageHash);
            Assert.AreEqual(_model.CallToAction, CallToActionTypeEnum.WatchVideo);
        }
    }
}
