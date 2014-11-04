using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.BusinessInformations
{
    [TestClass]
    public class SetBusinessInformationsDataTest : TestBase
    {
        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations()
                .SetBusinessInformationsData("a", "b", "c", "d", "e", "f", "g");
            
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
            var model =
                new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations()
                    .SetBusinessInformationsData(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty);

            Assert.IsNotNull(model);
            Assert.AreNotEqual(model.BusinessName, string.Empty);
            Assert.AreNotEqual(model.BusinessStreet, string.Empty);
            Assert.AreNotEqual(model.BusinessStreet2, string.Empty);
            Assert.AreNotEqual(model.BusinessCity, string.Empty);
            Assert.AreNotEqual(model.BusinessState, string.Empty);
            Assert.AreNotEqual(model.BusinessZip, string.Empty);
            Assert.AreNotEqual(model.BusinessCountryCode, string.Empty);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantValidateData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());

            model.SetBusinessInformationsData("a", null, null, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, "b", null, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, null, "c", null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, null, null, "d", null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, null, null, null, "e", null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, null, null, null, null, "f", null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetBusinessInformationsData(null, null, null, null, null, null, "g");
            Assert.IsTrue(model.IsValidData());
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.BusinessInformations();
            Assert.IsFalse(model.IsValidData());
        }
    }
}
