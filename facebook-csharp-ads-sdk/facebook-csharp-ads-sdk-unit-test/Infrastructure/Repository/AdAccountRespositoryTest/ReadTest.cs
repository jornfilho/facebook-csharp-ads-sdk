using System;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Infrastructure.Repository.AdAccountRespositoryTest
{
    [TestClass]
    public class ReadTest : TestBase
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantCreateARepositoryInstanceWhenSendInvalidFacebookSessionOnConstructor()
        {
            RepositoryAdAccount = new AdAccountRespository(null);
        }
    }
}
