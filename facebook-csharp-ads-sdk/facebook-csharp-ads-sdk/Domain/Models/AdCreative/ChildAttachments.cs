using System;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative
{
    /// <summary>
    ///     A three elements array of link objects required for multi products ads
    /// </summary>
    public class ChildAttachments
    {
        /// <summary>
        /// The URL of a link to attach to the post
        /// </summary>
        [FacebookName("link")]
        public string Link { get; private set; }

        /// <summary>
        /// Preview image associated with the link
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
        /// Description used to show either a price, discount or website domain
        /// </summary>
        [FacebookName("description")]
        public string Description { get; private set; }

        /// <summary>
        ///     Set data to a element of multi product ads
        /// </summary>
        /// <param name="link"></param>
        /// <param name="picture"></param>
        /// <param name="imageHash"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public ChildAttachments SetData(string link, string picture, string imageHash, string name, string description)
        {
            if (String.IsNullOrEmpty(link))
                return null;
            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
                return null;
            if (String.IsNullOrEmpty(name))
                return null;
            if (String.IsNullOrEmpty(description))
                return null;

            Link = link;
            if (!String.IsNullOrEmpty(picture))
                Picture = picture;
            else
                ImageHash = imageHash;
            Name = name;
            Description = description;
            
            return this;
        }
    }
}
