using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     Targeting mobile user device
    /// </summary>
    public class TargetingUserDevice : BaseObject
    {
        #region Dependencies
        
        private readonly IAdTargetingSearchRepository adTargetingSearchRepository;

        #endregion Dependencies

        #region Construtor
        
        public TargetingUserDevice(IAdTargetingSearchRepository adTargetingSearchRepository)
        {
            this.adTargetingSearchRepository = adTargetingSearchRepository;
        }

        #endregion Construtor

        #region Properties

        /// <summary>
        ///     Audience size
        /// </summary>
        [FacebookName("audience_size")]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AudienceSize { get; private set; }

        /// <summary>
        ///     User device description
        /// </summary>
        [FacebookName("description")]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Description { get; private set; }

        /// <summary>
        ///     User device name
        /// </summary>
        [FacebookName("name")]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Name { get; private set; }

        #endregion Properties
        
        public IList<TargetingUserDevice> ReadAll()
        {
            return this.adTargetingSearchRepository.ReadUserDeviceList();
        }
    }
}