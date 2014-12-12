using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccount
{
    [TestClass]
    public class SetAdAccountBaseDataTest : TestBase
    {
        readonly IAccountRepository accountRepository = new AdAccountRespository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model;

        [TestInitialize]
        public void Initialize()
        {
            this.model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(accountRepository);
        }

        [TestMethod]
        public void CantSetOnlyAdAccounId()
        {
            model.SetAdAccountBaseData(
                    null,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountIdOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    InvalidAdAccountId1,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountIdOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    InvalidAdAccountId2,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidStringAdAccountIdOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    InvalidAdAccountStrId1,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidStringAdAccountIdOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    InvalidAdAccountStrId2,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountStatusOnAdAccountData()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    InvalidAdAccountStatus,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountAgeOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    InvalidAdAccountAge1,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountAgeOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    InvalidAdAccountAge2,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountCapabilitiesOnAdAccountData()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountCapabilities,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountEndAdvertiserOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountEndAdvertiser1,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountEndAdvertiserOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountEndAdvertiser2,
                    null,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountMediaAgencyOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountMediaAgency1,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountMediaAgencyOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountMediaAgency2,
                    null,
                    null,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountPartnerOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountPartner1,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountPartnerOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountPartner2,
                    null,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountTosAcceptedOnAdAccountData_1()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountTosAccepted1,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountTosAcceptedOnAdAccountData_2()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountTosAccepted1,
                    null
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountTaxStatusOnAdAccountData()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    InvalidAdAccountTaxStatus
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            model.SetAdAccountBaseData(
                    ValidAdAccountStrId,
                    ValidAdAccountId,
                    ValidAdAccountName,
                    ValidAdAccountStatus,
                    ValidAdAccountAge,
                    true,
                    ValidAdAccountCapabilities,
                    ValidAdAccountEndAdvertiser,
                    ValidAdAccountMediaAgency,
                    true,
                    ValidAdAccountPartner,
                    ValidAdAccountTosAccepted,
                    ValidAdAccountTaxStatus
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.Id, ValidAdAccountStrId);
            Assert.AreEqual(model.AccountId, ValidAdAccountId);
            Assert.AreEqual(model.Name, ValidAdAccountName);
            Assert.AreEqual(model.AccountStatus, ValidAdAccountStatus);
            Assert.AreEqual(model.Age, ValidAdAccountAge);
            Assert.IsTrue(model.IsPersonal ?? false);
            Assert.AreEqual(string.Join(",", model.Capabilities), string.Join(",", ValidAdAccountCapabilities));
            Assert.AreEqual(model.EndAdvertiser, ValidAdAccountEndAdvertiser);
            Assert.AreEqual(model.MediaAgency, ValidAdAccountMediaAgency);
            Assert.IsTrue(model.OffsitePixelsTosAccepted ?? false);
            Assert.AreEqual(model.Partner, ValidAdAccountPartner);
            Assert.AreEqual(string.Join(",", model.TosAccepted), string.Join(",", ValidAdAccountTosAccepted));
            Assert.AreEqual(model.TaxStatus, ValidAdAccountTaxStatus);
        }

        [TestMethod]
        public void CanValidateData()
        {
            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);

            model.SetAdAccountBaseData(ValidAdAccountStrId, ValidAdAccountId, 
                null, null, null, null, null, null, null, null, null, null, null);
            Assert.IsTrue(model.IsValid);
            RenewModel(out model);
        }

        private static void RenewModel(out facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount model)
        {
            model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts.AdAccount(new AdAccountRespository(new FacebookSessionRepository()));
            Assert.IsFalse(model.IsValid);
        }
    }
}
