using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// <para>Class to ad account users</para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/aduser </para>
    /// </summary>
    public class User
    {
        #region Params
        /// <summary>
        /// User id
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// List of user permission
        /// </summary>
        public IList<UserPermissionsEnum> Permissions { get; private set; }

        /// <summary>
        /// User permission role
        /// </summary>
        public UserRoleEnum Role { get; private set; }
        #endregion
    }
}
