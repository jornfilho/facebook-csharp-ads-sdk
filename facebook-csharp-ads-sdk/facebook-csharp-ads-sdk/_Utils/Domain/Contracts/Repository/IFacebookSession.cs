using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.App;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.Configurations;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    /// Repository for Facebook sessions data
    /// </summary>
    public interface IFacebookSession
    {
        #region App data
        /// <summary>
        /// Set application data values
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        IFacebookSession SetDefaultApplication(long appId, string appSecret);

        /// <summary>
        /// Get app id
        /// </summary>
        long GetAppId();

        /// <summary>
        /// Get app secret
        /// </summary>
        string GetAppSecret();

        /// <summary>
        /// Set app token value
        /// </summary>
        /// <exception cref="InvalidAppAccessToken"></exception>
        IFacebookSession SetAppAccessToken(string appAccessToken);

        /// <summary>
        /// Get app access token
        /// </summary>
        string GetAppAccessToken(); 
        #endregion

        #region user data
        /// <summary>
        /// Set user access token value
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"></exception>
        IFacebookSession SetUserAccessToken(string userAccessToken);

        /// <summary>
        /// Get user access token
        /// </summary>
        string GetUserAccessToken(); 
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
        IFacebookSession ValidateFacebookSessionRequirements(ICollection<RequiredOnFacebookSessionEnum> requirements);
        #endregion

        /// <summary>
        /// Return an instance of Facebook Ads Api configuration class
        /// </summary>
        FacebookAdsApiConfiguration GetFacebookAdsApiConfiguration();
    }
}
