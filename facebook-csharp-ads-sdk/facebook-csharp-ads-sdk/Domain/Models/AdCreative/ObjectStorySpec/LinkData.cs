using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    /// <summary>
    /// Content for creating a link page post or a multi product ad
    /// </summary>
    public class LinkData
    {
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
        /// A three element Array of link objects required for multi product ads
        /// </summary>
        [FacebookName("child_attachments")]
        public IList<ChildAttachments> ChilAttachments { get; private set; }
    }
}
