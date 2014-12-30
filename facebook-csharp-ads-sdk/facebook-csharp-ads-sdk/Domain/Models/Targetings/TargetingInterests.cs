using System.Collections.Generic;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     <para> Interest targeting lets you target everyone who has expressed a specific interest </para>
    ///     <para>https://developers.facebook.com/docs/reference/ads-api/targeting-specs/#interests</para>
    /// </summary>
    public class TargetingInterests : BaseObject
    {
        #region Dependencies
        
        /// <summary>
        ///     Targeting search reporitory
        /// </summary>
        private readonly IAdTargetingSearchRepository adTargetingSearchRepository;

        #endregion Dependencies

        #region Construtor
        
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="adTargetingSearchRepository"> Targeting search reporitory </param>
        public TargetingInterests(IAdTargetingSearchRepository adTargetingSearchRepository)
        {
            this.adTargetingSearchRepository = adTargetingSearchRepository;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public TargetingInterests()
        {
        }

        #endregion Construtor

        #region Properties

        /// <summary>
        ///     Estimated audience size of the target audience
        /// </summary>
        [FacebookName("audience_size")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long AudienceSize { get; private set; }

        /// <summary>
        ///     Facebook ID of the interest targeting
        /// </summary>
        [FacebookName("id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long Id { get; private set; }

        /// <summary>
        ///     Name of the interest targeting
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Name { get; private set; }

        /// <summary>
        ///     Includes the category and any parent categories the targeting falls into
        /// </summary>
        [FacebookName("path")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.StringArray)]
        public IList<string> Path { get; private set; }

        #endregion Properties

        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <param name="autoComplete"> The string for which you want autocomplete values. </param>
        /// <returns> List of the interests </returns>
        public IList<TargetingInterests> ReadInterestsList(string autoComplete)
        {
            return this.adTargetingSearchRepository.ReadInterestsList(autoComplete);
        }
    }
}