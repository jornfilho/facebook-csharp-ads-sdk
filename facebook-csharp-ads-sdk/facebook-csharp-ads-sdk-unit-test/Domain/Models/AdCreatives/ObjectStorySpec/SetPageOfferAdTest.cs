using System;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPageOfferAdTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec _model;
        private DateTime _validDateTime;
        private DateTime _validReminderDateTime;
        private DateTime _invalidDateTime;
        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec();
            _validDateTime = DateTime.UtcNow.AddHours(4);
            _validReminderDateTime = DateTime.UtcNow.AddHours(2);
            _invalidDateTime = DateTime.UtcNow.AddHours(-1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativePageIdException))]
        public void MustThrowExceptionToSetPageOfferObjectIfPageIdIsInvalid()
        {
            _model.SetPageOfferAd(InvalidPageId, null, null, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetPageOfferObjectIfTitleIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, InvalidSpecTitle, null, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetPageOfferObjectIfTitleIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, InvalidSpecTitle, null, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageOfferObjectIfMessageIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, InvalidSpecMessage, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageOfferObjectIfMessageIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, null, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageOfferObjectIfImageUrlIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, InvalidSpecImageUrl, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetPageOfferObjectIfImageUrlIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, null, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCouponTypeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfCouponTypeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, InvalidSpecCouponType, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeCouponTypeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfCouponTypeIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, null, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeExpirationTimeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfExpirationTimeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _invalidDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeReminderTimeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfReminderTimeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _invalidDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeClaimLimitException))]
        public void MustThrowExceptionToSetPageOfferObjectIfClaimLimitIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 0, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeRedemptionLinkException))]
        public void MustThrowExceptionToSetPageOfferObjectIfRedemptionLinkIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, InvalidRedemptionLink, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeRedemptionLinkException))]
        public void MustThrowExceptionToSetPageOfferObjectIfRedemptionLinkIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeRedemptionCodeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfRedemptionCodeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, InvalidRedemptionCode, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeRedemptionCodeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfRedemptionCodeIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBarcodeTypeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfBarcodeTypeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, ValidRedemptionCode, InvalidBarcodeType, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBarcodeTypeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfBarcodeTypeIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, ValidRedemptionCode, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBarcodeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfBarcodeIsInvalid()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, ValidRedemptionCode, ValidBarcodeType, InvalidBarcode);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBarcodeException))]
        public void MustThrowExceptionToSetPageOfferObjectIfBarcodeIsNull()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, ValidRedemptionCode, ValidBarcodeType, null);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPageOfferAd(ValidAdCreativePageId, ValidSpecTitle, ValidSpecMessage, ValidSpecImageUrl, ValidSpecCouponType, _validDateTime, _validReminderDateTime, 1, ValidRedemptionLink, ValidRedemptionCode, ValidBarcodeType, ValidBarcode);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.PageId, ValidAdCreativePageId);
            Assert.AreEqual(_model.Title, ValidSpecTitle);
            Assert.AreEqual(_model.Message, ValidSpecMessage);
            Assert.AreEqual(_model.ImageUrl, ValidSpecImageUrl);
            Assert.AreEqual(_model.CouponType, ValidSpecCouponType);
            Assert.AreEqual(_model.ExpirationTime, _validDateTime);
            Assert.AreEqual(_model.ReminderTime, _validReminderDateTime);
            Assert.AreEqual(_model.ClaimLimit, 1);
            Assert.AreEqual(_model.RedemptionLink, ValidRedemptionLink);
            Assert.AreEqual(_model.RedemptionCode, ValidRedemptionCode);
            Assert.AreEqual(_model.BarcodeType, ValidBarcodeType);
            Assert.AreEqual(_model.Barcode, ValidBarcode);
        }

    }
}
