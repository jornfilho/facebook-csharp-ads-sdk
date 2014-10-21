using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.Attribute.GetCustomEnumAttributeValueExtension
{
    [TestClass]
    public class GetCustomEnumAttributeValueExtensionTest
    {
        [TestMethod]
        public void CanGetACustomAttributeFromEnum()
        {
            const AdAccountFieldsEnum enumOption = AdAccountFieldsEnum.AccountId;
            var attributeValue = enumOption.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();

            Assert.IsNotNull(attributeValue);
            Assert.AreEqual(attributeValue, "account_id");
        }

        [TestMethod]
        public void CantGetACustomAttributeFromEnumIfSendInvalidType()
        {
            const AdAccountFieldsEnum enumOption = AdAccountFieldsEnum.AccountId;
            var attributeValue = enumOption.GetCustomEnumAttributeValue<FacebookNameAttribute, int>();

            Assert.IsNotNull(attributeValue);
            Assert.AreEqual(attributeValue, default(int));
        }
    }
}
