using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialCapTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidSpendCapToFinancialInformations_1()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialSpendCap(InvalidAdAccountSpendCap1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantSetInvalidSpendCapToFinancialInformations_2()
        {
            new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialSpendCap(InvalidAdAccountSpendCap2);
        }

        [TestMethod]
        public void CanSetSpendCapToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialSpendCap(ValidAdAccountSpendCap);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.SpendCap, ValidAdAccountSpendCap);
            Assert.IsTrue(model.IsValidData());
        }
    }
}
