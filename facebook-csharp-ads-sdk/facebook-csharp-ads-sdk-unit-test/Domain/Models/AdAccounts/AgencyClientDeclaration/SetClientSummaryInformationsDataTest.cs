using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AgencyClientDeclaration
{
    [TestClass]
    public class SetClientSummaryInformationsDataTest : TestBase
    {
        [TestMethod]
        public void CanSetClientSummaryInformationsData_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientSummaryInformationsData(false, false, false, false);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CanSetClientSummaryInformationsData_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientSummaryInformationsData(true, false, false, false);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CanSetClientSummaryInformationsData_3()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientSummaryInformationsData(false, true, false, false);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CanSetClientSummaryInformationsData_4()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientSummaryInformationsData(false, false, true, false);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CanSetClientSummaryInformationsData_5()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientSummaryInformationsData(false, false, false, true);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }
    }
}
