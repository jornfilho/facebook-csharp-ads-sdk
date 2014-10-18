using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with financial ad account informations
    /// </summary>
    public class FinancialInformations
    {
        #region Params
        /// <summary>
        /// <para>Current total amount spent by the account. This can be reset.</para>
        /// </summary>
        public long AmountSpent { get; private set; }

        /// <summary>
        /// <para>Bill amount due</para>
        /// </summary>
        public long Balance { get; private set; }

        /// <summary>
        /// <para>The maximum that can be spent by this account after which campaigns will be paused.</para>
        /// <para>A value of 0 signifies no spending-cap and setting a new spend cap only applies to spend AFTER the time at which you set it.</para>
        /// <para>Value specified in basic unit of the currency, e.g. dollars for USD</para>
        /// </summary>
        public double SpendCap { get; private set; }

        /// <summary>
        /// <para>The account's limit for daily spend, based on the corresponding value in the account settings</para>
        /// </summary>
        public long DailySpendLimit { get; private set; }

        /// <summary>
        /// <para>The currency used for the account, based on the corresponding value in the account settings.</para>
        /// <para>The list of supported currencies can be found at https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
        /// </summary>
        public IList<CurrenciesEnum> Currency { get; private set; }

        /// <summary>
        /// <para>ID of the funding source</para>
        /// </summary>
        public long FundingSource { get; private set; }

        /// <summary>
        /// <para>The details of funding source</para>
        /// </summary>
        public IList<FundingSourceDetail> FundingSourceDetails { get; private set; }
        #endregion

        /// <summary>
        /// Return a list of fields of ad account fiancial informations
        /// </summary>
        /// <returns>list of fields of ad account fiancial informations</returns>
        public IList<AdAccountFieldsEnum> GetFields()
        {
            return new []
            {
                AdAccountFieldsEnum.AmountSpent, 
                AdAccountFieldsEnum.Balance, 
                AdAccountFieldsEnum.SpendCap, 
                AdAccountFieldsEnum.DailySpendLimit, 
                AdAccountFieldsEnum.Currency, 
                AdAccountFieldsEnum.FundingSource, 
                AdAccountFieldsEnum.FundingSourceDetails
            };
        }
    }
}
