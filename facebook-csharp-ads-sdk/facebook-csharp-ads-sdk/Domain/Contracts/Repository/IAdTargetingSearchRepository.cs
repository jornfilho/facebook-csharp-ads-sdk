using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Models.Targetings;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Ad Targeting Search API interface
    /// </summary>
    public interface IAdTargetingSearchRepository
    {
        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <returns> List of the user device </returns>
        IList<TargetingUserDevice> ReadUserDeviceList();
        
        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <param name="autoComplete"> The string for which you want autocomplete values. </param>
        /// <returns> List of the interests </returns>
        IList<TargetingInterests> ReadInterestsList(string autoComplete);
    }
}
