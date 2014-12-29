using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository.Base;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts.Connections;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Ad activity logs repository interface
    /// </summary>
    public interface IAdActivityLogRepository : IBaseRepository<IList<AdActivityLog>>
    {
        Task<IList<AdActivityLog>> Read(long id, IList<AdActivityLogFieldsEnum> fields);
    }
}
