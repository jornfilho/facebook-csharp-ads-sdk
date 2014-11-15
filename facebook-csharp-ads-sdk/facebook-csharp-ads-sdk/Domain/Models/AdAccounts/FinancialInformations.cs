using System;
using System.Collections.Generic;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

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
        public long SpendCap { get; private set; }

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
        public FinancialInformations SetFinancialSpendCap(long spendCap)
        {
            if (!spendCap.IsValidAdAccountSpendCap())
                return this;

            SpendCap = spendCap;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial currency
        /// </summary>
        public FinancialInformations SetFinancialCurrency(CurrenciesEnum currency)
        {
            if (!IsValidAdAccountCurrency(currency))
                return this;

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
            if (!IsValidAdAccountFundingSourceId(fundingSource))
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

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public FinancialInformations ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            #region Summary
            long amountSpent = 0, balance = 0, dailySpendLimit = 0;

            if (jsonResult["amount_spent"] != null && jsonResult["amount_spent"].Type == JTokenType.Integer)
                amountSpent = jsonResult["amount_spent"].ToString().TryParseLong();

            if (jsonResult["balance"] != null && jsonResult["balance"].Type == JTokenType.Integer)
                balance = jsonResult["balance"].ToString().TryParseLong();

            if (jsonResult["daily_spend_limit"] != null && jsonResult["daily_spend_limit"].Type == JTokenType.Integer)
                dailySpendLimit = jsonResult["daily_spend_limit"].ToString().TryParseLong();

            SetFinancialSummary(amountSpent, balance, dailySpendLimit); 
            #endregion

            #region SpendCap
            long spendCap = 0;
            if (jsonResult["spend_cap"] != null && jsonResult["spend_cap"].Type == JTokenType.Integer)
                spendCap = jsonResult["spend_cap"].ToString().TryParseLong();

            SetFinancialSpendCap(spendCap); 
            #endregion

            #region Currency
            var currency = CurrenciesEnum.UND;

            if (jsonResult["currency"] != null && jsonResult["currency"].Type == JTokenType.String)
                currency = jsonResult["currency"].ToString().GetCurrencyEnum();

            SetFinancialCurrency(currency); 
            #endregion

            #region FundingSource
            long fundingSource = 0;
            if (jsonResult["funding_source"] != null && jsonResult["funding_source"].Type == JTokenType.String)
                fundingSource = jsonResult["funding_source"].ToString().TryParseLong();

            SetFinancialFundingSource(fundingSource); 
            #endregion

            #region FundingSourceDetails
            if (jsonResult["funding_source_details"] != null && jsonResult["funding_source_details"].Type == JTokenType.Array)
            {
                var fundingSourceDetailCount = jsonResult["funding_source_details"].Count();
                for (var index = 0; index < fundingSourceDetailCount; index++)
                {
                    var fundingSourceDetail = new FundingSourceDetail().ParseApiResponse(jsonResult["funding_source_details"]);
                    if (fundingSourceDetail.IsValidData())
                        SetFinancialFundingDetail(fundingSourceDetail); 
                }
            }
            #endregion
            
            return this;
        }

        /// <summary>
        /// Test if ad account currency has a vaid value
        /// </summary>
        private static bool IsValidAdAccountCurrency(CurrenciesEnum currency)
        {
            return !currency.Equals(CurrenciesEnum.UND);
        }

        /// <summary>
        /// Test if ad account financial funding source id has a vaid value
        /// </summary>
        private static bool IsValidAdAccountFundingSourceId(long fundingSourceId)
        {
            return fundingSourceId > 0;
        }
    }
}
