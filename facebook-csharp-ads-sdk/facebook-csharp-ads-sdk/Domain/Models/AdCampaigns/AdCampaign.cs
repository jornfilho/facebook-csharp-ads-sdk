using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
    public class AdCampaign : BaseCrudObject<AdCampaign>
    {
        public long Id { get; private set; }

        public long AccountId { get; private set; }

        public string Name { get; private set; }

        public AdCampaignObjective Objective { get; private set; }

        // TODO: criar enum
        public string Status { get; private set; }

        // TODO: criar enum
        public string BuyingType { get; private set; }

        public override AdCampaign ReadSingle(long id)
        {
            throw new NotImplementedException();
        }

        public override AdCampaign ParseSingleResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}
