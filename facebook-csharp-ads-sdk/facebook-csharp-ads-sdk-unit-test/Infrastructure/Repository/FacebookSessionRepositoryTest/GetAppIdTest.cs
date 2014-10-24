using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAppIdTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAppId()
        {
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);

            var appId = RepositoryFacebookSession.GetAppId();
            
            Assert.AreEqual(appId, ValidAppId);
        }
    }
}
