using System.Linq;
using facebook_csharp_ads_sdk.Domain.Models.Configurations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetFacebookAdsApiConfigurationTest : TestBase
    {
        private FacebookAdsApiConfiguration Configuration { get; set; }

        [TestMethod]
        public void CanGetFacebookAdsApiConfiguration()
        {
            Configuration = repositoryFacebookSession.GetFacebookAdsApiConfiguration();
            Assert.IsNotNull(Configuration);
        }

        [TestMethod]
        public void CanGetFacebookAdsApiVersionFromConfiguration()
        {
            Configuration = repositoryFacebookSession.GetFacebookAdsApiConfiguration();
            var version = Configuration.Version;
            Assert.IsNotNull(version);
        }

        [TestMethod]
        public void CanGetGraphApiUrlFromConfiguration()
        {
            Configuration = repositoryFacebookSession.GetFacebookAdsApiConfiguration();
            var graphApiUrl = Configuration.GraphApiUrl;
            Assert.IsNotNull(graphApiUrl);
        }

        [TestMethod]
        public void CanGetAdAccountFieldsListFromConfiguration()
        {
            Configuration = repositoryFacebookSession.GetFacebookAdsApiConfiguration();
            var adAccountFields = Configuration.AdAccountFields;
            Assert.IsNotNull(adAccountFields);
            Assert.IsTrue(adAccountFields.Any());
        }

        [TestMethod]
        public void CanGetAdAccountReadDataUrlFromConfiguration()
        {
            Configuration = repositoryFacebookSession.GetFacebookAdsApiConfiguration();
            var adAccountReadDataUrl = Configuration.AdAccountReadDataUrl;
            Assert.IsNotNull(adAccountReadDataUrl);
        }
    }
}
