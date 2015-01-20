using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevUtils.ObjectExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
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
        private readonly ICreativeRepository creativeRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="creativeRepository">Interface of the creative repository</param>
        public AdCreative(ICreativeRepository creativeRepository)
        {
            this.creativeRepository = creativeRepository;
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
        public bool FollowRedirect { get; private set; }

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
        /// <param name="objectUrl"> Object url of the ad creative</param>
        /// <param name="name"> Name of the ad creative in the creative library </param>
        /// <param name="actorId">Actor id of the ad creative </param>
        /// <param name="followRedirect">Follow Redirect of the ad creative</param>
        /// <returns> Ad Creative with the Link Ad Parameters </returns>
        public AdCreative SetLinkAdData(long id, long accountId, string title, string body, string objectUrl, string name,
            string actorId, bool? followRedirect)
        {
            if (!id.IsValidAdCreativeId())
                return this;
            if (!accountId.IsValidAdAccountId())
                return this;
            if (String.IsNullOrEmpty(title))
                return this;
            if (String.IsNullOrEmpty(body))
                return this;
            if (String.IsNullOrEmpty(objectUrl))
                return this;
            Type = AdCreativeTypeEnum.LinkAd;
            Id = id;
            AccountId = accountId;
            Title = title;
            Body = body;
            ObjectUrl = objectUrl;
            if (!String.IsNullOrEmpty(name))
                Name = name;
            if (!String.IsNullOrEmpty(actorId))
                ActorId = actorId;
            if (followRedirect != null) FollowRedirect = (bool) followRedirect;
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
        /// <param name="imageCrops"> Image Crops of the ad creative </param>
        /// <param name="title"> Title of the ad creative </param>
        /// <returns> Ad Creative with the Pag Link ad Parameters </returns>
        public AdCreative SetPageLikeAdData(long id, long accountId, string objectId, string body, string name, string linkUrl, string imageCrops, string title)
        {
            if (!id.IsValidAdCreativeId())
                return this;
            if (!accountId.IsValidAdAccountId())
                return this;
            if (String.IsNullOrEmpty(objectId))
                return this;
            if (String.IsNullOrEmpty(body))
                return this;
            Type = AdCreativeTypeEnum.PageLikeAd;
            Id = id;
            AccountId = accountId;
            ObjectId = objectId;
            Body = body;
            if (!String.IsNullOrEmpty(name)) 
                Name = name;
            if (!String.IsNullOrEmpty(linkUrl)) 
                LinkUrl = linkUrl;
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
        /// <returns></returns>
        public AdCreative SetEventAdData(long id, long accountId, string objectId, string body, string name, string imageFile, string imageCrops, string title)
        {
            if (!id.IsValidAdCreativeId())
                return this;
            if (!accountId.IsValidAdAccountId())
                return this;
            if (String.IsNullOrEmpty(objectId))
                return this;
            if (String.IsNullOrEmpty(body))
                return this;
            Type = AdCreativeTypeEnum.EventAd;
            Id = id;
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
        ///     Set page link ad creative data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
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
        public AdCreative SetPageLinkAdData(long id, long accountId, long pageId, string link, string message, string name, string caption,
            string description, string picture, string imageHash, CallToActionTypeEnum callToAction, string imageCrops)
        {
            if (!id.IsValidAdCreativeId())
                return this;
            if (!accountId.IsValidAdAccountId())
                return this;
            var objectStorySpec = new ObjectStorySpec();
            objectStorySpec = objectStorySpec.SetPageLinkAd(pageId, link, message, name, caption, description, picture,
                imageHash, callToAction, imageCrops);
            if (objectStorySpec == null)
                return this;
            Type = AdCreativeTypeEnum.PageLinkAd;
            Id = id;
            AccountId = accountId;
            ObjectStorySpec = objectStorySpec;
            SetValid();
            return this;

        }

        /// <summary>
        ///     Set Page photo ad creative data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <param name="pageId"></param>
        /// <param name="url"></param>
        /// <param name="imageHash"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public AdCreative SetPagePhotoAdData(long id, long accountId, long pageId, string url, string imageHash, string caption)
        {
            if (!id.IsValidAdCreativeId())
                return this;
            if (!accountId.IsValidAdAccountId())
                return this;
            var objectStorySpec = new ObjectStorySpec();
            objectStorySpec = objectStorySpec.SetPagePhotoAd(pageId, url, imageHash, caption);
            if (objectStorySpec == null)
                return this;
            Type = AdCreativeTypeEnum.PagePhotoAd;
            Id = id;
            AccountId = accountId;
            ObjectStorySpec = objectStorySpec;
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

                return this.creativeRepository.Create(this).Result;
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
                bool success = this.Id.IsValidAdCreativeId() && this.creativeRepository.Delete(Id).Result;
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

        public Dictionary<string, string> GetSingleCreateParams()
        {
            throw new System.NotImplementedException();
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
                    ? creativeRepository.Read(id).Result
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
                    ? creativeRepository.Read(id, fields).Result
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

        #endregion Private methods
    }
}
