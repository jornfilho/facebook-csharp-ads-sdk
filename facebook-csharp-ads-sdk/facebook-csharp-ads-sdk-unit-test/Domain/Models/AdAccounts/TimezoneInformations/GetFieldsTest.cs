using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.TimezoneInformations
{
    [TestClass]
    public class GetFieldsTest : TestBase
    {
        [TestMethod]
        public void CanGetTimezoneInformationsFieldsList()
        {
            var fields = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .TimezoneInformations()
                .GetFields();

            Assert.IsNotNull(fields);
            Assert.IsTrue(fields.Any());
        }
    }
}
