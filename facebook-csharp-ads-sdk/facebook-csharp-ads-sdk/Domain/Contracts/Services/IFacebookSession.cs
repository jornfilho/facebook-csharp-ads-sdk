using System;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Services
{
    /// <summary>
    /// Repository for Facebook sessions data
    /// </summary>
    public interface IFacebookSession
    {
        /// <summary>
        /// Set application data values
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        void SetDefaultApplication(long appId, string appSecret);

        /// <summary>
        /// Get app id
        /// </summary>
        long GetAppId();

        /// <summary>
        /// Get app secret
        /// </summary>
        string GetAppSecret();

        /// <summary>
        /// Set access token value
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        void SetAccessToken(string accessToken);

        /// <summary>
        /// Get access token
        /// </summary>
        string GetAccessToken();
    }
}
