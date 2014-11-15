using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts
{
    /// <summary>
    /// Class with business rules of ad account financial data
    /// </summary>
    public static class FinancialInformations
    {
        #region Funding source
        /// <summary>
        /// Test if ad account financial funding source id has a vaid value
        /// </summary>
        public static bool IsValidAdAccountFundingSourceId(this long fundingSourceId)
        {
            return fundingSourceId > 0;
        }

        /// <summary>
        /// Test if ad account financial funding source id has a vaid value
        /// </summary>
        public static bool IsValidAdAccountFundingSourceId(this long? fundingSourceId)
        {
            if (fundingSourceId == null)
                fundingSourceId = 0;

            return fundingSourceId.Value.IsValidAdAccountFundingSourceId();
        }
        #endregion

        #region Spend Cap
        /// <summary>
        /// Test if ad account financial spend cap has a vaid value
        /// </summary>
        public static bool IsValidAdAccountSpendCap(this long spendCap)
        {
            return spendCap > 0;
        }

        /// <summary>
        /// Test if ad account financial spend cap has a vaid value
        /// </summary>
        public static bool IsValidAdAccountSpendCap(this long? spendCap)
        {
            if (spendCap == null)
                spendCap = 0;

            return spendCap.Value.IsValidAdAccountSpendCap();
        }
        #endregion

        #region Amount spent
        /// <summary>
        /// Test if ad account financial amount spent has a vaid value
        /// </summary>
        public static bool IsValidAdAccountAmountSpent(this long amountSpent)
        {
            return amountSpent > 0;
        }

        /// <summary>
        /// Test if ad account financial amount spent has a vaid value
        /// </summary>
        public static bool IsValidAdAccountAmountSpent(this long? amountSpent)
        {
            if (amountSpent == null)
                amountSpent = 0;

            return amountSpent.Value.IsValidAdAccountAmountSpent();
        }
        #endregion

        #region Balance
        /// <summary>
        /// Test if ad account financial balance has a vaid value
        /// </summary>
        public static bool IsValidAdAccountBalance(this long balance)
        {
            return balance > 0;
        }

        /// <summary>
        /// Test if ad account financial balance has a vaid value
        /// </summary>
        public static bool IsValidAdAccountBalance(this long? balance)
        {
            if (balance == null)
                balance = 0;

            return balance.Value.IsValidAdAccountBalance();
        }
        #endregion

        #region Daily spent limit
        /// <summary>
        /// Test if ad account financial daily spend limit has a vaid value
        /// </summary>
        public static bool IsValidAdAccountDailySpendLimit(this long dailySpendLimit)
        {
            return dailySpendLimit > 0;
        }

        /// <summary>
        /// Test if ad account financial daily spend limit has a vaid value
        /// </summary>
        public static bool IsValidAdAccountDailySpendLimit(this long? dailySpendLimit)
        {
            if (dailySpendLimit == null)
                dailySpendLimit = 0;

            return dailySpendLimit.Value.IsValidAdAccountDailySpendLimit();
        }
        #endregion
    }
}
