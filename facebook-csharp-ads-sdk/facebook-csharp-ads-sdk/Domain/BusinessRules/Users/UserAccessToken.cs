using System;

namespace facebook_csharp_ads_sdk.Domain.BusinessRules.Users
{
    /// <summary>
    /// Class with business rules of Facebook token
    /// </summary>
    public static class UserAccessToken
    {
        /// <summary>
        /// Check if facebook token value has a valid value
        /// </summary>
        public static bool IsValidUserAccessToken(this string facebookToken)
        {
            return !String.IsNullOrEmpty(facebookToken);
        }
    }
}
