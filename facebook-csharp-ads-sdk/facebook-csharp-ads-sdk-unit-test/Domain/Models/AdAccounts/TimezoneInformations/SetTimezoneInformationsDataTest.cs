using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.TimezoneInformations
{
    [TestClass]
    public class SetTimezoneInformationsDataTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidTimezoneId_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .SetTimezoneInformationsData(InvalidTimezoneId1, ValidTimezoneName, ValidTimezoneOffsetHoursFromUtc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidTimezoneId_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .SetTimezoneInformationsData(InvalidTimezoneId2, ValidTimezoneName, ValidTimezoneOffsetHoursFromUtc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidTimezoneName_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .SetTimezoneInformationsData(ValidTimezoneId, InvalidTimezoneName1, ValidTimezoneOffsetHoursFromUtc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidTimezoneName_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .SetTimezoneInformationsData(ValidTimezoneId, InvalidTimezoneName2, ValidTimezoneOffsetHoursFromUtc);
        }

        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .SetTimezoneInformationsData(ValidTimezoneId, ValidTimezoneName, ValidTimezoneOffsetHoursFromUtc);
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.TimezoneId, ValidTimezoneId);
            Assert.AreEqual(model.TimezoneName,ValidTimezoneName);
            Assert.AreEqual(model.TimezoneOffsetHoursUtc, ValidTimezoneOffsetHoursFromUtc);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
