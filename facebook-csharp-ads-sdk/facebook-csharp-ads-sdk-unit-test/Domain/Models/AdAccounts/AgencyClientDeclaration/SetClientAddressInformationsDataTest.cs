using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AgencyClientDeclaration
{
    [TestClass]
    public class SetClientAddressInformationsDataTest : TestBase
    {
        [TestMethod]
        public void CantSetClientAddressInformationsDataWhenAllFieldsAreNullOrEmpty_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientAddressInformationsData(null, null, null, null, null, null, null, null);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantSetClientAddressInformationsDataWhenAllFieldsAreNullOrEmpty_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientAddressInformationsData(string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, string.Empty);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration()
                .SetClientAddressInformationsData(
                    ValidClientCity,
                    ValidClientCountryCode,
                    ValidClientEmailAddress,
                    ValidClientName,
                    ValidClientPostalCode,
                    ValidClientProvince,
                    ValidClientStreet,
                    ValidClientStreet2
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.ClientCity, ValidClientCity);
            Assert.AreEqual(model.ClientCountryCode, ValidClientCountryCode);
            Assert.AreEqual(model.ClientEmailAddress, ValidClientEmailAddress);
            Assert.AreEqual(model.ClientName, ValidClientName);
            Assert.AreEqual(model.ClientPostalCode, ValidClientPostalCode);
            Assert.AreEqual(model.ClientProvince, ValidClientProvince);
            Assert.AreEqual(model.ClientStreet, ValidClientStreet);
            Assert.AreEqual(model.ClientStreet2, ValidClientStreet2);
        }

        [TestMethod]
        public void CanValidateData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AgencyClientDeclaration();
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());

            model.SetClientAddressInformationsData(ValidClientCity, null, null, null, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, ValidClientCountryCode, null, null, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, ValidClientEmailAddress, null, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, null, ValidClientName, null, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, null, null, ValidClientPostalCode, null, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, null, null, null, ValidClientProvince, null, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, null, null, null, null, ValidClientStreet, null);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);

            model.SetClientAddressInformationsData(null, null, null, null, null, null, null, ValidClientStreet2);
            Assert.IsTrue(model.IsValidData());
            RenewModel(out model);
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AgencyClientDeclaration model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AgencyClientDeclaration();
            Assert.IsFalse(model.IsValidData());
        }
    }
}
