using System;
using System.Collections.Generic;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using facebook_csharp_ads_sdk.Domain.BusinessRules.Users;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.App;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.Configurations;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    /// <summary>
    /// Repository for Facebook sessions data
    /// </summary>
    public class FacebookSessionRepository : IFacebookSession
    {
        #region Properties
        private long AppId { get; set; }
        private string AppSecret { get; set; }
        private string AppAccessToken { get; set; }
        private string UserAccessToken { get; set; }
        private FacebookAdsApiConfiguration FacebookAdsApiConfiguration { get; set; } 
        #endregion

        #region App data
        /// <summary>
        /// Set application data values
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public IFacebookSession SetDefaultApplication(long appId, string appSecret)
        {
            if (!appId.IsValidAppId())
                throw new ArgumentOutOfRangeException();

            if (!appSecret.IsValidAppSecret())
                throw new ArgumentException();

            AppId = appId;
            AppSecret = appSecret;

            return this;
        }

        /// <summary>
        /// Get app id
        /// </summary>
        public long GetAppId()
        {
            return AppId;
        }

        /// <summary>
        /// Get app secret
        /// </summary>
        public string GetAppSecret()
        {
            return AppSecret;
        }

        /// <summary>
        /// Set app token value
        /// </summary>
        /// <exception cref="InvalidAppAccessToken"></exception>
        public IFacebookSession SetAppAccessToken(string appAccessToken)
        {
            if (!appAccessToken.IsValidAppAccessToken())
                throw new InvalidAppAccessToken();

            AppAccessToken = appAccessToken;

            return this;
        }

        /// <summary>
        /// Get app access token
        /// </summary>
        public string GetAppAccessToken()
        {
            return AppAccessToken;
        }
        #endregion

        #region User data
        /// <summary>
        /// Set user access token value
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"></exception>
        public IFacebookSession SetUserAccessToken(string userAccessToken)
        {
            if (!userAccessToken.IsValidUserAccessToken())
                throw new InvalidUserAccessToken();

            UserAccessToken = userAccessToken;

            return this;
        }

        /// <summary>
        /// Get user access token
        /// </summary>
        public string GetUserAccessToken()
        {
            return UserAccessToken;
        }
        #endregion

        #region Global
        /// <summary>
        /// Validate Facebook Session according received requirements
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidAppAccessToken"></exception>
        /// <exception cref="InvalidAppSecret"></exception>
        /// <exception cref="InvalidAppId"></exception>
        /// <exception cref="InvalidUserAccessToken"></exception>
        public IFacebookSession ValidateFacebookSessionRequirements(ICollection<RequiredOnFacebookSessionEnum> requirements)
        {
            if (!requirements.Any())
                return this;

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AppAccessToken) &&
                !AppAccessToken.IsValidAppAccessToken())
                throw new InvalidAppAccessToken();

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AppSecret) &&
                !AppSecret.IsValidAppSecret())
                throw new InvalidAppSecret();

            if (requirements.Contains(RequiredOnFacebookSessionEnum.AppId) &&
                !AppId.IsValidAppId())
                throw new InvalidAppId();

            if (requirements.Contains(RequiredOnFacebookSessionEnum.UserAccessToken) &&
                !UserAccessToken.IsValidUserAccessToken())
                throw new InvalidUserAccessToken();

            return this;
        } 
        #endregion

        /// <summary>
        /// Return an instance of Facebook Ads Api configuration class
        /// </summary>
        public FacebookAdsApiConfiguration GetFacebookAdsApiConfiguration()
        {
            return FacebookAdsApiConfiguration ?? (FacebookAdsApiConfiguration = new FacebookAdsApiConfiguration());
        }
    }
}
