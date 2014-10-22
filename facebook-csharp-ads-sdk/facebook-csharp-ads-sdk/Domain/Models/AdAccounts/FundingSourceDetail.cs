using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Ad account funding source details class
    /// Without Facebook documentation for this model
    /// </summary>
    public class FundingSourceDetail
    {
        #region Properties
        /// <summary>
        /// Facebook name: id
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Facebook name: display_string
        /// </summary>
        public string DisplayString { get; private set; }

        //TODO: Know more about this field on Facebook
        /// <summary>
        /// Facebook name: type
        /// 1: credit card
        /// 4: invoice
        /// 13: paypal
        /// </summary>
        public int Type { get; private set; }

        /// <summary>
        /// Facebook name: coupon
        /// </summary>
        public FundingSourceCupon Cupon { get; private set; }
        #endregion

        /// <summary>
        /// Set funding source values
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">id or type invalid</exception>
        public FundingSourceDetail SetFundingSourceDetailData(long id, string displayString, int type)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            if (type <= 0)
                throw new ArgumentOutOfRangeException();

            Id = id;

            if (!String.IsNullOrEmpty(displayString))
                DisplayString = displayString;

            Type = type;

            return this;
        }

        /// <summary>
        /// Set funding source cupon model
        /// </summary>
        /// <exception cref="ArgumentNullException">cupon is null</exception>
        /// <exception cref="ArgumentException">cupon has invalid value</exception>
        public FundingSourceDetail SetFundingSourceCupon(FundingSourceCupon cupon)
        {
            if (cupon == null)
                throw new ArgumentNullException();

            if (cupon.Currency == CurrenciesEnum.UND)
                throw new ArgumentException();

            Cupon = cupon;

            return this;
        }
    }
}
