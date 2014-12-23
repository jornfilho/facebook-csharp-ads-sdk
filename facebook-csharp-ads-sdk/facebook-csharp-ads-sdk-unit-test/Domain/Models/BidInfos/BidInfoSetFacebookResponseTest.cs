using facebook_csharp_ads_sdk.Domain.Enums.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.BidInfos
{
    /// <summary>
    ///     Unit test for the BidInfo class
    /// </summary>
    [TestClass]
    public class BidInfoSetFacebookResponseTest
    {
        private BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Actions;
        private int bidInfoValue = 10;

        [TestMethod]
        public void ShouldNotBetSetAttributesIfBidInfoObjectiveTypeUndefined()
        {
            this.bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Undefined;
            facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo bidInfo = new facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo().SetAttributesFromFacebookResponse(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.IsNull(bidInfo.Objective);
            Assert.IsNull(bidInfo.Value);
        }

        [TestMethod]
        public void ShouldNotBetSetAttributesIfBidInfoValueLessThanZero()
        {
            this.bidInfoValue = -1;
            facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo bidInfo = new facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo().SetAttributesFromFacebookResponse(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.IsNull(bidInfo.Objective);
            Assert.IsNull(bidInfo.Value);
        }

        [TestMethod]
        public void ShouldBetSetAttributesIfBidInfoObjectiveTypeAndValueCorrect()
        {
            facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo bidInfo = new facebook_csharp_ads_sdk.Domain.Models.Global.BidInfo().SetAttributesFromFacebookResponse(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(this.bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(this.bidInfoValue, bidInfo.Value);
        }
    }
}
