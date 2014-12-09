using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdAccountGroup.AdAccountGroupFieldsEnumExtensions
{
    [TestClass]
    public class GetAdAccountGroupFieldsEnumTest
    {
        [TestMethod]
        public void CanGetFacebookAccountGroupFieldEnumFromFacebookName()
        {
            const string facebookName = "account_group_id";
            const AdAccountGroupFieldsEnum facebookField = AdAccountGroupFieldsEnum.AccountGroupId;

            Assert.AreEqual(facebookField, facebookName.GetAdAccountGroupFieldsEnum());
        }

        [TestMethod]
        public void CantGetFacebookAccountGroupFieldEnumFromInvalidFacebookName()
        {
            const string facebookName = "account_group_idd";
            const AdAccountGroupFieldsEnum facebookField = AdAccountGroupFieldsEnum.Undefined;

            Assert.AreEqual(facebookField, facebookName.GetAdAccountGroupFieldsEnum());
        }
    }
}
