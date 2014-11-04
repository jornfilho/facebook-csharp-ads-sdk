using System;
using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with financial ad account informations
    /// </summary>
    public class FinancialInformations : ValidData
    {
        #region Properties

        /// <summary>
        /// <para>Current total amount spent by the account. This can be reset.</para>
        /// </summary>
        public long AmountSpent { get; private set; }

        /// <summary>
        /// <para>Bill amount due</para>
        /// </summary>
        public long Balance { get; private set; }

        /// <summary>
        /// <para>The account's limit for daily spend, based on the corresponding value in the account settings</para>
        /// </summary>
        public long DailySpendLimit { get; private set; }

        /// <summary>
        /// <para>The maximum that can be spent by this account after which campaigns will be paused.</para>
        /// <para>A value of 0 signifies no spending-cap and setting a new spend cap only applies to spend AFTER the time at which you set it.</para>
        /// <para>Value specified in basic unit of the currency, e.g. dollars for USD</para>
        /// </summary>
        public double SpendCap { get; private set; }

        /// <summary>
        /// <para>The currency used for the account, based on the corresponding value in the account settings.</para>
        /// <para>The list of supported currencies can be found at https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
        /// </summary>
        public CurrenciesEnum Currency { get; private set; }

        /// <summary>
        /// <para>ID of the funding source</para>
        /// </summary>
        public long FundingSourceId { get; private set; }

        /// <summary>
        /// <para>The details of funding source</para>
        /// </summary>
        public IList<FundingSourceDetail> FundingSourceDetails { get; private set; }
        #endregion

        /// <summary>
        /// Set financial summary
        /// </summary>
        public FinancialInformations SetFinancialSummary(long amountSpent, long balance, long dailySpendLimit)
        {
            bool isValid = false;

            if (amountSpent.IsValidAdAccountAmountSpent())
            {
                AmountSpent = amountSpent;
                isValid = true;
            }

            if (balance.IsValidAdAccountBalance())
            {
                Balance = balance;
                isValid = true;
            }

            if (dailySpendLimit.IsValidAdAccountDailySpendLimit())
            {
                DailySpendLimit = dailySpendLimit;
                isValid = true;
            }

            if (isValid)
                SetValid();

            return this;
        }

        /// <summary>
        /// Set financial cap
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When spendCap has invalid value</exception>
        public FinancialInformations SetFinancialSpendCap(double spendCap)
        {
            if (!spendCap.IsValidAdAccountSpendCap())
                throw new ArgumentOutOfRangeException();

            SpendCap = spendCap;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial currency
        /// </summary>
        public FinancialInformations SetFinancialCurrency(CurrenciesEnum currency)
        {
            if (!currency.IsValidAdAccountCurrency())
                throw new InvalidEnumArgumentException();

            Currency = currency;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial funding source
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When fundingSource has invalid value</exception>
        public FinancialInformations SetFinancialFundingSource(long fundingSource)
        {
            if (!fundingSource.IsValidAdAccountFundingSourceId())
                throw new ArgumentOutOfRangeException();

            FundingSourceId = fundingSource;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial funding detail
        /// </summary>
        /// <exception cref="ArgumentNullException">fundingSourceDetails is null</exception>
        /// <exception cref="ArgumentException">fundingSourceDetails has an invalid value</exception>
        public FinancialInformations SetFinancialFundingDetail(FundingSourceDetail fundingSourceDetails)
        {
            if (fundingSourceDetails == null)
                throw new ArgumentNullException();

            if (!fundingSourceDetails.IsValidData())
                throw new ArgumentException();

            if (FundingSourceDetails == null)
                FundingSourceDetails = new List<FundingSourceDetail>();

            FundingSourceDetails.Add(fundingSourceDetails);

            SetValid();

            return this;
        }

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
