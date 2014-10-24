using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAppSecretTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAppSecret()
        {
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);

            var appSecret = RepositoryFacebookSession.GetAppSecret();
            
            Assert.AreEqual(appSecret, ValidAppSecret);
        }
    }
}
