using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     Targeting demographics and events model
    /// </summary>
    public class TargetingDemographics
    {
        /// <summary>
        ///     Indicates gender-based targeting
        /// </summary>
        [FacebookName("genders")]
        [DefaultValue(null)]
        public IList<GenderTypeEnum> Genders { get; private set; }

        /// <summary>
        ///     Age min 
        /// </summary>
        [FacebookName("age_min")]
        [DefaultValue(null)]
        public int? AgeMin { get; private set; }

        /// <summary>
        ///     Age max 
        /// </summary>
        [FacebookName("age_max")]
        [DefaultValue(null)]
        public int? AgeMax { get; private set; }
    }
}