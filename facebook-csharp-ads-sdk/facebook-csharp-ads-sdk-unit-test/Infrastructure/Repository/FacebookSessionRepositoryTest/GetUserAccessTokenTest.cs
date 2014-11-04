using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetUserAccessTokenTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfUserAccessToken()
        {
            RepositoryFacebookSession.SetUserAccessToken(ValidAccessToken);

            var accessToken = RepositoryFacebookSession.GetUserAccessToken();
            
            Assert.AreEqual(accessToken, ValidAccessToken);
        }
    }
}
