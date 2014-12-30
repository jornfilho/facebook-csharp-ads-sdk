using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IList<TargetingUserDevice>> ReadUserDeviceList();
    }
}
