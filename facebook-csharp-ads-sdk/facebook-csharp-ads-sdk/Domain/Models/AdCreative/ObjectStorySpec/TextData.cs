using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    public class TextData
    {
        /// <summary>
        /// ID of a Facebook page
        /// </summary>
        [FacebookName("page_id")]
        public long PageId { get; private set; }

        /// <summary>
        /// Status message.
        /// </summary>
        [FacebookName("message")]
        public string Message { get; private set; }
    }
}
