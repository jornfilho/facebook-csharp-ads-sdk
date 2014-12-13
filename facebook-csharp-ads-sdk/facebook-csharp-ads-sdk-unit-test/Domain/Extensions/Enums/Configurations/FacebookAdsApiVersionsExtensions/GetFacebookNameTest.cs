using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.Configurations.FacebookAdsApiVersionsExtensions
{
    [TestClass]
    public class GetFacebookNameTest
    {
        [TestMethod]
        public void CanGetFacebookAdApiVersionFromEnumOption()
        {
            const FacebookAdsApiVersionsEnum enumOption = FacebookAdsApiVersionsEnum.V22;
            var attributeValue = enumOption.GetCustomEnumAttributeValue<FacebookNameAttribute, string>();

            Assert.IsNotNull(attributeValue);
            Assert.AreEqual(attributeValue, "v2.2");
        }
    }
}
