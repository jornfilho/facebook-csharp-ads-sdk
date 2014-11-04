using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Configurations;

namespace facebook_csharp_ads_sdk.Domain.Models.Configurations
{
    /// <summary>
    /// Facebook configurations model
    /// </summary>
    public class FacebookAdsApiConfiguration
    {
        #region Global properties
        /// <summary>
        /// Currend Facebook Ads Api version
        /// </summary>
        public FacebookAdsApiVersionsEnum Version { get; private set; }

        /// <summary>
        /// Base Facebook graph api url
        /// </summary>
        public string GraphApiUrl { get; private set; } 
        #endregion

        #region Ad account properties
        /// <summary>
        /// Available ad account fields
        /// </summary>
        public IList<AdAccountFieldsEnum> AdAccountFields { get; private set; }

        /// <summary>
        /// Uri to read single account data
        /// </summary>
        public string AdAccountEndpoint { get; private set; } 
        #endregion

        /// <summary>
        /// Base constructor
        /// </summary>
        public FacebookAdsApiConfiguration()
        {
            SetGlobalConfigurations();
            SetAdAccountConfigurations();
        }

        private void SetGlobalConfigurations()
        {
            Version = FacebookAdsApiVersionsEnum.V201;
            GraphApiUrl = string.Format("https://graph.facebook.com/{0}/", Version.GetFacebookName());
        }

        private void SetAdAccountConfigurations()
        {
            AdAccountFields = AdAccountFieldsExtensions.GetAdAccountFieldsList();
            AdAccountEndpoint = GraphApiUrl + "act_{0}/";
        }
    }
}
