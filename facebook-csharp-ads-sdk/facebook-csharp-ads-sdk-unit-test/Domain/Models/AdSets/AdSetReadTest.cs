using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    [TestClass]
    public class AdSetReadTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;
        private long adSetId = 8789987987;
        private List<AdSetReadFieldsEnum> fieldsToRead = new List<AdSetReadFieldsEnum>
                                                         {
                                                             AdSetReadFieldsEnum.AccountId,
                                                             AdSetReadFieldsEnum.BidInfo
                                                         };

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
        public void TesteCreate()
        {
            var facebookSession = new FacebookSessionRepository();
            facebookSession.SetUserAccessToken(
                "CAADMSrKzEFUBAIpm5GqBA4fNNXNYdTZBqJtKxks0QSBt3k3ZBUsPLQhZB7DFvVKLZA4mZCjOTzIsJ7wx4rCZBs6ZAWrbn6GrqmMeTJZC24C46fYG764KzHAyqBQoc7PSW4SUgKFOdm8h8pdvhBwN3FLyLuqfxQhtfMndeWPl4JEOw2ZBZC426GfQuV22KPGPQJsaAL3m1i8yDH2fhVS3UAIHXe");

            var adSet = new AdSet(new AdSetRepository(facebookSession)).ReadSingle(6021503160588, new List<AdSetReadFieldsEnum> { AdSetReadFieldsEnum.Name, AdSetReadFieldsEnum.BidType });
        }
    }
}
