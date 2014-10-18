using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk._Utils.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test._Utils.WebRequests
{
    [TestClass]
    public class PostAsyncTest
    {
        private IRequest Request { get; set; }
        private string ValidUri { get; set; }
        private string InvalidUri { get; set; }
        private NameValueCollection EmptyNameValueCollection { get; set; }
        private NameValueCollection SingleValueNameValueCollection { get; set; }
        private NameValueCollection MultipleValuesNameValueCollection { get; set; }

        [TestInitialize]
        public void InitializeTest()
        {
            Request = new Request();

            ValidUri = "http://private-5eeb3-fbcsharpadssdkbasicendpoint.apiary-mock.com/basic";
            InvalidUri = "";

            EmptyNameValueCollection = new NameValueCollection();
            SingleValueNameValueCollection = new NameValueCollection {{"param1", "value1"}};
            MultipleValuesNameValueCollection = new NameValueCollection
            {
                {"param1", "value1"},
                {"param2", "value2"},
                {"param3", "value3"}
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_1()
        {
            await Request.PostAsync(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_2()
        {
            await Request.PostAsync(InvalidUri,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_1()
        {
            await Request.PostAsync(InvalidUri, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_2()
        {
            await Request.PostAsync(InvalidUri, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_1()
        {
            await Request.PostAsync(ValidUri, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_2()
        {
            await Request.PostAsync(ValidUri, null, -1000);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_1()
        {
            string result = await Request.PostAsync(ValidUri, null, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_2()
        {
            string result = await Request.PostAsync(ValidUri, EmptyNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_3()
        {
            string result = await Request.PostAsync(ValidUri, SingleValueNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData_4()
        {
            string result = await Request.PostAsync(ValidUri, MultipleValuesNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_1()
        {
            string result = await Request.PostAsync(ValidUri, null, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_2()
        {
            string result = await Request.PostAsync(ValidUri, EmptyNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_3()
        {
            string result = await Request.PostAsync(ValidUri, SingleValueNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData_4()
        {
            string result = await Request.PostAsync(ValidUri, MultipleValuesNameValueCollection, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }
    }
}
