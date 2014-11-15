namespace facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts
{
    /// <summary>
    /// Class with business rules of ad account financial data
    /// </summary>
    public static class FinancialInformations
    {
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
