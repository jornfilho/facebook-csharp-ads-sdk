using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_integration_test._Utils.WebRequests
{
    [TestClass]
    public class GetAsyncTest : TestBase
    {
        [TestMethod]
        public async Task CatMakeRequestsWithFullData()
        {
            string result = await Request.GetAsync(ValidUri, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData()
        {
            string result = await Request.GetAsync(ValidUri, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }
    }
}
