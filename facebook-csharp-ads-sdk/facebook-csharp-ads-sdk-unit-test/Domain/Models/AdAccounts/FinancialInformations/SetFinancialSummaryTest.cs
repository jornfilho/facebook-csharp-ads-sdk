using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccounts.FinancialInformations
{
    [TestClass]
    public class SetFinancialSummaryTest : TestBase
    {
        [TestMethod]
        public void CantSetInvalidAdAccountAmountSpentToFinancialInformations_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(InvalidAdAccountAmountSpent1, default(long), default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.AmountSpent, default(long));
            if (model.AmountSpent >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountAmountSpentToFinancialInformations_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(InvalidAdAccountAmountSpent2, default(long), default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.AmountSpent, default(long));
            if (model.AmountSpent >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CanSetAdAccountAmountSpentToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(ValidAdAccountAmountSpent, default(long), default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.AmountSpent, ValidAdAccountAmountSpent);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountBalanceToFinancialInformations_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), InvalidAdAccountBalance1, default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Balance, default(long));
            if (model.Balance >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountBalanceToFinancialInformations_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), InvalidAdAccountBalance2, default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Balance, default(long));
            if (model.Balance >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CanSetAdAccountBalanceToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), ValidAdAccountBalance, default(long));

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Balance, ValidAdAccountBalance);
            Assert.IsTrue(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountDailySpendLimitToFinancialInformations_1()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), default(long), InvalidAdAccountDailySpendLimit1);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.DailySpendLimit, default(long));
            if (model.DailySpendLimit >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CantSetInvalidAdAccountDailySpendLimitToFinancialInformations_2()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), default(long), InvalidAdAccountDailySpendLimit2);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.DailySpendLimit, default(long));
            if (model.DailySpendLimit >= 0)
                Assert.IsTrue(model.IsValid);
            else
                Assert.IsFalse(model.IsValid);
        }

        [TestMethod]
        public void CanSetAdAccountDailySpendLimitToFinancialInformations()
        {
            var model = new facebook_csharp_ads_sdk.Domain.Models
                .AdAccounts.FinancialInformations()
                .SetFinancialSummary(default(long), default(long), ValidAdAccountDailySpendLimit);

            Assert.IsNotNull(model);
            Assert.AreEqual(model.DailySpendLimit, ValidAdAccountDailySpendLimit);
            Assert.IsTrue(model.IsValid);
        }
    }
}
