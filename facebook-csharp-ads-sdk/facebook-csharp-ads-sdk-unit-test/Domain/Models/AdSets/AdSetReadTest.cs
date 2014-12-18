using System.Collections.Generic;
using System.Linq;
using DevUtils.DateTimeExtensions;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class AdSetReadTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;
        private readonly List<AdSetReadFieldsEnum> fieldsToRead = new List<AdSetReadFieldsEnum>
                                                         {
                                                             AdSetReadFieldsEnum.AccountId,
                                                             AdSetReadFieldsEnum.AdCampaignId,
                                                             AdSetReadFieldsEnum.BidInfo,
                                                             AdSetReadFieldsEnum.BidType,
                                                             AdSetReadFieldsEnum.BudgetRemaining,
                                                             AdSetReadFieldsEnum.CreateTime,
                                                             AdSetReadFieldsEnum.DailyBudget,
                                                             AdSetReadFieldsEnum.EndTime,
                                                             AdSetReadFieldsEnum.Id,
                                                             AdSetReadFieldsEnum.LifetimeBudget,
                                                             AdSetReadFieldsEnum.Name,
                                                             AdSetReadFieldsEnum.PromotedObject,
                                                             AdSetReadFieldsEnum.StartTime,
                                                             AdSetReadFieldsEnum.Status,
                                                             AdSetReadFieldsEnum.Targeting,
                                                             AdSetReadFieldsEnum.UpdatedTime
                                                         };

        private const long AccountId = 564564564;
        private const long CampaignId = 2133132132;
        private long adSetId = 8789987987;
        private const string AdSetName = "ad set 1";
        private const string BidInfoType1 = "ACTIONS";
        private const string BidInfoType2 = "CLICKS";
        private const int BidInfoValue = 6000;
        private const string BidType = "ABSOLUTE_OCPM";
        private const int BudgetRemaining = 512;
        private const int DailyBudget = 1000;
        private const int LifetimeBudget = 12;
        private const long CreateTimeTimestamp = 1418910135;
        private const long StartTimeTimestamp = 1418910135;
        private const long EndTimeTimestamp = 1418910300;
        private const long UpdatedTimeTimestamp = 1418910135;
        private const string Targeting = "{'age_max':65,'age_min':18,'geo_locations':{'countries':['BR']},'user_os':['Android']}";
        private const string Status = "ACTIVE";
        private const long ApplicationId = 321113213;
        private const string ObjectStoreUrl = "www.facebook.com";

        [TestInitialize]
        public void Initialize()
        {
            mockAdSetRepository = new Mock<IAdSetRepository>();
        }

        [TestMethod]
        public void ShouldNotCallAdSetRepositoryReadMethodWithoutFieldsIfAdSetIdInvalid()
        {
            adSetId = 0;
            var adSetRead = new AdSet(mockAdSetRepository.Object);
            adSetRead.ReadSingle(adSetId);

            mockAdSetRepository.Verify(m => m.Read(It.IsAny<long>()), Times.Never);
        }

        [TestMethod]
        public void ShouldNotCallAdSetRepositoryReadMethodWithFieldsIfAdSetIdInvalid()
        {
            adSetId = 0;
            var adSetRead = new AdSet(mockAdSetRepository.Object);
            adSetRead.ReadSingle(adSetId, fieldsToRead);

            mockAdSetRepository.Verify(m => m.Read(It.IsAny<long>(), It.IsAny<IList<AdSetReadFieldsEnum>>()), Times.Never);
        }

        [TestMethod]
        public void ShouldBeParseFacebookResponseWithAllFields()
        {
            string facebookResponse =
                "{'account_id':'" + AccountId + "'," +
                "'campaign_group_id':'" + CampaignId + "'," +
                "'bid_info':{'" + BidInfoType1 + "':" + BidInfoValue + ",'" + BidInfoType2 + "':" + BidInfoValue + "}," +
                "'bid_type':'" + BidType + "'," +
                "'budget_remaining':" + BudgetRemaining + "," +
                "'daily_budget':" + DailyBudget + "," +
                "'id':'" + this.adSetId + "'," +
                "'lifetime_budget': " + LifetimeBudget + "," +
                "'name':'" + AdSetName + "'," +
                "'created_time':" + CreateTimeTimestamp + "," +
                "'start_time':" + StartTimeTimestamp + "," +
                "'end_time':" + EndTimeTimestamp + "," +
                "'updated_time':" + UpdatedTimeTimestamp + "," +
                "'campaign_status':'" + Status + "'," +
                "'targeting':" + Targeting + "," +
                "'promoted_object': {'application_id' : '" + ApplicationId + "', 'object_store_url': '" + ObjectStoreUrl + "'}}";

            var facebookResponseJObject = JObject.Parse(facebookResponse);
            var adSetReaded = new AdSet(this.mockAdSetRepository.Object);
            adSetReaded.ParseReadSingleResponse(facebookResponse);

            Assert.IsNotNull(adSetReaded);
            Assert.AreEqual(AccountId, adSetReaded.AccountId);
            Assert.AreEqual(CampaignId, adSetReaded.AdCampaignId);
            Assert.AreEqual(2, adSetReaded.BidInfo.Count);
            Assert.IsTrue(adSetReaded.BidInfo.Any(b => b.Objective == BidInfoType1.GetBidInfoType()));
            Assert.IsTrue(adSetReaded.BidInfo.Any(b => b.Objective == BidInfoType2.GetBidInfoType()));
            Assert.IsTrue(adSetReaded.BidInfo.All(b => b.Value == BidInfoValue));
            Assert.AreEqual(BidInfoValue, adSetReaded.BidInfo[0].Value);
            Assert.AreEqual(BidType.GetAdSetBidType(), adSetReaded.BidType);
            Assert.AreEqual(BudgetRemaining, adSetReaded.BudgetRemaining);
            Assert.AreEqual(DailyBudget, adSetReaded.DailyBudget);
            Assert.AreEqual(this.adSetId, adSetReaded.Id);
            Assert.AreEqual(LifetimeBudget, adSetReaded.LifetimeBudget);
            Assert.AreEqual(AdSetName, adSetReaded.Name);
            Assert.AreEqual(Status.GetAdSetStatus(), adSetReaded.Status);
            Assert.AreEqual(JsonConvert.SerializeObject(facebookResponseJObject["targeting"]), adSetReaded.Targeting);
            Assert.AreEqual(ApplicationId, adSetReaded.PromotedObject.ApplicationId);
            Assert.AreEqual(ObjectStoreUrl, adSetReaded.PromotedObject.ObjectStoreUrl);
            Assert.AreEqual(CreateTimeTimestamp.FromUnixTimestamp(), adSetReaded.CreatedTime);
            Assert.AreEqual(StartTimeTimestamp.FromUnixTimestamp(), adSetReaded.StartTime);
            Assert.AreEqual(EndTimeTimestamp.FromUnixTimestamp(), adSetReaded.EndTime);
            Assert.AreEqual(UpdatedTimeTimestamp.FromUnixTimestamp(), adSetReaded.UpdatedTime);
        }
    }
}
