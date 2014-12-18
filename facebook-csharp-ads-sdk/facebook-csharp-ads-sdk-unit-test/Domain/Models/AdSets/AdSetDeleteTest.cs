using System;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdSets
{
    /// <summary>
    ///     Unit test of the ad set delete method
    /// </summary>
    [TestClass]
    public class AdSetDeleteTest
    {
        private Mock<IAdSetRepository> mockAdSetRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.mockAdSetRepository = new Mock<IAdSetRepository>();
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteAdSetIfIdInvalid()
        {
            var adSet = new AdSet(this.mockAdSetRepository.Object);

            bool successDelete = adSet.Delete(0);
            this.mockAdSetRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.Never);
            Assert.IsFalse(successDelete);
        }

        [TestMethod]
        public void ShouldReturnFalseToDeleteAdSetIfIdAnExceptionThrow()
        {
            this.mockAdSetRepository.Setup(m => m.Delete(It.IsAny<long>())).Throws(new Exception());
            var adSet = new AdSet(this.mockAdSetRepository.Object);

            bool successDelete = adSet.Delete(10);
            this.mockAdSetRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.AtLeastOnce);
            Assert.IsFalse(successDelete);
        }

        [TestMethod]
        public void ShouldSetInvalidAdSetToUpdateToDeleteAdSet()
        {
            this.mockAdSetRepository.Setup(m => m.Delete(It.IsAny<long>())).Returns(Task.FromResult(true));
            var adSet = new AdSet(this.mockAdSetRepository.Object);

            bool successDelete = adSet.Delete(10);
            this.mockAdSetRepository.Verify(m => m.Delete(It.IsAny<long>()), Times.AtLeastOnce);
            Assert.IsTrue(successDelete);
            Assert.IsFalse(adSet.UpdateModelIsReady);
        }
    }
}