using System;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk._Utils.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test._Utils.WebRequests
{
    [TestClass]
    public class GetAsyncTest
    {
        private IRequest Request { get; set; }
        private string ValidUri { get; set; }
        private string InvalidUri { get; set; }

        [TestInitialize]
        public void InitializeTest()
        {
            Request = new Request();

            ValidUri = "http://private-5eeb3-fbcsharpadssdkbasicendpoint.apiary-mock.com/basic";
            InvalidUri = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_1()
        {
            await Request.GetAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_2()
        {
            await Request.GetAsync(InvalidUri);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_1()
        {
            await Request.GetAsync(InvalidUri, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_2()
        {
            await Request.GetAsync(InvalidUri, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_1()
        {
            await Request.GetAsync(ValidUri, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_2()
        {
            await Request.GetAsync(ValidUri, -1000);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithFullData()
        {
            string result = await Request.GetAsync(ValidUri, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }

        [TestMethod]
        public async Task CatMakeRequestsWithBasicData()
        {
            string result = await Request.GetAsync(ValidUri, 1000);
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result));
            Console.WriteLine(result);
        }
    }
}
