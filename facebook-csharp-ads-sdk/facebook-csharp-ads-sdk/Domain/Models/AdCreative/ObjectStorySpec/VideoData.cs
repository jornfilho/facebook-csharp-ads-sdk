using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    /// <summary>
    /// Content for creating a video page post
    /// </summary>
    public class VideoData
    {
        /// <summary>
        /// ID of a Facebook page
        /// </summary>
        [FacebookName("page_id")]
        public long PageId { get; private set; }

        /// <summary>
        /// Id of video that user has permission to or a video in ad account video library
        /// </summary>
        [FacebookName("video_id")]
        public long VideoId { get; private set; }

        /// <summary>
        /// Title for video
        /// </summary>
        [FacebookName("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Description of the video
        /// </summary>
        [FacebookName("description")]
        public string Description { get; private set; }

        /// <summary>
        /// URL of image to use as thumbnail
        /// </summary>
        [FacebookName("image_url")]
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Hash of an image in your image library with Facebook to use as thumbnail
        /// </summary>
        [FacebookName("image_hash")]
        public string ImageHash { get; private set; }

        /// <summary>
        /// An optional call to action
        /// </summary>
        [FacebookName("call_to_action")]
        public CallToActionTypeEnum CallToAction { get; private set; }
    }
}
