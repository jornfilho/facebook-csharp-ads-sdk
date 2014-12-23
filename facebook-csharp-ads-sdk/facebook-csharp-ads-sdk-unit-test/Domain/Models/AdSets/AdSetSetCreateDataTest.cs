using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class AdSetSetCreateDataTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;
        private string name;
        private AdSetBidTypeEnum bidType;
        private List<BidInfo> bidInfo;
        private AdSetStatusEnum status;
        private int? dailyBudget;
        private int? lifetimeBudget;
        private IList<ExecutionOptionsEnum> executionOptionsList;
        private DateTime? startTime;
        private DateTime? endTime;
        private long adCampaignId;
        private bool? redownload;
        private string targeting;
        private PromotedObject promotedObject;

        [TestInitialize]
        public void Initialize()
        {
            this.mockAdSetRepository = new Mock<IAdSetRepository>();
            this.name = "ad set name";
            this.bidType = AdSetBidTypeEnum.Cpa;
            this.bidInfo = new List<BidInfo>
                           {
                               new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.Cpc, BidInfoObjectiveTypeEnum.Clicks, 10)
                           };

            this.status = AdSetStatusEnum.Active;
            this.executionOptionsList = null;
            this.dailyBudget = 120;
            this.lifetimeBudget = null;
            this.startTime = new DateTime(2014, 12, 1);
            this.endTime = new DateTime(2014, 12, 3);
            this.adCampaignId = 45546546546;
            this.redownload = null;
            this.targeting = "{}";
            this.promotedObject = new PromotedObject();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetNameException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetNameEmpty()
        {
            this.name = string.Empty;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetBidTypeException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetBidType()
        {
            this.bidType = AdSetBidTypeEnum.Undefined;
            this.SetAdSetDataToCreateForThrowException();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetBidInfoException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetBidInfoNull()
        {
            this.bidInfo = null;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetBidInfoDataException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetBidInfoDataInvalid()
        {
            this.bidInfo = new List<BidInfo>{new BidInfo()};
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetStatusException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetStatusUndefined()
        {
            this.status = AdSetStatusEnum.Undefined;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetStatusException))]
        public void MustThrowExceptionToSetCreateDataIfAdSetStatusAdCampaignPaused()
        {
            this.status = AdSetStatusEnum.AdCamnpaignPaused;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(LifetimeBudgetOrDailyBudgetRequiredException))]
        public void MustThrowExceptionToSetCreateDataIfDailyBudgetAndLifetimeBudgetIsNull()
        {
            this.dailyBudget = null;
            this.lifetimeBudget = null;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdCampaignIdException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignIdInvalid()
        {
            this.adCampaignId = -1;
            this.SetAdSetDataToCreateForThrowException();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAdSetTargetingException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignTargetingEmpty()
        {
            this.targeting = string.Empty;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeMustBeGreaterThanStartTimeException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignEndTimeLessThanStartTime()
        {
            this.startTime = new DateTime(2014,2,1);
            this.endTime = new DateTime(2014,1,1);
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(DifferenceWithStartTimeAndEndTimeMustBe24HoursException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignIsDailyBudgetAndDifferenceWithStartTimeAndEndTimeLessThan24Hours()
        {
            this.dailyBudget = 100;
            this.lifetimeBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 1, 13, 0, 0);
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeRequiredInLifetimeBudgetException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignIsLifetimeBudgetAndEndTimeNull()
        {
            this.dailyBudget = null;
            this.lifetimeBudget = 100;

            this.endTime = null;
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        [ExpectedException(typeof(DailyBudgetMustBeGreaterThan100CentsException))]
        public void MustThrowExceptionToSetCreateDataIfDailyBudgetLessThan100Cents()
        {
            this.dailyBudget = 99;
            this.lifetimeBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 2, 13, 0, 0);
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        public void ShouldNotThrowExceptionToSetCreateDataIfDailyBudgetGreaterThan100Cents()
        {
            const int dailyBudgetExpected = 101;

            this.dailyBudget = dailyBudgetExpected;
            this.lifetimeBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 2, 13, 0, 0);

            var adSet = new AdSet(this.mockAdSetRepository.Object)
                .SetCreateData(this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);

            Assert.IsNotNull(adSet);
            Assert.IsNotNull(adSet.DailyBudget);
            Assert.AreEqual(dailyBudgetExpected, adSet.DailyBudget);
        }

        [TestMethod]
        [ExpectedException(typeof(LifetimeBudgetMustBeGreaterThan100CentsPerDayException))]
        public void MustThrowExceptionToSetCreateDataIfLifetimeBudgetLessThan100CentsPerDay()
        {
            this.lifetimeBudget = 290;
            this.dailyBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 3, 12, 0, 0);
            this.SetAdSetDataToCreateForThrowException();
        }

        [TestMethod]
        public void ShouldNotThrowExceptionToSetCreateDataIfLifetimeBudgetGreaterThan100CentsPerDay()
        {
            this.lifetimeBudget = 300;
            this.dailyBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 3, 12, 0, 0);
            
            var adSet = new AdSet(this.mockAdSetRepository.Object)
                .SetCreateData(this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);

            Assert.IsNotNull(adSet);
            Assert.IsNotNull(adSet.LifetimeBudget);
            Assert.AreEqual(300, adSet.LifetimeBudget);
        }

        #region Private methods
        
        private void SetAdSetDataToCreateForThrowException()
        {
            new AdSet(this.mockAdSetRepository.Object)
                .SetCreateData(this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);
        }

        #endregion Private methods
    }
}
