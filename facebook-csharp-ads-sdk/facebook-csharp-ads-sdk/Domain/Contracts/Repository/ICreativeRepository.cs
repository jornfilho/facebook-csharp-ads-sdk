using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository.Base;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    /// Interface of Creative repository
    /// </summary>
    public interface ICreativeRepository : IBaseCrudRepository<AdCreative>
    {
        /// <summary>
        ///     <para>Get the ad Creative by de id and the fields</para>
        /// </summary>
        /// <param name="creativeId"> Id of the creative</param>
        /// <param name="fields">Field list you wish to retrieve</param>
        /// <returns>Ad creative has passed fields</returns>
        Task<AdCreative> Read(long creativeId, IList<AdCreativeReadFieldsEnum> fields);
    }
}
