using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with financial ad account informations
    /// </summary>
    public class FinancialInformations : BaseObject
    {
        #region Properties

        /// <summary>
        /// <para>Current total amount spent by the account. This can be reset.</para>
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("amount_spent")]
        public long AmountSpent { get; private set; }

        /// <summary>
        /// <para>Bill amount due</para>
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("balance")]
        public long Balance { get; private set; }

        /// <summary>
        /// <para>The account's limit for daily spend, based on the corresponding value in the account settings</para>
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("daily_spend_limit")]
        public long DailySpendLimit { get; private set; }

        /// <summary>
        /// <para>The maximum that can be spent by this account after which campaigns will be paused.</para>
        /// <para>A value of 0 signifies no spending-cap and setting a new spend cap only applies to spend AFTER the time at which you set it.</para>
        /// <para>Value specified in basic unit of the currency, e.g. dollars for USD</para>
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("spend_cap")]
        public long SpendCap { get; private set; }

        /// <summary>
        /// <para>The currency used for the account, based on the corresponding value in the account settings.</para>
        /// <para>The list of supported currencies can be found at https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
        /// </summary>
        [DefaultValue(CurrenciesEnum.UND)]
        [FacebookName("currency")]
        public CurrenciesEnum Currency { get; private set; }

        /// <summary>
        /// <para>ID of the funding source</para>
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("funding_source")]
        public long FundingSourceId { get; private set; }

        /// <summary>
        /// <para>The details of funding source</para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("funding_source_details")]
        public IList<FundingSourceDetail> FundingSourceDetails { get; private set; }
        #endregion

        /// <summary>
        /// Set financial summary
        /// </summary>
        public FinancialInformations SetFinancialSummary(long amountSpent, long balance, long dailySpendLimit)
        {
            var isValid = false;

            if (IsValidAdAccountAmountSpent(amountSpent))
            {
                AmountSpent = amountSpent;
                isValid = true;
            }

            if (IsValidAdAccountBalance(balance))
            {
                Balance = balance;
                isValid = true;
            }

            if (IsValidAdAccountDailySpendLimit(dailySpendLimit))
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
            if (!IsValidAdAccountSpendCap(spendCap))
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
        public FinancialInformations SetFinancialFundingSource(long fundingSource)
        {
            if (!IsValidAdAccountFundingSourceId(fundingSource))
                return this;

            FundingSourceId = fundingSource;
            SetValid();

            return this;
        }

        /// <summary>
        /// Set financial funding detail
        /// </summary>
        public FinancialInformations SetFinancialFundingDetail(FundingSourceDetail fundingSourceDetails)
        {
            if (fundingSourceDetails == null)
            {
                FundingSourceDetails = null;
                return this;
            }


            if (!fundingSourceDetails.IsValid)
                return this;

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
                    if (fundingSourceDetail.IsValid)
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
            return fundingSourceId >= 0;
        }

        /// <summary>
        /// Test if ad account financial spend cap has a vaid value
        /// </summary>
        private static bool IsValidAdAccountSpendCap(long spendCap)
        {
            return spendCap >= 0;
        }

        /// <summary>
        /// Test if ad account financial amount spent has a vaid value
        /// </summary>
        private static bool IsValidAdAccountAmountSpent(long amountSpent)
        {
            return amountSpent >= 0;
        }

        /// <summary>
        /// Test if ad account financial balance has a vaid value
        /// </summary>
        private static bool IsValidAdAccountBalance(long balance)
        {
            return balance >= 0;
        }

        /// <summary>
        /// Test if ad account financial daily spend limit has a vaid value
        /// </summary>
        private static bool IsValidAdAccountDailySpendLimit(long dailySpendLimit)
        {
            return dailySpendLimit >= 0;
        }
    }
}
