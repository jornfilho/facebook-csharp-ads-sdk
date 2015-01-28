using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.AdCreative
{
    [TestClass]
    public class SetPagePostAdDataTest : TestBase
    {
        readonly ICreativeRepository _creativeRepository = new AdCreativeRepository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative _model;
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec objectStorySpec;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative(_creativeRepository);
            objectStorySpec = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec().SetPageTextAd(ValidAdCreativePageId, ValidAdCreativeMessage);
        }

        #region Object Story Spec
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeIdException))]
        public void MustThrowExceptionToSetPagePostSpecAdDataIfCreativeIdIsInvalid()
        {
            _model.SetPagePostAdData(InvalidAdCreativeId, ValidAdAccountId, null as facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void MustThrowExceptionToSetPagePostSpecAdDataIfAccountIdIsInvalid()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, InvalidAdAccountId1, null as facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectStorySpecException))]
        public void MustThrowExceptionToSetPagePostSpecAdDataIfObjectStorySpecIsNull()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, null as facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec, null, null);
        }

        [TestMethod]
        public void CanSetJustRequiredParameters1()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, objectStorySpec, null, null);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectStorySpec, objectStorySpec);
            Assert.IsNull(_model.UrlTags);
            Assert.IsNull(_model.Name);
        }
        
        [TestMethod]
        public void CanSetAllParameters2()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, objectStorySpec, ValidAdCreativeUrlTags, ValidAdCreativeName);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectStorySpec, objectStorySpec);
            Assert.AreEqual(_model.UrlTags, ValidAdCreativeUrlTags);
            Assert.AreEqual(_model.Name, ValidAdCreativeName);
        }

        #endregion

        #region Object Story Id
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeIdException))]
        public void MustThrowExceptionToSetPagePostIdAdDataIfCreativeIdIsInvalid()
        {
            _model.SetPagePostAdData(InvalidAdCreativeId, ValidAdAccountId, null as string, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void MustThrowExceptionToSetPagePostIdAdDataIfAccountIdIsInvalid()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, InvalidAdAccountId1, null as string, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectStoryIdException))]
        public void MustThrowExceptionToSetPagePostIdAdDataIfObjectStoryIdIsInvalid()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, InvalidAdCreativeObjectStoryId, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectStoryIdException))]
        public void MustThrowExceptionToSetPagePostIdAdDataIfObjectStoryIdIsNull()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, null as string, null, null);
        }

        [TestMethod]
        public void CanSetJustRequiredParameters2()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectStoryId, null, null);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectStoryId, ValidAdCreativeObjectStoryId);
            Assert.IsNull(_model.UrlTags);
            Assert.IsNull(_model.Name);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectStoryId, ValidAdCreativeUrlTags, ValidAdCreativeName);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectStoryId, ValidAdCreativeObjectStoryId);
            Assert.AreEqual(_model.UrlTags, ValidAdCreativeUrlTags);
            Assert.AreEqual(_model.Name, ValidAdCreativeName);
        }

        #endregion Object Story Id
    }
}