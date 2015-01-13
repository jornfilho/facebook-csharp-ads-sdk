using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdStatistics
{
    /// <summary>
    /// Statistics for Facebook ad account, group, campaign or set
    /// </summary>
    public class AdStatistics : BaseObject
    {
        #region properties
        /// <summary>
        /// Statistics object id
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("id")]
        public long Id { get; private set; }

        /// <summary>
        /// Number of ads served
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("impressions")]
        public long Impressions { get; private set; }

        /// <summary>
        /// Number of clicks received
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("clicks")]
        public long Clciks { get; private set; }

        /// <summary>
        /// Amount spent in the ad account currency. Need to apply currency offset
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("spent")]
        public long Spent { get; private set; }

        /// <summary>
        /// Ads that were served with social context
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("social_impressions")]
        public long SocialImpressions { get; private set; }

        /// <summary>
        /// Clicks on ads that were shown with social context
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("social_clicks")]
        public long SocialClicks { get; private set; }

        /// <summary>
        /// The amount spent on ads with social context
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("social_spent")]
        public long SocialSpent { get; private set; }

        /// <summary>
        /// The number of individuals this ad was served to on the site
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("unique_impressions")]
        public long UniqueImpressions { get; private set; }

        /// <summary>
        /// The number of individuals this ad was served to with social context
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("social_unique_impressions")]
        public long SocialUniqueImpressions { get; private set; }

        /// <summary>
        /// The number of individuals who clicked this ad.
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("unique_clicks")]
        public long UniqueClicks { get; private set; }

        /// <summary>
        /// The number of individuals who clicked this ad while it had social context
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("unique_clicks")]
        public long SocialUniqueClicks { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("actions")]
        public JObject Actions { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("inline_actions")]
        public JObject InlineActions { get; private set; }

        /// <summary>
        /// The ID of the object the statistics refer to, this may also be adcampaign_id or adgroup_id
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("account_id")]
        public long AccountId { get; private set; }

        /// <summary>
        /// A timestamp of the start of the statistics period
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("start_time")]
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// A timestamp of the end of the statistics period
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("end_time")]
        public DateTime EndTime { get; private set; }
        #endregion

        #region Métodos para parse das respostas do Facebook

        /// <summary>
        /// Método para parse multiplo dos dados de uma lista de grupo de contas
        /// </summary>
        public static BaseObjectsList<AdStatistics> ParseMultipleResponse(string response)
        {
            return new BaseObjectsList<AdStatistics>().ParseReadMultipleResponse(response);
        }
        #endregion
    }
}
