using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using facebook_csharp_ads_sdk.Domain.Models.Global;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class AdSetUpdateTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;

        private AdSetUpdateData updateData;
        private AdSetBidTypeEnum? bidType;
        private List<BidInfo> bidInfoList;
        private AdSetStatusEnum? status;
        private int? dailyBudget;
        private int? lifetimeBudget;
        private string name;
        private DateTime? startTime;
        private DateTime? endTime;
        private string targeting;
        private IList<ExecutionOptionsEnum> executionOptionsList;

        [TestInitialize]
        public void Initialize()
        {
            mockAdSetRepository = new Mock<IAdSetRepository>();
            bidType = null;
            bidInfoList = null;
            status = null;
            dailyBudget = null;
            lifetimeBudget = null;
            name = null;
            startTime = null;
            endTime = null;
            targeting = null;
            executionOptionsList = null;
        }

        [TestMethod]
        public void MustSetInvalidUpdateModelIfNoPropertyUpdated()
        {
            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);

            Assert.IsNotNull(adSetToUpdate);
            Assert.IsFalse(adSetToUpdate.UpdateModelIsReady);
        }

        [TestMethod]
        public void MustSetInvalidUpdateModelIfAdSetUpdateDataNull()
        {
            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(null, executionOptionsList);

            Assert.IsNotNull(adSetToUpdate);
            Assert.IsFalse(adSetToUpdate.UpdateModelIsReady);
        }

        [TestMethod]
        [ExpectedException(typeof(LifetimeBudgetMustBeGreaterThan100CentsPerDayException))]
        public void MustThrowExceptionToSetUpdateDataIfLifetimeBudgetLessThan100CentsPerDay()
        {
            this.lifetimeBudget = 290;
            this.dailyBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 3, 12, 0, 0);

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        [TestMethod]
        [ExpectedException(typeof(DailyBudgetMustBeGreaterThan100CentsException))]
        public void MustThrowExceptionToSetUpdateDataIfDailyBudgetLessThan100Cents()
        {
            this.dailyBudget = 99;
            this.lifetimeBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 2, 13, 0, 0);

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferenceWithStartTimeAndEndTimeMustBe24HoursException))]
        public void MustThrowExceptionToSetUpdateDataIfAdCampaignIsDailyBudgetAndDifferenceWithStartTimeAndEndTimeLessThan24Hours()
        {
            this.dailyBudget = 100;
            this.lifetimeBudget = null;

            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);
            this.endTime = new DateTime(2014, 1, 1, 13, 0, 0);

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeRequiredInLifetimeBudgetException))]
        public void MustThrowExceptionToSetUpdateDataIfAdCampaignIsLifetimeBudgetAndEndTimeNull()
        {
            this.dailyBudget = null;
            this.lifetimeBudget = 100;
            this.endTime = null;

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        [TestMethod]
        [ExpectedException(typeof(EndTimeMustBeGreaterThanStartTimeException))]
        public void MustThrowExceptionToSetCreateDataIfAdCampaignEndTimeLessThanStartTime()
        {
            this.startTime = new DateTime(2014, 2, 1);
            this.endTime = new DateTime(2014, 1, 1);

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        [TestMethod]
        [ExpectedException(typeof(StartDateMustBeGreatherThanUtcNowException))]
        public void MustThrowExceptionToSetCreateDataIfStartTimeIsGreaterThanUtcNow()
        {
            this.startTime = new DateTime(2014, 1, 1, 12, 0, 0);

            this.InitializeAdSetUpdateData();
            var adSetToUpdate = new AdSet(mockAdSetRepository.Object);
            adSetToUpdate.SetUpdateData(this.updateData, executionOptionsList);
        }

        #region Private methods

        public void InitializeAdSetUpdateData()
        {
            this.updateData = new AdSetUpdateData
                              {
                                  BidInfoList = this.bidInfoList,
                                  BidType = this.bidType,
                                  DailyBudget = this.dailyBudget,
                                  EndTime = this.endTime,
                                  LifetimeBudget = this.lifetimeBudget,
                                  Name = this.name,
                                  StartTime = this.startTime,
                                  Status = this.status,
                                  Targeting = this.targeting
                              };
        }

        #endregion Private methods

        [TestMethod]
        public void Teste()
        {
            var facebookSession = new FacebookSessionRepository();
            facebookSession.SetUserAccessToken(
                "CAADMSrKzEFUBAIpm5GqBA4fNNXNYdTZBqJtKxks0QSBt3k3ZBUsPLQhZB7DFvVKLZA4mZCjOTzIsJ7wx4rCZBs6ZAWrbn6GrqmMeTJZC24C46fYG764KzHAyqBQoc7PSW4SUgKFOdm8h8pdvhBwN3FLyLuqfxQhtfMndeWPl4JEOw2ZBZC426GfQuV22KPGPQJsaAL3m1i8yDH2fhVS3UAIHXe");

            var adSet = new AdSet(new AdSetRepository(facebookSession)).ReadSingle(6021630454788);
            
            var updateData = new AdSetUpdateData
                                         {
                                             Status = AdSetStatusEnum.Active
                                         };

            adSet.SetUpdateData(updateData, null);
            adSet.Update();

        }

    }
}
