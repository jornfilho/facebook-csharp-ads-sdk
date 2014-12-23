using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class AdSetSetCreateDataTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;
        private string name;
        private long accountId;
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
            this.accountId = 132456789;
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
            this.targeting = "{'flexible_spec':[],'exclusions':{},'geo_locations':{'countries':['BR'],'regions':[],'cities':[],'zips':[]},'excluded_geo_locations':{'countries':[],'regions':[],'cities':[],'zips':[]},'age_min':13,'age_max':65,'page_types':['desktopfeed']}";
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
                .SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
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
        [ExpectedException(typeof(StartDateMustBeGreatherThanUtcNowException))]
        public void MustThrowExceptionToSetCreateDataIfStartTimeIsGreaterThanUtcNow()
        {
            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
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
                .SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);

            Assert.IsNotNull(adSet);
            Assert.IsNotNull(adSet.LifetimeBudget);
            Assert.AreEqual(300, adSet.LifetimeBudget);
        }

        [TestMethod]
        public void MustSetInvalidDataIfModelNotReadyToCreate()
        {
            this.mockAdSetRepository.Setup(m => m.Create(It.IsAny<AdSet>()))
                .Returns(Task.FromResult(new AdSet(this.mockAdSetRepository.Object)));

            var adSet = new AdSet(this.mockAdSetRepository.Object);
            try
            {
                this.lifetimeBudget = 290;
                this.dailyBudget = null;

                this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
                this.endTime = new DateTime(2014, 1, 3, 12, 0, 0);
                adSet.SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);
            }
            catch (Exception)
            { }

            adSet.Create();
            this.mockAdSetRepository.Verify(m => m.Create(It.IsAny<AdSet>()), Times.Never);
            Assert.IsFalse(adSet.IsValid);
        }

        [TestMethod]
        public void MustCallRepositoryIfModelIsReadyToCreate()
        {
            this.mockAdSetRepository.Setup(m => m.Create(It.IsAny<AdSet>()))
                .Returns(Task.FromResult(new AdSet(this.mockAdSetRepository.Object)));

            var adSet = new AdSet(this.mockAdSetRepository.Object);
            try
            {
                adSet.SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);
            }
            catch (Exception)
            { }

            adSet.Create();
            this.mockAdSetRepository.Verify(m => m.Create(It.IsAny<AdSet>()), Times.AtLeastOnce);
        }

        #region Private methods
        
        private void SetAdSetDataToCreateForThrowException()
        {
            new AdSet(this.mockAdSetRepository.Object)
                .SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget,
                    this.executionOptionsList, this.lifetimeBudget, this.startTime, this.endTime, this.adCampaignId,
                    this.redownload, this.targeting, this.promotedObject);
        }

        #endregion Private methods

        [TestMethod]
        public void Teste()
        {
            var facebookSession = new FacebookSessionRepository();
            facebookSession.SetUserAccessToken(
                "CAADMSrKzEFUBAIpm5GqBA4fNNXNYdTZBqJtKxks0QSBt3k3ZBUsPLQhZB7DFvVKLZA4mZCjOTzIsJ7wx4rCZBs6ZAWrbn6GrqmMeTJZC24C46fYG764KzHAyqBQoc7PSW4SUgKFOdm8h8pdvhBwN3FLyLuqfxQhtfMndeWPl4JEOw2ZBZC426GfQuV22KPGPQJsaAL3m1i8yDH2fhVS3UAIHXe");

            var adSet = new AdSet(new AdSetRepository(facebookSession));
            this.bidInfo = new List<BidInfo>
                           {
                               new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Actions, 10),
                               new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Reach, 10),
                               new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Clicks, 10),
                               new BidInfo().SetAttributesToCreate(AdSetBidTypeEnum.AbsoluteOcpm, BidInfoObjectiveTypeEnum.Social, 10)
                           };

            this.accountId = 100690260075287;
            this.adCampaignId = 6021626814588;
            this.bidType = AdSetBidTypeEnum.AbsoluteOcpm;
            this.startTime = DateTime.UtcNow.AddDays(1);
            this.endTime = DateTime.UtcNow.AddDays(2);

            //AdCampaign adCampaign = new AdCampaign(new AdCampaignRepository(facebookSession)).ReadSingle(6021626814588);
            //adCampaign.SetUpdateData(string.Empty, AdCampaignObjectiveEnum.WebsiteConversions, null, null);

            //adCampaign.Update();

            long pixelId = 6018736758788;

            this.promotedObject = new PromotedObject().SetDataToCreate(AdCampaignObjectiveEnum.WebsiteConversions, pixelId, string.Empty);

            //this.executionOptionsList = new List<ExecutionOptionsEnum> { ExecutionOptionsEnum.ValidateOnly };

            adSet.SetCreateData(this.accountId, this.name, this.bidType, this.bidInfo, this.status, this.dailyBudget, this.executionOptionsList, null,
                this.startTime, this.endTime, this.adCampaignId, null,
                this.targeting, this.promotedObject);

            adSet.Create();
        }
    }
}
