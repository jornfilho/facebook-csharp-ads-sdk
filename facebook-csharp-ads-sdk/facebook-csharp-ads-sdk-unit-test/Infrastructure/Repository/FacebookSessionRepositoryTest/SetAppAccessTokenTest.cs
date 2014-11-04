using facebook_csharp_ads_sdk.Domain.Exceptions.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetAppAccessTokenTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAppAccessToken))]
        public void CatSetInvalidAppAccessToken_1()
        {
            RepositoryFacebookSession.SetAppAccessToken(InvalidAccessToken1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAppAccessToken))]
        public void CatSetInvalidAppAccessToken_2()
        {
            RepositoryFacebookSession.SetAppAccessToken(InvalidAccessToken2);
        }

        [TestMethod]
        public void CanSetAppAccessToken()
        {
            RepositoryFacebookSession.SetAppAccessToken(ValidAccessToken);
        }
    }
}
