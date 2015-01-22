using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative
{
    /// <summary>
    /// The page id and the content to create a new unpublished page post
    /// </summary>
    public class ObjectStorySpec
    {

        #region Properties

        /// <summary>
        /// Id of a Facebook Page
        /// </summary>
        [FacebookName("page_id")]
        public long PageId { get; private set; }

        /// <summary>
        /// Link url
        /// </summary>
        [FacebookName("link")]
        public string Link { get; private set; }

        /// <summary>
        /// Story message
        /// </summary>
        [FacebookName("message")]
        public string Message { get; private set; }

        /// <summary>
        /// Name of the link
        /// </summary>
        [FacebookName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Link Caption
        /// </summary>
        [FacebookName("caption")]
        public string Caption { get; private set; }

        /// <summary>
        /// Link Description    
        /// </summary>
        [FacebookName("description")]
        public string Description { get; private set; }

        /// <summary>
        /// URL of a picture to use in the post
        /// </summary>
        [FacebookName("picture")]
        public string Picture { get; private set; }

        /// <summary>
        /// Hash of an image in your image library with Facebook
        /// </summary>
        [FacebookName("image_hash")]
        public string ImageHash { get; private set; }

        /// <summary>
        /// An optional call to action
        /// </summary>
        [FacebookName("call_to_action")]
        public CallToActionTypeEnum CallToAction { get; private set; }

        /// <summary>
        /// How to display the image
        /// </summary>
        [FacebookName("image_crops")]
        public string ImageCrops { get; private set; }
        
        /// <summary>
        /// URL of an image to use in the post
        /// </summary>
        [FacebookName("url")]
        public string Url { get; private set; }
        
        /// <summary>
        /// Id of video that user has permission to or a video in ad account video library
        /// </summary>
        [FacebookName("video_id")]
        public long VideoId { get; private set; }

        /// <summary>
        /// URL of image to use as thumbnail
        /// </summary>
        [FacebookName("image_url")]
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Title for video
        /// </summary>
        [FacebookName("title")]
        public string Title { get; private set; }
        
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

        /// <summary>
        ///     A three element Array of link objects required for multi product ads
        /// </summary>
        [FacebookName("child_attachments")]
        public IList<ChildAttachments> ChildAttachments { get; private set; }

        /// <summary>
        ///     Type of object story spec
        /// </summary>
        public ObjectStorySpecType Type { get; private set; }

        #endregion Properties

        /// <summary>
        ///     Set Object story spec to Page link ad
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="link"></param>
        /// <param name="message"></param>
        /// <param name="name"></param>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        /// <param name="picture"></param>
        /// <param name="imageHash"></param>
        /// <param name="callToAction"></param>
        /// <param name="imageCrops"></param>
        /// <returns></returns>
        public ObjectStorySpec SetPageLinkAd(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops)
        {
            if (!pageId.IsValidPageId())
                return null;
            if (String.IsNullOrEmpty(link))
                return null;
            if (String.IsNullOrEmpty(message))
                return null;
            if (String.IsNullOrEmpty(name))
                return null;
            if (String.IsNullOrEmpty(caption))
                return null;
            if (String.IsNullOrEmpty(description))
                return null;
            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
                return null;
            if (String.IsNullOrEmpty(imageCrops))
                return null;

            Type = ObjectStorySpecType.LinkPageData;
            PageId = pageId;
            Link = link;
            Message = message;
            Name = name;
            Caption = caption;
            Description = description;
            if (picture != null)
                Picture = picture;
            else 
                ImageHash = imageHash;
            CallToAction = callToAction;
            ImageCrops = imageCrops;
            return this;
        }

        /// <summary>
        ///     Set Object story spec to Page Photo ad
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="url"></param>
        /// <param name="imageHash"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public ObjectStorySpec SetPagePhotoAd(long pageId, string url, string imageHash, string caption)
        {
            if(!pageId.IsValidPageId())
                return null;
            if (String.IsNullOrEmpty(url) && String.IsNullOrEmpty(imageHash))
                return null;
            if (String.IsNullOrEmpty(caption))
                return null;

            Type = ObjectStorySpecType.PhotoPageData;
            PageId = pageId;
            if (url != null)
                Url = url;
            else ImageHash = imageHash;
            Caption = caption;
            
            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Video ad
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="videoId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="imageUrl"></param>
        /// <param name="imageHash"></param>
        /// <param name="callToAction"></param>
        /// <returns></returns>
        public ObjectStorySpec SetPageVideoAd(long pageId, long videoId, string title, string description, string imageUrl,
            string imageHash, CallToActionTypeEnum callToAction)
        {
            if (!pageId.IsValidPageId())
                return null;
            if (!videoId.IsValidVideoId())
                return null;
            if (String.IsNullOrEmpty(title))
                return null;
            if (String.IsNullOrEmpty(description))
                return null;
            if (String.IsNullOrEmpty(imageUrl))
                return null;
            if (String.IsNullOrEmpty(imageHash))
                return null;

            PageId = pageId;
            VideoId = videoId;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            ImageHash = imageHash;
            CallToAction = callToAction;
            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Offer ad
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="imageUrl"></param>
        /// <param name="couponType"></param>
        /// <param name="expirationTime"></param>
        /// <param name="reminderTime"></param>
        /// <param name="claimLimit"></param>
        /// <param name="redemptionLink"></param>
        /// <param name="redemptionCode"></param>
        /// <param name="barcodeType"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public ObjectStorySpec SetPageOfferAd(long pageId, string title, string message, string imageUrl, string couponType,
            DateTime expirationTime, DateTime reminderTime, int claimLimit, string redemptionLink, string redemptionCode,
            string barcodeType, string barcode)
        {
            if (!pageId.IsValidPageId())
                return null;
            if (String.IsNullOrEmpty(title))
                return null;
            if (String.IsNullOrEmpty(message))
                return null;
            if (String.IsNullOrEmpty(imageUrl))
                return null;
            if (String.IsNullOrEmpty(couponType))
                return null;
            if (claimLimit < 0)
                return null;
            if (String.IsNullOrEmpty(redemptionLink))
                return null;
            if (String.IsNullOrEmpty(redemptionCode))
                return null;
            if (String.IsNullOrEmpty(barcodeType))
                return null;
            if (String.IsNullOrEmpty(barcode))
                return null;

            Type = ObjectStorySpecType.OfferPageData;
            PageId = pageId;
            Title = title;
            Message = message;
            ImageUrl = imageUrl;
            CouponType = couponType;
            ExpirationTime = expirationTime;
            ReminderTime = reminderTime;
            ClaimLimit = claimLimit;
            RedemptionLink = redemptionLink;
            RedemptionCode = redemptionCode;
            BarcodeType = barcodeType;
            Barcode = barcode;

            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Text ad
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ObjectStorySpec SetPageTextAd(long pageId, string message)
        {
            if (!pageId.IsValidPageId())
                return null;
            if (String.IsNullOrEmpty(message))
                return null;

            Type = ObjectStorySpecType.TextPageData;
            PageId = pageId;
            Message = message;

            return this;
        }

        public ObjectStorySpec SetPageMultiProductAd(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops, IList<ChildAttachments> childAttachments)
        {
            if (!pageId.IsValidPageId())
                return null;
            if (String.IsNullOrEmpty(link))
                return null;
            if (String.IsNullOrEmpty(message))
                return null;
            if (String.IsNullOrEmpty(name))
                return null;
            if (String.IsNullOrEmpty(caption))
                return null;
            if (String.IsNullOrEmpty(description))
                return null;
            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
                return null;
            if (String.IsNullOrEmpty(imageCrops))
                return null;
            if (!childAttachments.Any() || childAttachments != null)
                return null;
            
            Type = ObjectStorySpecType.MultiProductData;
            PageId = pageId;
            Link = link;
            Message = message;
            Name = name;
            Caption = caption;
            Description = description;
            if (picture != null)
                Picture = picture;
            else
                ImageHash = imageHash;
            CallToAction = callToAction;
            ImageCrops = imageCrops;
            ChildAttachments = childAttachments;
            return this;
        }
    }
}
