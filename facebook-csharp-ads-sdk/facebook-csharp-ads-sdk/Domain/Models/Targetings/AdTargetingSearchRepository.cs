using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    public class AdTargetingSearchRepository : IAdTargetingSearchRepository
    {
        public IList<TargetingUserDevice> ReadUserDeviceList()
        {
            throw new NotImplementedException();
        }
    }
}
