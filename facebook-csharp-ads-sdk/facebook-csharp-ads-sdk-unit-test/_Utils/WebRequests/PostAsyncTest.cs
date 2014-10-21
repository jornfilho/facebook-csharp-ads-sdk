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
            await Request.Object.PostAsync(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_2()
        {
            await Request.Object.PostAsync(InvalidUri,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_1()
        {
            await Request.Object.PostAsync(InvalidUri, null, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_1()
        {
            await Request.Object.PostAsync(ValidUri, null, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_2()
        {
            await Request.Object.PostAsync(ValidUri, null, InvalidRequestTimeout2);
        }
    }
}
