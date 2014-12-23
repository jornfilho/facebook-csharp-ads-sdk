using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository.Base;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    /// Interface of Creative repository
    /// </summary>
    public interface ICreativeRepository : IBaseCrudRepository<AdCreative>
    {
        Task<AdCreative> Read(long creativeId);
    }
}
