using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative
{
    /// <summary>
    ///     <para> Facebook Ad Creative </para>
    ///     <para>https://developers.facebook.com/docs/reference/ads-api/adcreative/v2.2</para>
    /// </summary>
    public class AdCreative : BaseCrudObject<AdCreative>
    {

        #region Dependencies

        /// <summary>
        ///     Interface of creative repository
        /// </summary>
        private readonly ICreativeRepository _creativeRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="creativeRepository">Interface of the creative repository</param>
        public AdCreative(ICreativeRepository creativeRepository)
        {
            _creativeRepository = creativeRepository;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The Id of the creative
        /// </summary>
        [FacebookName("id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        [IsFacebookCreateResponseAttribute(true)]
        public long Id { get; private set; }
        
        /// <summary>
        ///     The account id of the creative
        /// </summary>
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public long AccountId { get; private set; }

        /// <summary>
        /// The Facebook object ID that is the actor for a link ad
        /// </summary>
        [FacebookName("actor_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ActorId { get; private set; }

        /// <summary>
        /// Body of the ad
        /// </summary>
        [FacebookName("body")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Body { get; private set; }

        /// <summary>
        /// Determines the call to action button text and header text of an ad
        /// </summary>
        [FacebookName("call_to_action_type")]
        [DefaultValue(1)]
        [FacebookFieldType(FacebookFieldType.CallToActionTypeEnum)]
        public CallToActionTypeEnum CallToActionType { get; private set; }

        /// <summary>
        /// Providing this parameter indicates that Facebook should follow any HTTP
        /// redirects encountered at the link_url
        /// </summary>
        [FacebookName("follow_redirect")]
        [DefaultValue(false)]
        [FacebookFieldType(FacebookFieldType.Boolean)]
        public bool? FollowRedirect { get; private set; }

        /// <summary>
        /// A JSON object defining crop dimensions for the image specified
        /// </summary>
        [FacebookName("image_crops")]
        [DefaultValue(null)]
        public string ImageCrops { get; private set; }

        /// <summary>
        /// Reference to a local image file to upload for use in creatives
        /// </summary>
        [FacebookName("image_file")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ImageFile { get; private set; }
        
        /// <summary>
        /// Image ID for an image you can use in creatives
        /// </summary>
        [FacebookName("image_hash")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ImageHash { get; private set; }

        /// <summary>
        /// A URL for the image for this creative
        /// </summary>
        [FacebookName("image_url")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Used to identify a specific landing tab on the Page
        /// </summary>
        [FacebookName("link_url")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string LinkUrl { get; private set; }

        /// <summary>
        /// The name of the creative in the creative library
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        [CanUpdateOnFacebook(true)]
        public string Name { get; private set; }

        /// <summary>
        /// The Facebook object ID that is relevant to the ad and ad type
        /// </summary>
        [FacebookName("object_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ObjectId { get; private set; }

        /// <summary>
        /// The ID of a page post to use in an ad
        /// </summary>
        [FacebookName("object_story_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ObjectStoryId { get; private set; }

        /// <summary>
        /// The page id and the content to create a new unpublished page post
        /// </summary>
        [FacebookName("object_story_spec")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public ObjectStorySpec ObjectStorySpec { get; private set; }

        /// <summary>
        /// Destination URL for a link ad
        /// </summary>
        [FacebookName("object_url")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string ObjectUrl { get; private set; }

        /// <summary>
        /// Title for a link ad
        /// </summary>
        [FacebookName("title")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Title { get; private set; }

        /// <summary>
        /// A set of query string parameters which will replace or be
        /// appended to urls clicked
        /// </summary>
        [FacebookName("url_tags")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string UrlTags { get; private set; }

        /// <summary>
        /// Type of the ad creative
        /// </summary>
        [DefaultValue(null)]
        public AdCreativeTypeEnum Type { get; private set; }

        #endregion Properties

        /// <summary>
        ///     Set Link Ad creative data
        /// </summary>
        /// <param name="id"> Id of the ad creative </param>
        /// <param name="accountId"> Account id of the ad creative </param>
        /// <param name="title"> Title of the ad creative </param>
        /// <param name="body"> Body of the ad creative </param>
        /// <param name="objectUrl"> Object url of the ad creative </param>
        /// <param name="imageFile"> Reference to a local image file to upload for use in creatives </param>
        /// <param name="imageHash"> Image id for an image you can use in creatives </param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <param name="actorId">Actor id of the ad creative </param>
        /// <param name="followRedirect">Follow Redirect of the ad creative</param>
        /// <exception cref="InvalidAdCreativeIdException"> Invalid ad creative id </exception>
        /// <exception cref="InvalidAdAccountId"> Invalid ad account id </exception>
        /// <exception cref="InvalidAdCreativeTitleException"> Invalid ad creative title </exception>
        /// <exception cref="InvalidAdCreativeBodyException"> Invalid ad creative body </exception>
        /// <exception cref="InvalidAdCreativeObjectUrlException"> Invalid ad creative object url </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative image </exception>
        /// <returns> Ad Creative with the Link Ad Parameters </returns>
        public AdCreative SetLinkAdData(long accountId, string title, string body, string objectUrl, string imageFile, string imageHash, string name,
            string actorId, bool? followRedirect)
        {
            ValidateDataToSetLinkAdCreative(accountId, title, body, objectUrl, imageFile, imageHash);
            
            Type = AdCreativeTypeEnum.LinkAd;
            AccountId = accountId;
            Title = title;
            Body = body;
            ObjectUrl = objectUrl;
            if (!String.IsNullOrEmpty(imageFile))
                ImageFile = imageFile;
            else
                ImageHash = imageHash;
            if (!String.IsNullOrEmpty(name))
                Name = name;
            if (!String.IsNullOrEmpty(actorId))
                ActorId = actorId;
            if (followRedirect != null) 
                FollowRedirect = (bool) followRedirect;

            SetValid();
            return this;
        }

        /// <summary>
        ///     Set Page Like Ad creative data
        /// </summary>
        /// <param name="id"> Id of the ad creative </param>
        /// <param name="accountId"> Account id of the ad creative </param>
        /// <param name="objectId"> Object Id of the ad creative </param>
        /// <param name="body"> Body of the ad creative </param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <param name="linkUrl"> Link Url of the ad creative </param>
        /// <param name="imageFile"> Reference to a local image file </param>
        /// <param name="imageHash"> Image Id for an image </param>
        /// <param name="imageCrops"> Image Crops of the ad creative </param>
        /// <param name="title"> Title of the ad creative </param>
        /// <exception cref="InvalidAdCreativeIdException"> Invalid ad creative id </exception>
        /// <exception cref="InvalidAdAccountId"> Invalid ad account id </exception>
        /// <exception cref="InvalidAdCreativeObjectIdException"> Invalid ad creative object id </exception>
        /// <exception cref="InvalidAdCreativeBodyException"> Invalid ad creative body </exception>
        /// <returns> Ad Creative with the Page Link ad Parameters </returns>
        public AdCreative SetPageLikeAdData(long accountId, string objectId, string body, string name, string linkUrl, string imageFile, string imageHash, string imageCrops, string title)
        {
            ValidateDataToSetPageLikeAdCreative(accountId, objectId, body);
            
            Type = AdCreativeTypeEnum.PageLikeAd;
            AccountId = accountId;
            ObjectId = objectId;
            Body = body;
            if (!String.IsNullOrEmpty(name)) 
                Name = name;
            if (!String.IsNullOrEmpty(linkUrl)) 
                LinkUrl = linkUrl;
            if (!String.IsNullOrEmpty(imageFile))
                ImageFile = imageFile;
            else if (!String.IsNullOrEmpty(imageHash))
                ImageHash = imageHash;
            if (!String.IsNullOrEmpty(imageCrops)) 
                ImageCrops = imageCrops;
            if (!String.IsNullOrEmpty(title)) 
                Title = title;
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set Event Ad creative data
        /// </summary>
        /// <param name="id"> Id of the ad creative </param>
        /// <param name="accountId"> Account id of the ad creative </param>
        /// <param name="objectId"> Object Id of the ad creative </param>
        /// <param name="body"> Body of the ad creative </param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <param name="imageFile"> Image File of the ad creative </param>
        /// <param name="imageCrops"> Image Crops of the ad creative </param>
        /// <param name="title"> Title of the ad creative </param>
        /// <exception cref="InvalidAdCreativeIdException"> Invalid ad creative id </exception>
        /// <exception cref="InvalidAdAccountId"> Invalid ad account id </exception>
        /// <exception cref="InvalidAdCreativeObjectIdException"> Invalid ad creative object id </exception>
        /// <exception cref="InvalidAdCreativeBodyException"> Invalid ad creative body </exception>
        /// <returns> Ad Creative with Event ad Parameters </returns>
        public AdCreative SetEventAdData(long accountId, string objectId, string body, string name, string imageFile, string imageCrops, string title)
        {
            ValidateDataToSetEventAdCreative(accountId, objectId, body);

            Type = AdCreativeTypeEnum.EventAd;
            AccountId = accountId;
            ObjectId = objectId;
            Body = body;
            if (!String.IsNullOrEmpty(name))
                Name = name;
            if (!String.IsNullOrEmpty(imageFile))
                ImageFile = imageFile;
            if (!String.IsNullOrEmpty(imageCrops))
                ImageCrops = imageCrops;
            if (!String.IsNullOrEmpty(title))
                Title = title;
            SetValid();
            return this;
        }

        /// <summary>
        ///     Set a Page Post Ad Criative to inline creation
        /// </summary>
        /// <param name="id"> Id of the ad creative </param>
        /// <param name="accountId"> Account id of the ad creative </param>
        /// <param name="objectStorySpec"> The page id and the content to create a new unpublished page post</param>
        /// <param name="urlTags"> A set of query string parameters </param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <exception cref="InvalidAdCreativeIdException"> Invalid ad creative id </exception>
        /// <exception cref="InvalidAdAccountId"> Invalid ad account id </exception>
        /// <exception cref="InvalidAdCreativeObjectStorySpecException"> Invalid ad creative object story spec </exception>
        /// <returns> Ad Creative with Page Post ad Parameters </returns>
        public AdCreative SetPagePostAdData(long accountId, ObjectStorySpec objectStorySpec, string urlTags, string name)
        {
            ValidateDataToSetPagePostAdCreative(accountId, objectStorySpec);
            
            Type = SetAdCreativeTypeByObjectStorySpec(objectStorySpec);
            AccountId = accountId;
            ObjectStorySpec = objectStorySpec;
            if (urlTags != null)
                UrlTags = urlTags;
            if (name != null)
                Name = name;

            SetValid();
            return this;
        }

        /// <summary>
        ///     Set a Page Post Ad Criative using an existing page post
        /// </summary>
        /// <param name="id"> Id of the ad creative </param>
        /// <param name="accountId"> Account id of the ad creative </param>
        /// <param name="objectStoryId"> The ID of a page post to use in an ad </param>
        /// <param name="urlTags"> A set of query string parameters </param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <exception cref="InvalidAdCreativeIdException"> Invalid ad creative id </exception>
        /// <exception cref="InvalidAdAccountId"> Invalid ad account id </exception>
        /// <exception cref="InvalidAdCreativeObjectStoryIdException"> Invalid ad creative object story id </exception>
        /// <returns> Ad Creative with Page Post ad Parameters </returns>
        public AdCreative SetPagePostAdData(long accountId, string objectStoryId, string urlTags, string name)
        {

            ValidateDataToSetPagePostAdCreative(accountId, objectStoryId);
            AccountId = accountId;
            ObjectStoryId = objectStoryId;
            if (urlTags != null)
                UrlTags = urlTags;
            if (name != null)
                Name = name;

            SetValid();
            return this;
        }

        /// <summary>
        ///     Create a ad creative in Facebook
        /// </summary>
        /// <returns></returns>
        public override AdCreative Create()
        {
            try
            {
                if (!this.CreateModelIsReady)
                {
                    this.SetInvalid();
                    return this;
                }

                return this._creativeRepository.Create(this).Result;
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }
        
        /// <summary>
        ///     Delet the ad creative in Facebook
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            try
            {
                bool success = this.Id.IsValidAdCreativeId() && this._creativeRepository.Delete(Id).Result;
                SetInvalidUpdateModel();
                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Delete the ad creative in Facebook
        /// </summary>
        /// <param name="id">Id of the ad creative</param>
        /// <returns></returns>
        public override bool Delete(long id)
        {
            try
            {
                Id = id;
                return Delete();
            }
            catch (Exception)
            {

                return false;
            }
        }
        
        /// <summary>
        ///     Read ad creative by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single ad creative</returns>
        public override AdCreative ReadSingle(long id)
        {
            try
            {
                return id.IsValidAdCreativeId()
                    ? _creativeRepository.Read(id).Result
                    : this;
            }
            catch (Exception)
            {
                return this;
            }
        }
        
        /// <summary>
        ///     Read ad creative by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ad creative with the fields passed</returns>
        public AdCreative ReadSingle(long id, IList<AdCreativeReadFieldsEnum> fields)
        {
            try
            {
                return id.IsValidAdCreativeId()
                    ? _creativeRepository.Read(id, fields).Result
                    : this;
            }
            catch (Exception)
            {
                return this;
            }
        }

        public override AdCreative Update()
        {
            throw new System.NotImplementedException();
        }

        public override AdCreative Update(long id)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetSingleUpdateParams()
        {
            throw new System.NotImplementedException();
        }

        #region Private methods

        protected override string ParsePropertyValueToFacebookValue(FacebookFieldType fieldType, object currentValue)
        {
            throw new System.NotImplementedException();
        }

        private AdCreativeTypeEnum SetAdCreativeTypeByObjectStorySpec(ObjectStorySpec objectStorySpec)
        {

            switch (objectStorySpec.Type)
            {
                case ObjectStorySpecType.PhotoPageData:
                    return AdCreativeTypeEnum.PagePhotoAd;
                case ObjectStorySpecType.LinkPageData:
                    return AdCreativeTypeEnum.PageLinkAd;
                case ObjectStorySpecType.VideoPageData:
                    return AdCreativeTypeEnum.PageVideoAd;
                case ObjectStorySpecType.OfferPageData:
                    return AdCreativeTypeEnum.PageOfferAd;
                case ObjectStorySpecType.MultiProductData:
                    return AdCreativeTypeEnum.PageMultiProductAd;
                default:
                    return AdCreativeTypeEnum.PageTextAd;
            }
        }

        private void ValidateDataToSetLinkAdCreative(long accountId, string title, string body, string objectUrl, string imageFile, string imageHash)
        {
            if (!accountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (String.IsNullOrEmpty(title))
            {
                throw new InvalidAdCreativeTitleException();
            }

            if (String.IsNullOrEmpty(body))
            {
                throw new InvalidAdCreativeBodyException();
            }

            if (String.IsNullOrEmpty(objectUrl))
            {
                throw new InvalidAdCreativeObjectUrlException();
            }

            if (String.IsNullOrEmpty(imageFile) && String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }
        }

        private void ValidateDataToSetPageLikeAdCreative(long accountId, string objectId, string body)
        {
            if (!accountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (String.IsNullOrEmpty(objectId))
            {
                throw new InvalidAdCreativeObjectIdException();
            }

            if (String.IsNullOrEmpty(body))
            {
                throw new InvalidAdCreativeBodyException();
            }
        }

        private void ValidateDataToSetEventAdCreative(long accountId, string objectId, string body)
        {
            if (!accountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (String.IsNullOrEmpty(objectId))
            {
                throw new InvalidAdCreativeObjectIdException();
            }

            if (String.IsNullOrEmpty(body))
            {
                throw new InvalidAdCreativeBodyException();
            }
        }

        private void ValidateDataToSetPagePostAdCreative(long accountId, ObjectStorySpec objectStorySpec)
        {
            if (!accountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (objectStorySpec == null)
            {
                throw new InvalidAdCreativeObjectStorySpecException();
            }
            
        }

        private void ValidateDataToSetPagePostAdCreative(long accountId, string objectStoryId)
        {
            if (!accountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (String.IsNullOrEmpty(objectStoryId))
            {
                throw new InvalidAdCreativeObjectStoryIdException();
            }
        }

        #endregion Private methods
    }
}
