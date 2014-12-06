using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models.AdCampaigns;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        #region Properties
        
        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
        private readonly IFacebookSession facebookSession;

        #endregion

        #region Constructor

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public CampaignRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
            {
                throw new ArgumentNullException();
            }

            this.facebookSession = facebookSession;
        } 

        #endregion

        public async Task<AdCampaign> Read(long campaignId)
        {
            //string campaignEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdAccountEndpoint;

            string campaignEndpoint = "https://graph.facebook.com/{0}?access_token={1}";
            string fields = "id";
            campaignEndpoint = string.Format(campaignEndpoint, campaignId, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            var getRequest = await webRequest.GetAsync(campaignEndpoint);
            var account = new AdCampaign(this).ParseSingleResponse(getRequest);
            return account;
        }
    }
}
