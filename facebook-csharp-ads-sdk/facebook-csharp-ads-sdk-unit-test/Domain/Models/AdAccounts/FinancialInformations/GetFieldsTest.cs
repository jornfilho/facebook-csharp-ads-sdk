using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class GetFieldsTest : TestBase
    {
        [TestMethod]
        public void CanGetAdAccountBusinessInformationsFieldsList()
        {
            var fields = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .GetFields();
            
            Assert.IsNotNull(fields);
            Assert.IsTrue(fields.Any());
        }
    }
}
