using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAppAccessTokenTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAppAccessToken()
        {
            RepositoryFacebookSession.SetAppAccessToken(ValidAccessToken);

            var accessToken = RepositoryFacebookSession.GetAppAccessToken();
            
            Assert.AreEqual(accessToken, ValidAccessToken);
        }
    }
}
