using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetDefaultApplicationTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CatSetApplicationDataBecauseAppIdIsInvalid()
        {
            repositoryFacebookSession.SetDefaultApplication(InvalidAppId, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetApplicationDataBecauseAppSecretIsInvalid_1()
        {
            repositoryFacebookSession.SetDefaultApplication(ValidAppId, InvalidAppSecret1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetApplicationDataBecauseAppSecretIsInvalid_2()
        {
            repositoryFacebookSession.SetDefaultApplication(ValidAppId, InvalidAppSecret2);
        }

        [TestMethod]
        public void CanSetApplicationData()
        {
            repositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);
        }
    }
}
