﻿using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.AdCreative
{
    [TestClass]
    public class SetPageLikeAdDataTest : TestBase
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
        public void MustThrowExceptionToSetPageLikeAdDataIfCreativeIdIsInvalid()
        {
            _model.SetPageLikeAdData(InvalidAdCreativeId, ValidAdAccountId, null, null, null, null, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void MustThrowExceptionToSetPageLikeAdDataIfAccountIdIsInvalid()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, InvalidAdAccountId1, null, null, null, null, null, null, null, null);
        } 
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectIdException))]
        public void MustThrowExceptionToSetPageLikeAdDataIfObjectIdIsInvalid()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, InvalidAdCreativeObjectId, null, null, null, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeObjectIdException))]
        public void MustThrowExceptionToSetPageLikeAdDataIfObjectIdIsNull()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, null, null, null, null, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBodyException))]
        public void MustThrowExceptionToSetPageLikeAdDataIfBodyIsInvalid()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectId, InvalidAdCreativeBody, null, null, null, null, null, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeBodyException))]
        public void MustThrowExceptionToSetPageLikeAdDataIfBodyIsNull()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectId, null, null, null, null, null, null, null);
        }
        
        [TestMethod]
        public void CanSetJustRequiredProperties()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectId, ValidAdCreativeBody,
                null, null, null, null, null, null);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectId, ValidAdCreativeObjectId);
            Assert.AreEqual(_model.Body, ValidAdCreativeBody);
            Assert.IsNull(_model.Name);
            Assert.IsNull(_model.LinkUrl);
            Assert.IsNull(_model.ImageFile);
            Assert.IsNull(_model.ImageHash);
            Assert.IsNull(_model.ImageCrops);
            Assert.IsNull(_model.Title);
        }

        [TestMethod]
        public void CanSetAllParameters()
        {
            _model.SetPageLikeAdData(ValidAdCreativeId, ValidAdAccountId, ValidAdCreativeObjectId, ValidAdCreativeBody,
                ValidAdCreativeName, ValidAdCreativeLinkUrl, null, ValidAdCreativeImageHash, ValidAdCreativeImageCrops, ValidAdCreativeTitle);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.Id, ValidAdCreativeId);
            Assert.AreEqual(_model.AccountId, ValidAdAccountId);
            Assert.AreEqual(_model.ObjectId, ValidAdCreativeObjectId);
            Assert.AreEqual(_model.Body, ValidAdCreativeBody);
            Assert.AreEqual(_model.Name, ValidAdCreativeName);
            Assert.AreEqual(_model.LinkUrl, ValidAdCreativeLinkUrl);
            Assert.IsNull(_model.ImageFile);
            Assert.AreEqual(_model.ImageHash, ValidAdCreativeImageHash);
            Assert.AreEqual(_model.ImageCrops, ValidAdCreativeImageCrops);
            Assert.AreEqual(_model.Title, ValidAdCreativeTitle);
            
        }
    }
}