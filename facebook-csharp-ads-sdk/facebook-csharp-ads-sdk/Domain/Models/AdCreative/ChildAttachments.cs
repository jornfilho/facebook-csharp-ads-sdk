using System;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative
{
    /// <summary>
    ///     A three elements array of link objects required for multi products ads
    /// </summary>
    public class ChildAttachments : BaseObject
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
        /// <param name="link"> The Url of a link to attach to the post </param>
        /// <param name="picture"> Determines the preview image associated with the link </param>
        /// <param name="imageHash"> Hash of a preview image associated with the link from your image library </param>
        /// <param name="name"> The title of the link preview </param>
        /// <param name="description"> Used to show either a price, discount or website domain </param>
        /// <exception cref="InvalidAdCreativeLinkException"> Invalid ad creative link </exception>
        /// <exception cref="InvalidAdCreativeImageException"> Invalid ad creative image </exception>
        /// <exception cref="InvalidAdCreativeNameException"> Invalid ad creative name </exception>
        /// <exception cref="InvalidAdCreativeDescriptionException"> Invalid ad creative description </exception>
        /// <returns> A child with the valid parameters </returns>
        public ChildAttachments SetData(string link, string picture, string imageHash, string name, string description)
        {

            ValidateDataToSetChildAttachment(link, picture, imageHash, name, description);

            Link = link;
            if (!String.IsNullOrEmpty(picture))
                Picture = picture;
            else
                ImageHash = imageHash;
            Name = name;
            Description = description;
            SetValid();
            return this;
        }

        private void ValidateDataToSetChildAttachment(string link, string picture, string imageHash, string name, string description)
        {
            if (String.IsNullOrEmpty(link))
            {
                throw new InvalidAdCreativeLinkException();
            }

            if (String.IsNullOrEmpty(picture) && String.IsNullOrEmpty(imageHash))
            {
                throw new InvalidAdCreativeImageException();
            }

            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidAdCreativeNameException();
            }

            if (String.IsNullOrEmpty(description))
            {
                throw new InvalidAdCreativeDescriptionException();
            }
            
        }
    }
}
