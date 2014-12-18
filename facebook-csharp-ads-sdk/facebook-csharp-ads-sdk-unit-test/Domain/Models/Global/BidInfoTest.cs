using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.Global
{
    /// <summary>
    ///     Unit test for the BidInfo class
    /// </summary>
    [TestClass]
    public class BidInfoTest
    {
        private BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Actions;
        private int bidInfoValue = 10;

        [TestMethod]
        public void ShouldNotBetSetAttributesIfBidInfoObjectiveTypeUndefined()
        {
            this.bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Undefined;
            BidInfo bidInfo = new BidInfo().SetAttributes(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.IsNull(bidInfo.Objective);
            Assert.IsNull(bidInfo.Value);
        }

        [TestMethod]
        public void ShouldNotBetSetAttributesIfBidInfoValueLessThanZero()
        {
            this.bidInfoValue = -1;
            BidInfo bidInfo = new BidInfo().SetAttributes(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.IsNull(bidInfo.Objective);
            Assert.IsNull(bidInfo.Value);
        }

        [TestMethod]
        public void ShouldBetSetAttributesIfBidInfoObjectiveTypeAndValueCorrect()
        {
            BidInfo bidInfo = new BidInfo().SetAttributes(this.bidInfoObjectiveTypeEnum, this.bidInfoValue);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(this.bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(this.bidInfoValue, bidInfo.Value);
        }
    }
}
