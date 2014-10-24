using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetAccessToken : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetInvalidAccessToken_1()
        {
            RepositoryFacebookSession.SetAccessToken(InvalidAccessToken1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetInvalidAccessToken_2()
        {
            RepositoryFacebookSession.SetAccessToken(InvalidAccessToken2);
        }

        [TestMethod]
        public void CanSetAccessToken()
        {
            RepositoryFacebookSession.SetAccessToken(ValidAccessToken);
        }
    }
}
