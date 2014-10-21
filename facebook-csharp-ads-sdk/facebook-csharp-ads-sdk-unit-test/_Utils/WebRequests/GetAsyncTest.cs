using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test._Utils.WebRequests
{
    [TestClass]
    public class GetAsyncTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_1()
        {
            await Request.Object.GetAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnFullMethod_2()
        {
            await Request.Object.GetAsync(InvalidUri);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CantSendEmptyUriOnBasicMethod_1()
        {
            await Request.Object.GetAsync(InvalidUri, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_1()
        {
            await Request.Object.GetAsync(ValidUri, InvalidRequestTimeout1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task CantSendInvalidTimeoutOnFullMethod_2()
        {
            await Request.Object.GetAsync(ValidUri, InvalidRequestTimeout2);
        }
    }
}
