using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccounts.AdAccountFieldsExtensions
{
    [TestClass]
    public class GetAdAccountFieldsListTest
    {
        [TestMethod]
        public void CanGetListOfAdAccountFields()
        {
            var fields = facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts.AdAccountFieldsExtensions
                    .GetAdAccountFieldsList();

            Assert.IsNotNull(fields);
            Assert.IsTrue(fields.Any());
        }
    }
}
