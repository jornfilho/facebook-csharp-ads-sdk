using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.ObjectStorySpec
{
    [TestClass]
    public class SetPageTextAdTest : TestBase
    {
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativePageIdException))]
        public void MustThrowExceptionToSetPageTextObjectIfPageIdIsInvalid()
        {
            _model.SetPageTextAd(InvalidPageId, null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageTextObjectIfMessageIsInvalid()
        {
            _model.SetPageTextAd(ValidAdCreativePageId, InvalidSpecMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeMessageException))]
        public void MustThrowExceptionToSetPageTextObjectIfMessageIsNull()
        {
            _model.SetPageTextAd(ValidAdCreativePageId, null);
        }

        [TestMethod]
        public void CanSetAllProperties()
        {
            _model.SetPageTextAd(ValidAdCreativePageId, ValidSpecMessage);
            Assert.IsNotNull(_model);
            Assert.IsTrue(_model.IsValid);
            Assert.AreEqual(_model.PageId, ValidAdCreativePageId);
            Assert.AreEqual(_model.Message, ValidSpecMessage);
        }

    }
}
