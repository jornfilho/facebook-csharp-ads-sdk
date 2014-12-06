using System;
using DevUtils.PrimitivesExtensions;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Ad account funding source details class
    /// Without Facebook documentation for this model
    /// </summary>
    public class FundingSourceDetail : BaseObject
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
        public FundingSourceCoupon Coupon { get; private set; }
        #endregion

        /// <summary>
        /// Set funding source values
        /// </summary>
        public FundingSourceDetail SetFundingSourceDetailData(long id, string displayString, int type)
        {
            if (id <= 0 || type <= 0)
                return this;

            Id = id;
            DisplayString = displayString;    
            Type = type;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set funding source coupon model
        /// </summary>
        /// <exception cref="ArgumentNullException">coupon is null</exception>
        /// <exception cref="ArgumentException">coupon has invalid value</exception>
        public FundingSourceDetail SetFundingSourceCoupon(FundingSourceCoupon coupon)
        {
            if (coupon == null)
                throw new ArgumentNullException();

            if (!coupon.IsValidData())
                throw new ArgumentException();

            Coupon = coupon;

            SetValid();

            return this;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public FundingSourceDetail ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            #region Summary
            long id = 0;
            if (jsonResult["id"] != null && jsonResult["id"].Type == JTokenType.Integer)
                id = jsonResult["id"].ToString().TryParseLong();

            string displayString = null;
            if (jsonResult["display_string"] != null && jsonResult["display_string"].Type == JTokenType.String)
                displayString = jsonResult["display_string"].ToString();

            int type = 0;
            if (jsonResult["type"] != null && jsonResult["type"].Type == JTokenType.Integer)
                type = jsonResult["type"].ToString().TryParseInt();

            SetFundingSourceDetailData(id, displayString, type);
            #endregion

            #region Coupon
            if (jsonResult["coupon"] != null && jsonResult["coupon"].Type == JTokenType.Object)
            {
                var coupon = new FundingSourceCoupon().ParseApiResponse(jsonResult["coupon"]);
                if (coupon.IsValidData())
                    SetFundingSourceCoupon(coupon);
            }
            #endregion

            return this;
        }
    }
}
