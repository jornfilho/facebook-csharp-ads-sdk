using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.Targetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.Targetings
{
    [TestClass]
    public class TargetingUserDeviceParseTest
    {
        private const string FacebookResponse = "{ 'data': [{ 'name': 'iPad', 'description': 'iPads (all)', 'audience_size': 107437237, 'type': 'user_device' }, { 'name': 'iPhone', 'description': 'iPhones (all)', 'audience_size': 241701983, 'type': 'user_device' }, { 'name': 'iPod', 'description': 'iPods (all)', 'audience_size': 10781306, 'type': 'user_device' }]}";
        private const string FacebookErrorResponse = "{'error':{'message':'An error occurred','type':'GraphMethodException','code':999}}";

        [TestMethod]
        public void MustParseFacebookResponseCorretlyIfFacebookResponseCorretly()
        {
            var userDevice = new TargetingUserDevice();
            BaseObjectsList<TargetingUserDevice> parseResult = userDevice.ParseMultipleResponse(FacebookResponse);

            Assert.IsNotNull(parseResult);
            Assert.IsNotNull(parseResult.Data);
            Assert.AreEqual(3, parseResult.Data.Count);
        }

        [TestMethod]
        public void MustParseFacebookResponseErrorCorretly()
        {
            var userDevice = new TargetingUserDevice();
            BaseObjectsList<TargetingUserDevice> parseResult = userDevice.ParseMultipleResponse(FacebookErrorResponse);

            Assert.IsNotNull(parseResult);
            Assert.IsNull(parseResult.Data);
            Assert.IsFalse(parseResult.IsValid);
        }
    }
}