using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     Promoted Object describes the thing an ad set is promoting
    /// </summary>
    public class PromotedObject : BaseObject
    {
        /// <summary>
        ///     Pixel id
        /// </summary>
        [FacebookName("pixel_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? PixelId { get; private set; }

        /// <summary>
        ///     Page id
        /// </summary>
        [FacebookName("page_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? PageId { get; private set; }

        /// <summary>
        ///     Offer id
        /// </summary>
        [FacebookName("offer_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? OfferId { get; private set; }
        
        /// <summary>
        ///     Application id
        /// </summary>
        [FacebookName("application_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? ApplicationId { get; private set; }

        /// <summary>
        ///     Url of object promoted
        /// </summary>
        [FacebookName("object_store_url")]
        [FacebookFieldTypeAttribute(FacebookFieldType.String)]
        public string ObjectStoreUrl { get; private set; }
    }
}
