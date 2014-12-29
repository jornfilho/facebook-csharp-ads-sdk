using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    public class TargetingPlacement
    {
        /// <summary>
        ///     List of placement options
        /// </summary>
        [FacebookName("page_types")]
        [DefaultValue(null)]
        public IList<PlacementTypeEnum> PageTypes { get; private set; }
    }
}