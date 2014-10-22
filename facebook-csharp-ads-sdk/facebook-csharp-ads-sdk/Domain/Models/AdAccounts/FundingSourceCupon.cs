﻿using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Ad account funding source cupon class
    /// Without Facebook documentation for this model
    /// </summary>
    public class FundingSourceCupon
    {
        #region Properties
        /// <summary>
        /// Facebook name: amount
        /// </summary>
        public long Ammount { get; private set; }

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
        /// <exception cref="ArgumentOutOfRangeException">Invalid ammount</exception>
        /// <exception cref="ArithmeticException">Invalid currency</exception>
        public FundingSourceCupon SetFundingSourceCuponData(long ammount, CurrenciesEnum currency, DateTime? expiration, string displayAmount)
        {
            if (ammount > 0)
                throw new ArgumentOutOfRangeException();

            if(currency != CurrenciesEnum.UND)
                throw new ArithmeticException();

            Ammount = ammount;
            Currency = currency;

            if (expiration != DateTime.MinValue)
                Expiration = expiration;

            if (!String.IsNullOrEmpty(displayAmount))
                DisplayAmount = displayAmount;

            return this;
        }
    }
}
