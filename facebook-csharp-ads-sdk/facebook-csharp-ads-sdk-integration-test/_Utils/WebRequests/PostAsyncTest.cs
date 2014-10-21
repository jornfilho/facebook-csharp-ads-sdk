using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_integration_test._Utils.WebRequests
{
    [TestClass]
    public class PostAsyncTest : TestBase
    {
        [TestMethod]
        public async Task CatMakeRequestsWithFullData_1()
        {
            string result = await Request.PostAsync(ValidUri, null, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_2()
        {
            string result = await Request.PostAsync(ValidUri, EmptyNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_3()
        {
            string result = await Request.PostAsync(ValidUri, SingleValueNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_4()
        {
            string result = await Request.PostAsync(ValidUri, MultipleValuesNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_1()
        {
            string result = await Request.PostAsync(ValidUri, null, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_2()
        {
            string result = await Request.PostAsync(ValidUri, EmptyNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_3()
        {
            string result = await Request.PostAsync(ValidUri, SingleValueNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_4()
        {
            string result = await Request.PostAsync(ValidUri, MultipleValuesNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }
    }
}
