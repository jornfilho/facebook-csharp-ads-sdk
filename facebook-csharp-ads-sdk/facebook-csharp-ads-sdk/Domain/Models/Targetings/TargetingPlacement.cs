using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     Targeting placement model
    /// </summary>
    public class TargetingPlacement
    {
        /// <summary>
        ///     List of placement options
        /// </summary>
        [FacebookName("page_types")]
        [DefaultValue(null)]
        public IList<PlacementTypeEnum> PageTypes { get; private set; }

        /// <summary>
        ///     Set attributes to create a targeting placement
        /// </summary>
        /// <param name="pageTypes"> Page types list </param>
        public TargetingPlacement SetAttributesToCreate(IList<PlacementTypeEnum> pageTypes)
        {
            this.PageTypes = pageTypes;
            return this;
        }
    }
}