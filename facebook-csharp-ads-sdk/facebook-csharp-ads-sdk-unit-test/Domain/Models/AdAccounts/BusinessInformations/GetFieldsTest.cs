using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.BusinessInformations
{
    [TestClass]
    public class GetFieldsTest
    {
        [TestMethod]
        public void CanGetAdAccountBusinessInformationsFieldsList()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            var fields = model.GetFields();
            
            Assert.IsNotNull(fields);
            Assert.IsTrue(fields.Any());
        }
    }
}
