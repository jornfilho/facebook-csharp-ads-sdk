using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.BidInfos
{
    [TestClass]
    public class BidInfoSetCreateDataTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetBidTypeException))]
        public void MustThrowExceptionIfBidTypeUndefined()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Undefined, BidInfoObjectiveTypeEnum.Clicks, 10);
        }

        #region CPM

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoObjectiveForBidTypeCpmException))]
        public void MustThrowExceptionIfBidTypeCpmAndBidInfoObjectiveNotImpressions()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpm, BidInfoObjectiveTypeEnum.Clicks, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeCpmException))]
        public void MustThrowExceptionIfBidTypeCpmAndBidInfoObjectiveImpressionsAndValueLessThan2Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpm, BidInfoObjectiveTypeEnum.Impressions, 1);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeCpm()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.Cpm;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Impressions;
            const int value = 3;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);

            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        #endregion CPM

        #region CPC

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoObjectiveForBidTypeCpcException))]
        public void MustThrowExceptionIfBidTypeCpcAndBidInfoObjectiveNotClicks()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpc, BidInfoObjectiveTypeEnum.Impressions, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeCpcException))]
        public void MustThrowExceptionIfBidTypeCpcAndBidInfoObjectiveClicksAndValueLessThan1Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpc, BidInfoObjectiveTypeEnum.Clicks, 0);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeCpc()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.Cpc;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Clicks;
            const int value = 3;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);

            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        #endregion CPC

        #region CPA

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoObjectiveForBidTypeCpaException))]
        public void MustThrowExceptionIfBidTypeCpaAndBidInfoObjectiveNotActions()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpa, BidInfoObjectiveTypeEnum.Impressions, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeCpaException))]
        public void MustThrowExceptionIfBidTypeCpaAndBidInfoObjectiveActionsAndValueLessThan1Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpa, BidInfoObjectiveTypeEnum.Actions, 0);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeCpa()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.Cpa;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Actions;
            const int value = 3;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);

            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        #endregion CPA

        #region OCPM

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoObjectiveForBidTypeOcpmException))]
        public void MustThrowExceptionIfBidTypeOcpmAndBidInfoObjectiveInvalid()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Impressions, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeOcpmException))]
        public void MustThrowExceptionIfBidTypeOcpmAndBidInfoObjectiveActionsAndValueLessThan1Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Actions, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeOcpmException))]
        public void MustThrowExceptionIfBidTypeOcpmAndBidInfoObjectiveReachAndValueLessThan2Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Reach, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeOcpmException))]
        public void MustThrowExceptionIfBidTypeOcpmAndBidInfoObjectiveClicksAndValueLessThan1Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Reach, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBidInfoValueForBidTypeOcpmException))]
        public void MustThrowExceptionIfBidTypeOcpmAndBidInfoObjectiveSocialAndValueLessThan1Cents()
        {
            new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Social, 0);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeOcpmAndBidInfoObjectiveActions()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.AbsoluteOcpm;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Actions;
            const int value = 10;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeOcpmAndBidInfoObjectiveReach()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.AbsoluteOcpm;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Reach;
            const int value = 10;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeOcpmAndBidInfoObjectiveClicks()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.AbsoluteOcpm;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Clicks;
            const int value = 10;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        [TestMethod]
        public void MustSetDataToCreateIfDataCorrectWithBidTypeOcpmAndBidInfoObjectiveSocial()
        {
            const AdSetBidTypeEnum adSetBidTypeEnum = AdSetBidTypeEnum.AbsoluteOcpm;
            const BidInfoObjectiveTypeEnum bidInfoObjectiveTypeEnum = BidInfoObjectiveTypeEnum.Social;
            const int value = 10;

            BidInfo bidInfo = new BidInfo().SetAttributesToCreate(adSetBidTypeEnum, bidInfoObjectiveTypeEnum, value);
            Assert.IsNotNull(bidInfo);
            Assert.AreEqual(bidInfoObjectiveTypeEnum, bidInfo.Objective);
            Assert.AreEqual(value, bidInfo.Value);
        }

        #endregion OCPM
    }
}
