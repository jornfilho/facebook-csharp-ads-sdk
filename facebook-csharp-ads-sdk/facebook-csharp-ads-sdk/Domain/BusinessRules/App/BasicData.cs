using System;

namespace facebook_csharp_ads_sdk.Domain.BusinessRules.App
{
    /// <summary>
    /// Class with business rules of app basic data
    /// </summary>
    public static class BasicData
    {
        /// <summary>
        /// Test if app id has a vaid value
        /// </summary>
        public static bool IsValidAppId(this long appId)
        {
            return appId > 0;
        }

        /// <summary>
        /// Test if app id has a vaid value
        /// </summary>
        public static bool IsValidAppId(this long? appId)
        {
            return (appId ?? 0).IsValidAppId();
        }

        /// <summary>
        /// Test if app secret has a vaid value
        /// </summary>
        public static bool IsValidAppSecret(this string appSecret)
        {
            return !String.IsNullOrEmpty(appSecret);
        }

        /// <summary>
        /// Test if accessToken has a vaid value
        /// </summary>
        public static bool IsValidAccessToken(this string accessToken)
        {
            return !String.IsNullOrEmpty(accessToken);
        }
    }
}
