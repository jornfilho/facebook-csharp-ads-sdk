using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.AdCreative
{
    [TestClass]
    public class SetLinkAdDataTest : TestBase
    {
        readonly ICreativeRepository _creativeRepository = new AdCreativeRepository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative(_creativeRepository);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeIdException))]
        public void MustThrowExceptionToSetLinkAdDataIfCreativeIdIsInvalid()
        {
            _model.SetLinkAdData(InvalidAdCreativeId, ValidAdAccountId, null, null, null, null, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void MustThrowExceptionToSetLinkAdDataIfAccountIdIsInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, InvalidAdAccountId1, null, null, null, null, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetLinkAdDataIfTitleIsInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, InvalidAdCreativeTitle, null, null, null, null, null, null, null);
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeTitleException))]
        public void MustThrowExceptionToSetLinkAdDataIfTitleIsNull()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, null, null, null, null, null, null, null, null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBodyException))]
        public void MustThrowExceptionToSetLinkAdDataIfBodyIsInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, InvalidAdCreativeBody, null, null, null, null, null, null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBodyException))]
        public void MustThrowExceptionToSetLinkAdDataIfBodyIsNull()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, null, null, null, null, null, null, null);

        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectUrlException))]
        public void MustThrowExceptionToSetLinkAdDataIfObjectUrlIsInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, InvalidAdCreativeObjectUrl, null, null, null, null, null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectUrlException))]
        public void MustThrowExceptionToSetLinkAdDataIfObjectUrlIsNull()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, null, null, null, null, null, null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetLinkAdDataIfImageFileAndImageHashAreInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, InvalidAdCreativeImageFile, InvalidAdCreativeImageHash, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetLinkAdDataIfImageFileIsInvalidAndImageHashIsNull()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, InvalidAdCreativeImageFile, null, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetLinkAdDataIfImageFileIsNullAndImageHashIsInvalid()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, null, InvalidAdCreativeImageHash, null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeImageException))]
        public void MustThrowExceptionToSetLinkAdDataIfImageFileAndImageHashAreNull()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, null, null, null, null, null);
        }

        [TestMethod]
        public void CanSetJustRequiredProperties()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, null, ValidAdCreativeImageHash, null, null, null);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.Title, ValidAdCreativeTitle);
            Assert.AreEqual(_model.Body, ValidAdCreativeBody);
            Assert.AreEqual(_model.ObjectUrl, ValidAdCreativeObjectUrl);
            Assert.AreEqual(_model.ImageHash, ValidAdCreativeImageHash);
            Assert.IsNull(_model.Name);
            Assert.IsNull(_model.ActorId);
            Assert.IsNull(_model.FollowRedirect);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetLinkAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeTitle, ValidAdCreativeBody, ValidAdCreativeObjectUrl, null, ValidAdCreativeImageHash, ValidAdCreativeName, ValidAdCreativeActorId, true);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.Title, ValidAdCreativeTitle);
            Assert.AreEqual(_model.Body, ValidAdCreativeBody);
            Assert.AreEqual(_model.ObjectUrl, ValidAdCreativeObjectUrl);
            Assert.AreEqual(_model.ImageHash, ValidAdCreativeImageHash);
            Assert.AreEqual(_model.Name, ValidAdCreativeName);
            Assert.AreEqual(_model.ActorId, ValidAdCreativeActorId);
            Assert.IsTrue((bool) _model.FollowRedirect);
        }
    }
}
