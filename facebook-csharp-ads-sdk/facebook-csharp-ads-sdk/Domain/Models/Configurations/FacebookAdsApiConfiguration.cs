﻿using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
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
        /// Available ad account group fields
        /// </summary>
        public IList<AdAccountGroupFieldsEnum> AdAccountGroupFields { get; private set; }

        /// <summary>
        /// Uri to read single account group data
        /// </summary>
        public string AdAccountGroupSingleEndpoint { get; private set; }

        /// <summary>
        /// Url para leitura de todos os grupos de conta de um token
        /// </summary>
        public string AdAccountGroupAllEndpoint { get; private set; }

        /// <summary>
        ///     Delete endpoint
        /// </summary>
        public string DeleteEndpoint
        {
            get { return String.Format("{0}{1}", this.GraphApiUrl, "{0}?access_token={1}"); }
        }

        #region Ad campaign
        
        /// <summary>

        ///     Endpoint of the read ad campaign
        /// </summary>
        public string AdCampaignReadEndpoint
        {
            get { return String.Format("{0}{1}", this.GraphApiUrl, "{0}?access_token={1}&fields={2}"); }
        }

        /// <summary>
        ///     Endpoint of the create ad campaign
        /// </summary>
        public string AdCampaignCreateEndpoint
        {
            get { return String.Format("{0}{1}", this.GraphApiUrl, "act_{0}/adcampaign_groups?access_token={1}"); }
        }
        
        /// <summary>
        ///     Endpoint of the update ad campaign
        /// </summary>
        public string AdCampaignUpdateEndpoint
        {
            get { return String.Format("{0}{1}", this.GraphApiUrl, "{0}?access_token={1}"); }
        }

        #endregion Ad campaign

        /// <summary>
        /// Base constructor
        /// </summary>
        public FacebookAdsApiConfiguration()
        {
            SetGlobalConfigurations();
            SetAdAccountConfigurations();
            SetAdAccountGroupConfigurations();
        }

        private void SetGlobalConfigurations()
        {
            Version = FacebookAdsApiVersionsEnum.V22;
            GraphApiUrl = string.Format("https://graph.facebook.com/{0}/", Version.GetFacebookName());
        }

        private void SetAdAccountConfigurations()
        {
            AdAccountFields = AdAccountFieldsExtensions.GetAllAdAccountFieldsList();
            AdAccountEndpoint = GraphApiUrl + "act_{0}?access_token={1}&fields={2}";
        }

        private void SetAdAccountGroupConfigurations()
        {
            AdAccountGroupFields = AdAccountGroupFieldsEnumExtensions.GetAllAdAccountGroupFieldsList();
            AdAccountGroupSingleEndpoint = GraphApiUrl + "{0}?access_token={1}&fields={2}";
            AdAccountGroupAllEndpoint = GraphApiUrl + "me/adaccountgroups?access_token={0}&fields={1}";
        }
    }
}
