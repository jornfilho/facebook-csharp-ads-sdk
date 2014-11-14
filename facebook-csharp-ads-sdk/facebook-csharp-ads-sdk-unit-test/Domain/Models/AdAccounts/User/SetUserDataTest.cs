using System;
using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;
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
        public void CantSetInvalidUserId_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(InvalidUserUserId1, ValidUserPermissions, ValidUserRole);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantSetInvalidUserPermission_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, InvalidUserPermissions2, ValidUserRole);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.Permissions, default(IList<UserPermissionsEnum>));
        }

        [TestMethod]
        public void CantSetInvalidUserPermission_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, InvalidUserPermissions1, ValidUserRole);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.Permissions, default(IList<UserPermissionsEnum>));
        }

        [TestMethod]
        public void CantSetInvalidUserRole()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, ValidUserPermissions, InvalidUserRole);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
            Assert.AreEqual(model.Role, default(UserRoleEnum));
        }
        
        [TestMethod]
        public void CanSetAllPropertiesData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .User()
                .SetUserData(ValidUserUserId, ValidUserPermissions, ValidUserRole);
            
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id, ValidUserUserId);
            Assert.AreEqual(string.Join(",", model.Permissions), string.Join(",", ValidUserPermissions));
            Assert.AreEqual(model.Role,ValidUserRole);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
