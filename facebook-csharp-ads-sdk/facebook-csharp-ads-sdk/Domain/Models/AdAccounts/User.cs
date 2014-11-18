using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// <para>Class to ad account users</para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/aduser </para>
    /// </summary>
    public class User : BaseObject<User>
    {
        #region Properties
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

        /// <summary>
        /// Set user data
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">invalid id</exception>
        /// <exception cref="ArgumentNullException">permissions is null</exception>
        /// <exception cref="InvalidEnumArgumentException">permissions or role has an invalid option value</exception>
        public User SetUserData(long id, IList<UserPermissionsEnum> permissions, UserRoleEnum role)
        {
            var isValid = false;

            if (id <= 0)
                return this;

            Id = id;

            if (permissions != null && permissions.Any())
            {
                var permissionCount = permissions.Count();
                for (var permissionIndex = 0; permissionIndex < permissionCount; permissionIndex++)
                {
                    var currentPermission = permissions[permissionIndex];
                    if(currentPermission == UserPermissionsEnum.Undefined)
                        continue;

                    if(Permissions == null)
                        Permissions = new List<UserPermissionsEnum>();

                    Permissions.Add(currentPermission);
                }

                if (Permissions != null && Permissions.Any())
                    isValid = true;
            }

            if (role != UserRoleEnum.Undefined)
            {
                Role = role;
                isValid = true;
            }
            
            if(isValid)
                SetValid();
            
            return this;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public User ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            long id = 0;
            IList<UserPermissionsEnum> permissions = null;
            var role = UserRoleEnum.Undefined;

            if (jsonResult["uid"] != null && jsonResult["uid"].Type == JTokenType.Integer)
                id = jsonResult["uid"].ToString().TryParseLong();

            if (jsonResult["permissions"] != null && 
                jsonResult["permissions"].Type == JTokenType.Array &&
                jsonResult["permissions"].Any())
            {
                var permissionCount = jsonResult["permissions"].Count();
                for (var permissionIndex = 0; permissionIndex < permissionCount; permissionIndex++)
                {
                    if(jsonResult["permissions"][permissionIndex] == null)
                        continue;

                    var currentPermission = jsonResult["permissions"][permissionIndex]
                        .ToString()
                        .TryParseInt()
                        .GetUserPermissionEnum();

                    if (currentPermission == UserPermissionsEnum.Undefined) 
                        continue;

                    if (permissions == null)
                        permissions = new List<UserPermissionsEnum>();

                    permissions.Add(currentPermission);
                }
            }

            if (jsonResult["role"] != null && jsonResult["role"].Type == JTokenType.Integer)
                role = jsonResult["role"].ToString().TryParseInt().GetUserRoleEnum();

            SetUserData(id, permissions, role);

            return this;
        }

        public override User Read(long id)
        {
            throw new NotImplementedException();
        }

        public override User ParseFacebookResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}
