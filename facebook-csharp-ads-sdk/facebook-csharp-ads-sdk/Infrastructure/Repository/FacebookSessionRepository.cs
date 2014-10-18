using System;
using facebook_csharp_ads_sdk.Domain.BusinessRules.App;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    /// <summary>
    /// Repository for Facebook sessions data
    /// </summary>
    public class FacebookSessionRepository : IFacebookSession
    {
        private long AppId { get; set; }
        private string AppSecret { get; set; }
        private string AccessToken { get; set; }

        /// <summary>
        /// Set application data values
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetDefaultApplication(long appId, string appSecret)
        {
            if (!appId.IsValidAppId())
                throw new ArgumentOutOfRangeException();

            if(!appSecret.IsValidAppSecret())
                throw new ArgumentException();

            AppId = appId;
            AppSecret = appSecret;
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
        /// Set access token value
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void SetAccessToken(string accessToken)
        {
            if(!accessToken.IsValidAccessToken())
                throw new ArgumentException();

            AccessToken = accessToken;
        }

        /// <summary>
        /// Get access token
        /// </summary>
        public string GetAccessToken()
        {
            return AccessToken;
        }
    }
}
