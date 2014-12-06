using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Interface of the campaign repository
    /// </summary>
    public interface ICampaignRepository
    {
        /// <summary>
        ///     <para> Get the ad campaign by id </para>
        /// </summary>
        /// <param name="campaignId"> Id of the campaign </param>
        /// <returns> Task async with ad campaign </returns>
        Task<AdCampaign> Read(long campaignId);
    }
}