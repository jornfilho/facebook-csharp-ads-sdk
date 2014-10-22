using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// <para>Class to ad account users</para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/aduser </para>
    /// </summary>
    public class User
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

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool ValidData { get; set; }
        #endregion

        /// <summary>
        /// Set user data
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">invalid id</exception>
        /// <exception cref="ArgumentNullException">permissions is null</exception>
        /// <exception cref="InvalidEnumArgumentException">permissions or role has an invalid option value</exception>
        public User SetUserData(long id, IList<UserPermissionsEnum> permissions, UserRoleEnum role)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            if (permissions == null)
                throw new ArgumentNullException();

            if (permissions.Any(p=> p == UserPermissionsEnum.Undefined))
                throw new InvalidEnumArgumentException();

            if(role == UserRoleEnum.Undefined)
                throw new InvalidEnumArgumentException();

            Id = id;
            Permissions = permissions;
            Role = role;
            
            ValidData = true;
            
            return this;
        }

        /// <summary>
        /// Return true if has valid data 
        /// </summary>
        public bool IsValid()
        {
            return ValidData;
        }
    }
}
