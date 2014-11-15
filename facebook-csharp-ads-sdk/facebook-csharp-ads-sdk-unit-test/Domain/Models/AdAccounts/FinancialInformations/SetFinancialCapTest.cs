using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialCapTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidSpendCapToFinancialInformations_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialSpendCap(InvalidAdAccountSpendCap1);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
        }

        [TestMethod]
        public void CantSetInvalidSpendCapToFinancialInformations_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models.AdAccounts
                .FinancialInformations()
                .SetFinancialSpendCap(InvalidAdAccountSpendCap2);

            Assert.IsNotNull(model);
            Assert.IsFalse(model.IsValidData());
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
