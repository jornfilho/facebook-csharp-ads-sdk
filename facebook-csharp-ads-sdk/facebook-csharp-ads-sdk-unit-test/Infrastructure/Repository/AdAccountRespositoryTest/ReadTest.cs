using System;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
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
            repositoryAdAccount = new AdAccountRespository(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantReadAccountDataWhenSendInvalidAccountId()
        {
            AdAccount adAccount = await repositoryAdAccount.Read(InvalidAccountId, null);
        }
    }
}
