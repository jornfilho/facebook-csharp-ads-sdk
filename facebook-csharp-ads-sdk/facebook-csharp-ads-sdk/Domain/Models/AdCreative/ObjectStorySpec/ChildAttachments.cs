using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    /// <summary>
    /// A three element Array of link objects required for multi product ads
    /// </summary>
    public class ChildAttachments
    {
        /// <summary>
        /// The URL of a link to attach to the post.
        /// </summary>
        [FacebookName("link")]
        public string Link { get; private set; }

        /// <summary>
        /// Determines the preview image associated with the link 
        /// </summary>
        [FacebookName("picture")]
        public string Picture { get; private set; }

        /// <summary>
        /// Hash of a preview image associated with the link from your image library
        /// </summary>
        [FacebookName("image_hash")]
        public string ImageHash { get; private set; }

        /// <summary>
        /// The title of the link preview
        /// </summary>
        [FacebookName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Used to show either a price, discount or website domain
        /// </summary>
        [FacebookName("description")]
        public string Description { get; private set; }
    }
}
