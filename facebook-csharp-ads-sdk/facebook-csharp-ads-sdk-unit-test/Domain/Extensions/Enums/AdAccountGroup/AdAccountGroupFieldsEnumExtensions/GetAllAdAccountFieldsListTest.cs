using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccountGroup.AdAccountGroupFieldsEnumExtensions
{
    [TestClass]
    public class GetAllAdAccountFieldsListTest
    {
        [TestMethod]
        public void CanGetAllAdAccountGroupFieldsList()
        {
            var defaultFields = facebook_csharp_ads_sdk.Domain.Extensions.Enums
                .AdAccountGroup
                .AdAccountGroupFieldsEnumExtensions
                .GetAllAdAccountGroupFieldsList();

            IList<AdAccountGroupFieldsEnum> baseList = new List<AdAccountGroupFieldsEnum>();
            foreach (AdAccountGroupFieldsEnum field in Enum.GetValues(typeof(AdAccountGroupFieldsEnum)))
                if (field != AdAccountGroupFieldsEnum.Undefined)
                    baseList.Add(field);

            Assert.AreEqual(baseList.Count, defaultFields.Count);

            foreach (var item in baseList)
                Assert.IsTrue(defaultFields.Any(d => d.Equals(item)));
        }
    }
}
