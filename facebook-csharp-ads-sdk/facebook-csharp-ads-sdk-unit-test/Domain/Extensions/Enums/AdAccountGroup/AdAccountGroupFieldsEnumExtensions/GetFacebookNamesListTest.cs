using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccountGroup.AdAccountGroupFieldsEnumExtensions
{
    [TestClass]
    public class GetFacebookNamesListTest
    {
        [TestMethod]
        public void CanGetFacebookNamesListFromAListOFields()
        {
            IList<AdAccountGroupFieldsEnum> fields = new[]
            {
                AdAccountGroupFieldsEnum.AccountGroupId,
                AdAccountGroupFieldsEnum.Name
            };

            var facebookNames = fields.GetFacebookNamesList();

            foreach (var field in fields)
            {
                var facebookName = field.GetFacebookName();
                Assert.IsFalse(String.IsNullOrEmpty(facebookName));
                Assert.IsTrue(facebookNames.Any(f => f.Equals(facebookName)));
            }
        }
    }
}
