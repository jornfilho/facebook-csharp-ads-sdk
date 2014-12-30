using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    /// <summary>
    /// An offer that is published by a Facebook Page
    /// </summary>
    public class OfferData
    {
        /// <summary>
        /// ID of a Facebook page
        /// </summary>
        [FacebookName("page_id")]
        public long PageId { get; private set; }

        /// <summary>
        /// The title of the offer
        /// </summary>
        [FacebookName("title")]
        public string Title { get; private set; }

        /// <summary>
        /// The description text of the offer
        /// </summary>
        [FacebookName("message")]
        public string Message { get; private set; }

        /// <summary>
        /// The URL for the offer's image
        /// </summary>
        [FacebookName("image_url")]
        public string ImageUrl { get; private set; }

        /// <summary>
        /// The type of offer
        /// </summary>
        [FacebookName("coupon_type")]
        public string CouponType { get; private set; }

        /// <summary>
        /// The expiration time of the offer
        /// </summary>
        [FacebookName("expiration_time")]
        public DateTime ExpirationTime { get; private set; }

        /// <summary>
        /// The reminder time of the offer
        /// </summary>
        [FacebookName("reminder_time")]
        public DateTime ReminderTime { get; private set; }

        /// <summary>
        /// The maximum number of times the offer can be claimed.
        /// </summary>
        [FacebookName("claim_limit")]
        public int ClaimLimit { get; private set; }

        /// <summary>
        /// The URL where the offer may be redeemed.
        /// </summary>
        [FacebookName("redemption_link")]
        public string RedemptionLink { get; private set; }

        /// <summary>
        /// A code to receive the discount or promotion.
        /// </summary>
        [FacebookName("redemption_code")]
        public string RedemptionCode { get; private set; }

        /// <summary>
        /// The Barcode Type of the offer
        /// </summary>
        [FacebookName("barcode_type")]
        public string BarcodeType { get; private set; }

        /// <summary>
        /// The barcode of the offer
        /// </summary>
        [FacebookName("barcode")]
        public string Barcode { get; private set; }
    }
}
