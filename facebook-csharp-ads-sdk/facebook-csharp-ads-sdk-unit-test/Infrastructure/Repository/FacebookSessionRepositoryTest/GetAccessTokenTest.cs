using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class GetAccessTokenTest : TestBase
    {
        [TestMethod]
        public void CanSetAnGetValueOfAccessToken()
        {
            RepositoryFacebookSession.SetAccessToken(ValidAccessToken);

            var accessToken = RepositoryFacebookSession.GetAccessToken();
            
            Assert.AreEqual(accessToken, ValidAccessToken);
        }
    }
}
