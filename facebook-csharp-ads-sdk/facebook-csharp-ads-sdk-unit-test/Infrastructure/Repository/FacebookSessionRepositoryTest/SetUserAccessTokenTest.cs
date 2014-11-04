using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetUserAccessTokenTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessToken))]
        public void CatSetInvalidUserAccessToken_1()
        {
            RepositoryFacebookSession.SetUserAccessToken(InvalidAccessToken1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessToken))]
        public void CatSetInvalidUserAccessToken_2()
        {
            RepositoryFacebookSession.SetUserAccessToken(InvalidAccessToken2);
        }

        [TestMethod]
        public void CanSetUserAccessToken()
        {
            RepositoryFacebookSession.SetUserAccessToken(ValidAccessToken);
        }
    }
}
