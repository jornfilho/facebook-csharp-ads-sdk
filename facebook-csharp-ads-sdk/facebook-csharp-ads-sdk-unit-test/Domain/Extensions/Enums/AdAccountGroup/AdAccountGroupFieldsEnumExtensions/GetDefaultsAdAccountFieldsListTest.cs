using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccountGroup.AdAccountGroupFieldsEnumExtensions
{
    [TestClass]
    public class GetDefaultsAdAccountFieldsListTest
    {
        [TestMethod]
        public void CanGetDefaultAdAccountGroupFieldsList()
        {
            var defaultFields = facebook_csharp_ads_sdk.Domain.Extensions.Enums
                .AdAccountGroup
                .AdAccountGroupFieldsEnumExtensions
                .GetDefaultsAdAccountGroupFieldsList();


            var baseList = new List<AdAccountGroupFieldsEnum>
            {
                AdAccountGroupFieldsEnum.AccountGroupId,
                AdAccountGroupFieldsEnum.Name,
                AdAccountGroupFieldsEnum.Status
            };

            Assert.AreEqual(baseList.Count, defaultFields.Count);

            foreach (var item in baseList)
                Assert.IsTrue(defaultFields.Any(d => d.Equals(item)));
        }
    }
}
