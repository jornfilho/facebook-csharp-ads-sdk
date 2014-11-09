using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.User
{
    [TestClass]
    public class SetUserDataTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidUserId_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(InvalidUserUserId2, ValidUserPermissions, ValidUserRole);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidUserId_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(InvalidUserUserId1, ValidUserPermissions, ValidUserRole);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantSetInvalidUserPermission_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, InvalidUserPermissions2, ValidUserRole);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]
        public void CantSetInvalidUserPermission_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, InvalidUserPermissions1, ValidUserRole);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]
        public void CantSetInvalidUserRole()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, ValidUserPermissions, InvalidUserRole);
        }
        
        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, ValidUserPermissions, ValidUserRole);
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id, ValidUserUserId);
            Assert.AreEqual(model.Permissions,ValidUserPermissions);
            Assert.AreEqual(model.Role,ValidUserRole);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
