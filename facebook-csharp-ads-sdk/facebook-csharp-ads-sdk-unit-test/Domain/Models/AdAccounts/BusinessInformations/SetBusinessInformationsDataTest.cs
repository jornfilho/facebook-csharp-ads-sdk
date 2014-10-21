using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.BusinessInformations
{
    [TestClass]
    public class SetBusinessInformationsDataTest
    {
        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            model.SetBusinessInformationsData("a", "b", "c", "d", "e", "f", "g");
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.BusinessName,"a");
            Assert.AreEqual(model.BusinessStreet,"b");
            Assert.AreEqual(model.BusinessStreet2,"c");
            Assert.AreEqual(model.BusinessCity,"d");
            Assert.AreEqual(model.BusinessState,"e");
            Assert.AreEqual(model.BusinessZip,"f");
            Assert.AreEqual(model.BusinessCountryCode,"g");
        }

        [TestMethod]
        public void CantSetEmptyValueToProperties()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            model.SetBusinessInformationsData(string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty, string.Empty);

            Assert.IsNotNull(model);
            Assert.AreNotEqual(model.BusinessName, string.Empty);
            Assert.AreNotEqual(model.BusinessStreet, string.Empty);
            Assert.AreNotEqual(model.BusinessStreet2, string.Empty);
            Assert.AreNotEqual(model.BusinessCity, string.Empty);
            Assert.AreNotEqual(model.BusinessState, string.Empty);
            Assert.AreNotEqual(model.BusinessZip, string.Empty);
            Assert.AreNotEqual(model.BusinessCountryCode, string.Empty);
        }
    }
}
