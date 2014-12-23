using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository.Base;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Interface of the ad set repository
    /// </summary>
    public interface IAdSetRepository : IBaseCrudRepository<AdSet>
    {
        /// <summary>
        ///     <para> Get the ad set by field list </para>
        /// </summary>
        /// <param name="adId"> Id of the ad set </param>
        /// <param name="fields"> Field list you wish to retrieve </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>/// 
        /// <returns> Ad set </returns>
        Task<AdSet> Read(long adId, IList<AdSetReadFieldsEnum> fields);
    }
}