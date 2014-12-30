using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    /// <summary>
    /// Content for creating a photo page post
    /// </summary>
    public class PhotoData
    {
        /// <summary>
        /// ID of a Facebook page
        /// </summary>
        [FacebookName("page_id")]
        public long PageId { get; private set; }

        /// <summary>
        /// URL of an image to use in the post
        /// </summary>
        [FacebookName("url")]
        public string Url { get; private set; }

        /// <summary>
        /// Hash of an image in your image library with Facebook
        /// </summary>
        [FacebookName("image_hash")]
        public string ImageHash { get; private set; }

        /// <summary>
        /// Photo caption
        /// </summary>
        [FacebookName("caption")]
        public string Caption { get; private set; }
    }
}
