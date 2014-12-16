using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     Promoted Object describes the thing an ad set is promoting
    /// </summary>
    public class PromotedObject
    {
        /// <summary>
        ///     Pixel id
        /// </summary>
        [FacebookName("pixel_id")]
        public long? PixelId { get; private set; }

        /// <summary>
        ///     Page id
        /// </summary>
        [FacebookName("page_id")]
        public long? PageId { get; private set; }

        /// <summary>
        ///     Offer id
        /// </summary>
        [FacebookName("offer_id")]
        public long? OfferId { get; private set; }

        /// <summary>
        ///     Url of object promoted
        /// </summary>
        [FacebookName("object_store_url")]
        public string ObjectStoreUrl { get; private set; }
    }
}
