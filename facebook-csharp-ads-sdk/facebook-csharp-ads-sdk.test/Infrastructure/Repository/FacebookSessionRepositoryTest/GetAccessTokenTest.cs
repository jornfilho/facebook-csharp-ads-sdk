using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAccessTokenTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAccessToken()
        {
            repositoryFacebookSession.SetAccessToken(ValidAccessToken);

            var accessToken = repositoryFacebookSession.GetAccessToken();
            
            Assert.AreEqual(accessToken, ValidAccessToken);
        }
    }
}
