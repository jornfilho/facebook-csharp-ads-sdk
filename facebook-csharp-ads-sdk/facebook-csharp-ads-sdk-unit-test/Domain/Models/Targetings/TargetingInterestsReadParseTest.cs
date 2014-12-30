using System.Linq;
using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.Targetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.Targetings
{
    [TestClass]
    public class TargetingInterestsReadParseTest
    {
        private const string FacebookResponse =
            "{\"data\":[{\"id\":\"6003087413192\",\"name\":\"Baseball\",\"audience_size\":193841840,\"path\":[\"Sports and outdoors\",\"Sports\",\"Baseball\"],\"description\":null},{\"id\":\"6003195136898\",\"name\":\"Major League Baseball\",\"audience_size\":86442650,\"path\":[],\"description\":null}]}";

        private const string FacebookErrorResponse =
            "{'error':{'message':'An error occurred','type':'GraphMethodException','code':999}}";

        [TestMethod]
        public void MustParseFacebookResponseErrorCorretly()
        {
            TargetingUserDevice userDevice = new TargetingUserDevice();
            BaseObjectsList<TargetingUserDevice> parseResult = userDevice.ParseMultipleResponse(FacebookErrorResponse);

            Assert.IsNotNull(parseResult);
            Assert.IsNull(parseResult.Data);
            Assert.IsFalse(parseResult.IsValid);
        }

        [TestMethod]
        public void MustParseTargetingInterestsCorretlyIfFacebookResponseCorretly()
        {
            TargetingInterests targeting = new TargetingInterests();

            BaseObjectsList<TargetingInterests> parseResult = targeting.ParseMultipleResponse(FacebookResponse);

            Assert.IsNotNull(parseResult);
            Assert.IsNotNull(parseResult.Data);
            Assert.AreEqual(2, parseResult.Data.Count);
            Assert.IsTrue(parseResult.Data.Any(u => u.Path.Count() == 3));
            Assert.IsTrue(parseResult.Data.Any(u => u.Path != null && u.Path.Contains("Sports and outdoors")));
        }
    }
}