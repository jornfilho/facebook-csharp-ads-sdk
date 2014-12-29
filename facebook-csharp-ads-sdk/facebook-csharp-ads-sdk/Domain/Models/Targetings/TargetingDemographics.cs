using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Exceptions.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     <para> Targeting demographics and events model </para>
    ///     <para> https://developers.facebook.com/docs/reference/ads-api/targeting-specs/#demographics </para>
    /// </summary>
    public class TargetingDemographics
    {
        /// <summary>
        ///     <para> Indicates gender-based targeting </para>
        ///     <para> 1 = male </para>
        ///     <para> 2 = female </para>
        ///     <para> Defaults to all. Do not specify 0 </para>
        /// </summary>
        [FacebookName("genders")]
        [DefaultValue(null)]
        public IList<GenderTypeEnum> Genders { get; private set; }

        /// <summary>
        ///     Minimum age. If used, must be 13 or higher. If omitted, will default to 18
        /// </summary>
        [FacebookName("age_min")]
        [DefaultValue(null)]
        public int? AgeMin { get; private set; }

        /// <summary>
        ///     Maximum age. If used, must be 65 or lower
        /// </summary>
        [FacebookName("age_max")]
        [DefaultValue(null)]
        public int? AgeMax { get; private set; }

        /// <summary>
        ///     Set attributes to create a targeting demographics
        /// </summary>
        /// <param name="ageMin"> Minimum age </param>
        /// <param name="ageMax"> Maximum age </param>
        /// <param name="genders"> Indicates gender-based targeting </param>
        /// <exception cref="TargetingDemographicsAgeMinMustBeGreatherThan13Exception"> If minimum age used, must be 13 or higher </exception>
        /// <exception cref="TargetingDemographicsAgeMaxMustBeLessThan65Exception"> If maximum age used, must be 65 or lower </exception>
        public TargetingDemographics SetAttributesToCreate(int? ageMin, int? ageMax, IList<GenderTypeEnum> genders)
        {
            if (ageMin != null && ageMin < 13)
            {
                throw new TargetingDemographicsAgeMinMustBeGreatherThan13Exception();
            }
            
            if (ageMax != null && ageMax > 65)
            {
                throw new TargetingDemographicsAgeMaxMustBeLessThan65Exception();
            }
            
            this.AgeMax = ageMax;
            this.AgeMin = ageMin;
            this.Genders = genders;
            return this;
        }
    }
}