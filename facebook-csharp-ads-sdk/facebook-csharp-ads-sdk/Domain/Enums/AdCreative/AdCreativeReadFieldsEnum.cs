using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCreative
{
    /// <summary>
    ///     Fields of Ad Creative to read
    /// </summary>
    public enum AdCreativeReadFieldsEnum
    {
        /// <summary>
        /// Id of Ad Creative
        /// </summary>
        [FacebookName("id")]
        Id,

        /// <summary>
        /// Facebook object id  that is the actor for a link ad
        /// </summary>
        [FacebookName("actor_id")]
        ActorId,

        /// <summary>
        /// The body of the ad
        /// </summary>
        [FacebookName("body")]
        Body,

        /// <summary>
        /// Call to action button text
        /// </summary>
        [FacebookName("call_to_action_type")]
        CallToActionType,

        /// <summary>
        /// Parameter that indicates that facebook should follow any HTTP redirects encountered at the link_url
        /// </summary>
        [FacebookName("follow_redirect")]
        FollowRedirect,

        /// <summary>
        /// A JSON object defining crop dimensions for the image specified
        /// </summary>
        [FacebookName("image_crops")]
        ImageCrops,

        /// <summary>
        /// Reference to a local image file to upload for use in creatives
        /// </summary>
        [FacebookName("Image_file")]
        ImageFile,

        /// <summary>
        /// Image ID for an image you can use in creatives
        /// </summary>
        [FacebookName("image_hash")]
        ImageHash,

        /// <summary>
        /// A URL for the image for this creative
        /// </summary>
        [FacebookName("image_url")]
        ImageUrl,

        /// <summary>
        /// Used to identify a specific landing tab on the Page
        /// </summary>
        [FacebookName("link_url")]
        LinkUrl,

        /// <summary>
        /// The name of the creative in the creative library
        /// </summary>
        [FacebookName("name")]
        Name,

        /// <summary>
        /// The facebook object ID that is relevant to the ad and ad type
        /// </summary>
        [FacebookName("object_id")]
        ObjectId,

        /// <summary>
        /// The ID of a page post to use in an ad
        /// </summary>
        [FacebookName("object_story_id")]
        ObjectStoryId,

        /// <summary>
        /// The page id and the content to create a new unpublished page post 
        /// </summary>
        [FacebookName("object_story_spec")]
        ObjectStorySpec,

        /// <summary>
        /// Destination URL for a link ad
        /// </summary>
        [FacebookName("object_url")]
        ObjectUrl,

        /// <summary>
        /// Title for a link ad 
        /// </summary>
        [FacebookName("title")]
        Title,

        /// <summary>
        /// A set of query string parameters
        /// </summary>
        [FacebookName("url_tags")]
        UrlTags
    }
}
