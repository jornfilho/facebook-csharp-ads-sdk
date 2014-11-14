﻿using System;
using System.ComponentModel;
using DevUtils.DateTimeExtensions;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Ad account funding source cupon class
    /// Without Facebook documentation for this model
    /// </summary>
    public class FundingSourceCoupon : ValidData
    {
        #region Properties
        /// <summary>
        /// Facebook name: amount
        /// </summary>
        public long Amount { get; private set; }

        /// <summary>
        /// Facebook name: currency
        /// </summary>
        public CurrenciesEnum Currency { get; private set; }

        /// <summary>
        /// Facebook name: expiration (unix)
        /// </summary>
        public DateTime? Expiration { get; private set; }

        /// <summary>
        /// Facebook name: display_amount
        /// </summary>
        public string DisplayAmount { get; private set; } 
        #endregion

        /// <summary>
        /// Set cupon data
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Invalid amount</exception>
        /// <exception cref="InvalidEnumArgumentException">Invalid currency</exception>
        public FundingSourceCoupon SetFundingSourceCuponData(long amount, CurrenciesEnum currency, DateTime? expiration, string displayAmount)
        {

            bool isValid = false;

            if (amount > 0)
            {
                Amount = amount;
                isValid = true;
            }

            if (currency != CurrenciesEnum.UND)
            {
                Currency = currency;
                isValid = true;
            }

            if (expiration != null && expiration != DateTime.MinValue)
            {
                Expiration = expiration;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(displayAmount))
            {
                DisplayAmount = displayAmount;
                isValid = true;
            }

            if(isValid)
                SetValid();

            return this;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public FundingSourceCoupon ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            #region Summary
            long amount = 0;
            if (jsonResult["amount"] != null && jsonResult["amount"].Type == JTokenType.Integer)
                amount = jsonResult["amount"].ToString().TryParseLong();

            var currency = CurrenciesEnum.UND;
            if (jsonResult["currency"] != null && jsonResult["currency"].Type == JTokenType.String)
                currency = jsonResult["currency"].ToString().GetCurrencyEnum();

            DateTime? expiration = null;
            if (jsonResult["expiration"] != null && jsonResult["expiration"].Type == JTokenType.Integer)
                expiration = jsonResult["expiration"].ToString().TryParseLong().FromUnixTimestamp();
            
            string displayAmount = null;
            if (jsonResult["display_amount"] != null && jsonResult["display_amount"].Type == JTokenType.String)
                displayAmount = jsonResult["display_amount"].ToString();

            SetFundingSourceCuponData(amount, currency, expiration, displayAmount);
            #endregion
            
            return this;
        }
    }
}