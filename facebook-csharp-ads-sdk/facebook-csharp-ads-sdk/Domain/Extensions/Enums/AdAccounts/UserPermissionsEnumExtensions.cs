using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for UserPermissionsEnum enum
    /// </summary>
    public static class UserPermissionsEnumExtensions
    {
        /// <summary>
        /// Get user permission enum from permission name
        /// </summary>
        public static UserPermissionsEnum GetUserPermissionEnum(this string permissionString)
        {
            if (String.IsNullOrEmpty(permissionString))
                return UserPermissionsEnum.Undefined;

            foreach (UserPermissionsEnum permission in Enum.GetValues(typeof(UserPermissionsEnum)))
                if (permission.ToString().Equals(permissionString, StringComparison.InvariantCultureIgnoreCase))
                    return permission;

            return UserPermissionsEnum.Undefined;
        }

        /// <summary>
        /// Get user permission enum from permission code
        /// </summary>
        public static UserPermissionsEnum GetUserPermissionEnum(this int permissionCode)
        {
            foreach (UserPermissionsEnum permission in Enum.GetValues(typeof(UserPermissionsEnum)))
                if ((int)permission == permissionCode)
                    return permission;

            return UserPermissionsEnum.Undefined;
        }
    }
}
