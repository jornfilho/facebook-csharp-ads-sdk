using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAppSecretTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAppSecret()
        {
            repositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);

            var appSecret = repositoryFacebookSession.GetAppSecret();
            
            Assert.AreEqual(appSecret, ValidAppSecret);
        }
    }
}
