using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.FacebookSessionRepositoryTest
{
    [TestClass]
    public class SetDefaultApplicationTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CatSetApplicationDataBecauseAppIdIsInvalid()
        {
            RepositoryFacebookSession.SetDefaultApplication(InvalidAppId, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetApplicationDataBecauseAppSecretIsInvalid_1()
        {
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, InvalidAppSecret1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatSetApplicationDataBecauseAppSecretIsInvalid_2()
        {
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, InvalidAppSecret2);
        }

        [TestMethod]
        public void CanSetApplicationData()
        {
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);
        }
    }
}
