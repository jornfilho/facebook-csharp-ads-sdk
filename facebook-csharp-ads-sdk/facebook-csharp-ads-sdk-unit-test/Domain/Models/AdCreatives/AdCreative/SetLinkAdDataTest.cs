using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
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
        public void CantSetOnlyAdCreativeIdAndAdAccountId()
        {
            _model.SetLinkAdData(
                ValidAdCreativeId,
                ValidAdAccountId,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
                );
            Assert.IsNotNull(_model);
            Assert.IsFalse(_model.IsValid);
        }


    }
}
