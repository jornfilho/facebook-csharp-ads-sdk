﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccountGroup
{
    [TestClass]
    public class SetAdAccountGroupDataTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidAccountGroupIdOnAdAccountGroup_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    InvalidAdAccountGroupId1,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAccountGroupIdOnAdAccountGroup_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    InvalidAdAccountGroupId2,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidNameOnAdAccountGroup_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    InvalidAdAccountGroupName1,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.Name, default(string));
        }

        [TestMethod]
        public void CantSetInvalidNameOnAdAccountGroup_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    InvalidAdAccountGroupName2,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
            Assert.AreEqual(model.Name, InvalidAdAccountGroupName2);
        }

        [TestMethod]
        public void CantSetInvalidStatusOnAdAccountGroup_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    ValidAdAccountGroupName,
                    InvalidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CanSetAdAccountGroupData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValid);
        }
    }
}
