using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccountGroup.AdAccountGroupFieldsEnumExtensions
{
    [TestClass]
    public class GetFacebookNameTest
    {
        [TestMethod]
        public void CanGetFacebookAccountGroupNameFromAdAccountGroupFieldsEnum()
        {
            const string facebookName = "account_group_id";
            const AdAccountGroupFieldsEnum facebookField = AdAccountGroupFieldsEnum.AccountGroupId;

            Assert.AreEqual(facebookName, facebookField.GetFacebookName());
        }

        [TestMethod]
        public void CantGetFacebookAccountGroupNameFromInvalidAdAccountGroupFieldsEnum()
        {
            const AdAccountGroupFieldsEnum facebookField = AdAccountGroupFieldsEnum.Undefined;

            Assert.IsNull(facebookField.GetFacebookName());
        }
    }
}
