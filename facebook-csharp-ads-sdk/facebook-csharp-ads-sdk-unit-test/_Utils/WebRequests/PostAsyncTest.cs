using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test._Utils.WebRequests
{
    [TestClass]
    public class PostAsyncTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_1()
        {
            await WebRequest.PostAsync(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_2()
        {
            await WebRequest.PostAsync(InvalidUri,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_1()
        {
            await WebRequest.PostAsync(InvalidUri, null, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_1()
        {
            await WebRequest.PostAsync(ValidUri, null, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_2()
        {
            await WebRequest.PostAsync(ValidUri, null, InvalidRequestTimeout2);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_1()
        {
            string result = await WebRequest.PostAsync(ValidUri, null, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_2()
        {
            string result = await WebRequest.PostAsync(ValidUri, EmptyNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_3()
        {
            string result = await WebRequest.PostAsync(ValidUri, SingleValueNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_4()
        {
            string result = await WebRequest.PostAsync(ValidUri, MultipleValuesNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_1()
        {
            string result = await WebRequest.PostAsync(ValidUri, null, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_2()
        {
            string result = await WebRequest.PostAsync(ValidUri, EmptyNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_3()
        {
            string result = await WebRequest.PostAsync(ValidUri, SingleValueNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_4()
        {
            string result = await WebRequest.PostAsync(ValidUri, MultipleValuesNameValueCollection, ValidRequestTimeout);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }
    }
}
