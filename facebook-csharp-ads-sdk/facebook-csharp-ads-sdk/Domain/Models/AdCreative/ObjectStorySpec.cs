using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative
{
    /// <summary>
    /// The page id and the content to create a new unpublished page post
    /// </summary>
    public class ObjectStorySpec : BaseObject
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
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="link"> Link url </param>
        /// <param name="message"> Story message </param>
        /// <param name="name"> Name of the link </param>
        /// <param name="caption"> Link caption </param>
        /// <param name="description">Link description </param>
        /// <param name="picture"> Url of a picture to use in the post </param>
        /// <param name="imageHash"> Hash of an image in your image library with Facebook </param>
        /// <param name="callToAction"> An optional call to action </param>
        /// <param name="imageCrops"> How to display the image </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeLinkException"> Invalid ad creative Link </exception>
        /// <exception cref="InvalidAdCreativeMessageException"> Invalid ad creative Message </exception>
        /// <exception cref="InvalidAdCreativeNameException"> Invalid ad creative Name </exception>
        /// <exception cref="InvalidAdCreativeCaptionException"> Invalid ad creative Caption </exception>
        /// <exception cref="InvalidAdCreativeDescriptionException"> Invalid ad creative Description </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative Image </exception>
        /// <exception cref="InvalidAdCreativeCallToActionTypeException"> Invalid ad creative Call to action </exception>
        /// <exception cref="InvalidAdCreativeImageCropsException"> Invalid ad creative Image crops </exception>
        /// <returns> A Object with Page Link parameters </returns>
        public ObjectStorySpec SetPageLinkAd(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops)
        {
            ValidateDataToSetPageLinkObject(pageId, link, message, name, caption, description, picture, imageHash, callToAction, imageCrops);
            
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
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set Object story spec to Page Photo ad
        /// </summary>
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="url"> Url of an image to use in the post</param>
        /// <param name="imageHash"> Hash of an image in your image library with Facebook </param>
        /// <param name="caption"> Photo caption </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative image </exception>
        /// <exception cref="InvalidAdCreativeCaptionException"> Invalid ad creative caption </exception>
        /// <returns> A Object with Page Photo parameters </returns>
        public ObjectStorySpec SetPagePhotoAd(long pageId, string url, string imageHash, string caption)
        {

            ValidateDataToSetPagePhotoObject(pageId, url, imageHash, caption);

            Type = ObjectStorySpecType.PhotoPageData;
            PageId = pageId;
            if (url != null)
                Url = url;
            else ImageHash = imageHash;
            Caption = caption;
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Video ad
        /// </summary>
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="videoId"> Id of video </param>
        /// <param name="title"> Title for video </param>
        /// <param name="description"> Description of the video </param>
        /// <param name="imageUrl"> Url of image to use as thumbnail </param>
        /// <param name="imageHash"> Hash of an image in your image library with Facebook to use as thumbnail </param>
        /// <param name="callToAction"> An optional call to action </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeVideoIdException"> Invalid ad creative Video id </exception>
        /// <exception cref="InvalidAdCreativeTitleException"> Invalid ad creative Title </exception>
        /// <exception cref="InvalidAdCreativeDescriptionException"> Invalid ad creative Description </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative Image </exception>
        /// <exception cref="InvalidAdCreativeCallToActionTypeException"> Invalid ad creative Call to action </exception>
        /// <returns> A Object with Page Video parameters </returns>
        public ObjectStorySpec SetPageVideoAd(long pageId, long videoId, string title, string description, string imageUrl,
            string imageHash, CallToActionTypeEnum callToAction)
        {

            ValidateDataToSetPageVideoObject(pageId, videoId, title, description, imageUrl, imageHash, callToAction);

            PageId = pageId;
            VideoId = videoId;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            ImageHash = imageHash;
            CallToAction = callToAction;
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Offer ad
        /// </summary>
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="title"> The title of the offer </param>
        /// <param name="message"> The description text of the offer </param>
        /// <param name="imageUrl"> The url for the offer's image </param>
        /// <param name="couponType"> The type of offer </param>
        /// <param name="expirationTime"> The expiration time of the offer </param>
        /// <param name="reminderTime"> The reminder time of the offer </param>
        /// <param name="claimLimit"> The maximum number of times the offer can be claimed </param>
        /// <param name="redemptionLink"> The url where the offer may be redeemed </param>
        /// <param name="redemptionCode"> A code to receive the discount or promotion </param>
        /// <param name="barcodeType"> The barcode type of the offer </param>
        /// <param name="barcode"> The barcode of the offer </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeTitleException"> Invalid ad creative title </exception>
        /// <exception cref="InvalidAdCreativeMessageException"> Invalid ad creative message </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative image </exception>
        /// <exception cref="InvalidAdCreativeCouponTypeException"> Invalid ad creative coupon type </exception>
        /// <exception cref="InvalidAdCreativeExpirationTimeException"> Invalid ad creative expiration time </exception>
        /// <exception cref="InvalidAdCreativeReminderTimeException"> Invalid ad creative reminder time </exception>
        /// <exception cref="InvalidAdCreativeClaimLimitException"> Invalid ad creative claim limit </exception>
        /// <exception cref="InvalidAdCreativeRedemptionLinkException"> Invalid ad creative redemption link </exception>
        /// <exception cref="InvalidAdCreativeRedemptionCodeException"> Invalid ad creative redemption code </exception>
        /// <exception cref="InvalidAdCreativeBarcodeTypeException"> Invalid ad creative barcode type </exception>
        /// <exception cref="InvalidAdCreativeBarcodeException"> Invalid ad creative barcode </exception>
        /// <returns></returns>
        public ObjectStorySpec SetPageOfferAd(long pageId, string title, string message, string imageUrl, string couponType,
            DateTime expirationTime, DateTime reminderTime, int claimLimit, string redemptionLink, string redemptionCode,
            string barcodeType, string barcode)
        {
            ValidateDataToSetPageOfferObject(pageId, title, message, imageUrl, couponType, expirationTime, reminderTime, claimLimit, redemptionLink, redemptionCode, barcodeType, barcode);
            
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
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set object story spec to Page Text ad
        /// </summary>
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="message"> Status message </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeMessageException"> Invalid ad creative Message </exception>
        /// <returns> A object with Page Text parameters </returns>
        public ObjectStorySpec SetPageTextAd(long pageId, string message)
        {
            ValidateDataToSetPageTextObject(pageId, message);

            Type = ObjectStorySpecType.TextPageData;
            PageId = pageId;
            Message = message;
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set Object story spec to Page link ad
        /// </summary>
        /// <param name="pageId"> Id of a Facebook page </param>
        /// <param name="link"> Link url </param>
        /// <param name="message"> Story message </param>
        /// <param name="name"> Name of the link </param>
        /// <param name="caption"> Link caption </param>
        /// <param name="description">Link description </param>
        /// <param name="picture"> Url of a picture to use in the post </param>
        /// <param name="imageHash"> Hash of an image in your image library with Facebook </param>
        /// <param name="callToAction"> An optional call to action </param>
        /// <param name="imageCrops"> How to display the image </param>
        /// <param name="childAttachments"> A element array of link objects </param>
        /// <exception cref="InvalidAdCreativePageIdException"> Invalid ad creative Page id </exception>
        /// <exception cref="InvalidAdCreativeLinkException"> Invalid ad creative Link </exception>
        /// <exception cref="InvalidAdCreativeMessageException"> Invalid ad creative Message </exception>
        /// <exception cref="InvalidAdCreativeNameException"> Invalid ad creative Name </exception>
        /// <exception cref="InvalidAdCreativeCaptionException"> Invalid ad creative Caption </exception>
        /// <exception cref="InvalidAdCreativeDescriptionException"> Invalid ad creative Description </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative Image </exception>
        /// <exception cref="InvalidAdCreativeCallToActionTypeException"> Invalid ad creative Call to action </exception>
        /// <exception cref="InvalidAdCreativeImageCropsException"> Invalid ad creative Image crops </exception>
        /// <exception cref="InvalidAdCreativeChildAttachmentsException"> Invalid ad creative Child Attachments </exception>
        /// <returns> A object with Multi product parameters </returns>
        public ObjectStorySpec SetPageMultiProductAd(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops, IList<ChildAttachments> childAttachments)
        {
            ValidateDataToSetPageMultiProductObject(pageId, link, message, name, caption, description, picture, imageHash, callToAction, imageCrops, childAttachments);
            
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
            SetValid();
            return this;
        }

        #region Private methods

        private bool IsValidChildAttachmentsList(IList<ChildAttachments> childAttachments)
        {
            if (childAttachments == null || !childAttachments.Any())
                return false;

            if (childAttachments.ToArray().Length < 3 || childAttachments.ToArray().Length > 5)
                return false;

            return true;
        }

        private void ValidateDataToSetPageLinkObject(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops)
        {
            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (String.IsNullOrEmpty(link))
            {
                throw new InvalidAdCreativeLinkException();
            }

            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidAdCreativeMessageException();
            }

            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidAdCreativeNameException();
            }

            if (String.IsNullOrEmpty(caption))
            {
                throw new InvalidAdCreativeCaptionException();
            }

            if (String.IsNullOrEmpty(description))
            {
                throw new InvalidAdCreativeDescriptionException();
            }

            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (callToAction == CallToActionTypeEnum.Undefined)
            {
                throw new InvalidAdCreativeCallToActionTypeException();
            }

            if (String.IsNullOrEmpty(imageCrops))
            {
                throw new InvalidAdCreativeImageCropsException();
            }
        }

        private void ValidateDataToSetPagePhotoObject(long pageId, string url, string imageHash, string caption)
        {
            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (String.IsNullOrEmpty(url) && String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (String.IsNullOrEmpty(caption))
            {
                throw new InvalidAdCreativeCaptionException();
            }
        }

        private void ValidateDataToSetPageVideoObject(long pageId, long videoId, string title, string description, string imageUrl,
            string imageHash, CallToActionTypeEnum callToAction)
        {
            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (!videoId.IsValidVideoId())
            {
                throw new InvalidAdCreativeVideoIdException();
            }

            if (String.IsNullOrEmpty(title))
            {
                throw new InvalidAdCreativeTitleException();
            }

            if (String.IsNullOrEmpty(description))
            {
                throw new InvalidAdCreativeDescriptionException();
            }

            if (String.IsNullOrEmpty(imageUrl))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (callToAction == CallToActionTypeEnum.Undefined)
            {
                throw new InvalidAdCreativeCallToActionTypeException();
            }
            
        }

        private void ValidateDataToSetPageOfferObject(long pageId, string title, string message, string imageUrl, string couponType,
            DateTime expirationTime, DateTime reminderTime, int claimLimit, string redemptionLink, string redemptionCode,
            string barcodeType, string barcode)
        {
            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (String.IsNullOrEmpty(title))
            {
                throw new InvalidAdCreativeTitleException();
            }

            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidAdCreativeMessageException();
            }

            if (String.IsNullOrEmpty(imageUrl))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (String.IsNullOrEmpty(couponType))
            {
                throw new InvalidAdCreativeCouponTypeException();
            }

            if (expirationTime < DateTime.UtcNow)
            {
                throw new InvalidAdCreativeExpirationTimeException();
            }

            if (reminderTime < DateTime.UtcNow || reminderTime > expirationTime)
            {
                throw new InvalidAdCreativeReminderTimeException();
            }

            if (claimLimit <= 0)
            {
                throw new InvalidAdCreativeClaimLimitException();
            }

            if (String.IsNullOrEmpty(redemptionLink))
            {
                throw new InvalidAdCreativeRedemptionLinkException();
            }

            if (String.IsNullOrEmpty(redemptionCode))
            {
                throw new InvalidAdCreativeRedemptionCodeException();
            }

            if (String.IsNullOrEmpty(barcodeType))
            {
                throw new InvalidAdCreativeBarcodeTypeException();
            }
            if (String.IsNullOrEmpty(barcode))
            {
                throw new InvalidAdCreativeBarcodeException();
            }
            
        }

        private void ValidateDataToSetPageTextObject(long pageId, string message)
        {
            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidAdCreativeMessageException();
            }
        }

        private void ValidateDataToSetPageMultiProductObject(long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops, IList<ChildAttachments> childAttachments)
        {

            if (!pageId.IsValidPageId())
            {
                throw new InvalidAdCreativePageIdException();
            }

            if (String.IsNullOrEmpty(link))
            {
                throw new InvalidAdCreativeLinkException();
            }

            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidAdCreativeMessageException();
            }

            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidAdCreativeNameException();
            }

            if (String.IsNullOrEmpty(caption))
            {
                throw new InvalidAdCreativeCaptionException();
            }

            if (String.IsNullOrEmpty(description))
            {
                throw new InvalidAdCreativeDescriptionException();
            }

            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (callToAction == CallToActionTypeEnum.Undefined)
            {
                throw new InvalidAdCreativeCallToActionTypeException();
            }

            if (String.IsNullOrEmpty(imageCrops))
            {
                throw new InvalidAdCreativeImageCropsException();
            }

            if (!IsValidChildAttachmentsList(childAttachments))
            {
                throw new InvalidAdCreativeChildAttachmentsException();
            }
        }

        #endregion Private methods
    }
}
