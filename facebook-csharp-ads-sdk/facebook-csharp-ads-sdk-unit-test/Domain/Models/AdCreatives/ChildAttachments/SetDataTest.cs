using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ChildAttachments
{
    [TestClass]
    public class SetDataTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ChildAttachments();
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetDataIfLinkIsInvalid()
        {
            _model.SetData(InvalidSpecLink, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeLinkException))]
        public void MustThrowExceptionToSetDataIfLinkIsNull()
        {
            _model.SetData(null, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetDataIfPictureAndImageHashAreInvalid()
        {
            _model.SetData(ValidSpecLink, InvalidSpecPicture, InvalidSpecImageHash, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetDataIfPictureIsInvalidAndImageHashIsNull()
        {
            _model.SetData(ValidSpecLink, InvalidSpecPicture, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetDataIfPictureIsNullAndImageHashIsInvalid()
        {
            _model.SetData(ValidSpecLink, null, InvalidSpecImageHash, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetDataIfPictureAndImageHashAreNull()
        {
            _model.SetData(ValidSpecLink, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetDataIfNameIsInvalid()
        {
            _model.SetData(ValidSpecLink, null, ValidSpecImageHash, InvalidSpecName, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeNameException))]
        public void MustThrowExceptionToSetDataIfNameIsNull()
        {
            _model.SetData(ValidSpecLink, null, ValidSpecImageHash, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetDataIfDescriptionIsInvalid()
        {
            _model.SetData(ValidSpecLink, null, ValidSpecImageHash, ValidSpecName, InvalidSpecDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeDescriptionException))]
        public void MustThrowExceptionToSetDataIfDescriptionIsNull()
        {
            _model.SetData(ValidSpecLink, null, ValidSpecImageHash, ValidSpecName, null);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetData(ValidSpecLink, null, ValidSpecImageHash, ValidSpecName, ValidSpecDescription);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Link, ValidSpecLink);
            Assert.IsNull(_model.Picture);
            Assert.AreEqual(_model.ImageHash, ValidSpecImageHash);
            Assert.AreEqual(_model.Name, ValidSpecName);
            Assert.AreEqual(_model.Description, ValidSpecDescription);
        }
    }
}
