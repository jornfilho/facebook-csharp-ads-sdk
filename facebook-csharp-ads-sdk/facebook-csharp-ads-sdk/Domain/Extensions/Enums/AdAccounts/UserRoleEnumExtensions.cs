using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    /// <summary>
    /// Extensions for UserRoleEnum enum
    /// </summary>
    public static class UserRoleEnumExtensions
    {
        /// <summary>
        /// Get user role enum from role code
        /// </summary>
        public static UserRoleEnum GetUserRoleEnum(this int roleCode)
        {
            foreach (UserRoleEnum role in Enum.GetValues(typeof(UserRoleEnum)))
                if ((int)role == roleCode)
                    return role;

            return UserRoleEnum.Undefined;
        }
    }
}
