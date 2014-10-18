using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetAccessToken : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetInvalidAccessToken_1()
        {
            repositoryFacebookSession.SetAccessToken(InvalidAccessToken1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetInvalidAccessToken_2()
        {
            repositoryFacebookSession.SetAccessToken(InvalidAccessToken2);
        }

        [TestMethod]
        public void CanSetAccessToken()
        {
            repositoryFacebookSession.SetAccessToken(ValidAccessToken);
        }
    }
}
