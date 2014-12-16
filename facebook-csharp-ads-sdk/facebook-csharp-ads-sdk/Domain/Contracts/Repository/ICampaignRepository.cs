using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Interface of the campaign repository
    /// </summary>
    public interface ICampaignRepository : IBaseCrudRepository<AdCampaign>
    {
        /// <summary>
        ///     <para> Get the ad campaign by field list </para>
        /// </summary>
        /// <param name="campaignId"> Id of the campaign </param>
        /// <param name="fields"> Field list you wish to retrieve </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad campaign has passed fields </returns>
        Task<AdCampaign> Read(long campaignId, IList<AdCampaignReadFieldsEnum> fields);
    }
}