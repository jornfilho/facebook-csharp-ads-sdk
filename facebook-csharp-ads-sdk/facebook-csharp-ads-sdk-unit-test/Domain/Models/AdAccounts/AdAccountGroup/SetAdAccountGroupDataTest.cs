using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.AdAccountGroup
{
    [TestClass]
    public class SetAdAccountGroupDataTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidAccountGroupIdOnAdAccountGroup_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    InvalidAdAccountGroupId1,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidAccountGroupIdOnAdAccountGroup_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    InvalidAdAccountGroupId2,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidNameOnAdAccountGroup_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    InvalidAdAccountGroupName1,
                    ValidAdAccountGroupStatus
                );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantSetInvalidNameOnAdAccountGroup_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    InvalidAdAccountGroupName2,
                    ValidAdAccountGroupStatus
                );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]
        public void CantSetInvalidStatusOnAdAccountGroup_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    ValidAdAccountGroupName,
                    InvalidAdAccountGroupStatus
                );
        }

        [TestMethod]
        public void CanSetAdAccountGroupData()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .AdAccountGroup()
                .SetAdAccountGroupData(
                    ValidAdAccountGroupId,
                    ValidAdAccountGroupName,
                    ValidAdAccountGroupStatus
                );

            Assert.IsNotNull(model);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
