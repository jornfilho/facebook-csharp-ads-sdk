using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to ad account group
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/adaccountgroup/ </para>
    /// </summary>
    public class AdAccountGroup
    {
        #region Properties
        /// <summary>
        /// The account group ID, required for updating an account group
        /// </summary>
        public long AccountGroupId { get; private set; }

        /// <summary>
        /// Name for the account group, and required when creating an account group; need not be unique; can be changed
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Determines whether the account has a status of active (1) or deleted (2)
        /// </summary>
        public AdAccountGroupsStatusEnum Status { get; private set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool ValidData { get; set; }
        #endregion

        /// <summary>
        /// Set ad account group data.
        /// All fields are required.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Invalid accountGroupId</exception>
        /// <exception cref="ArgumentException">Invalid name or status</exception>
        public AdAccountGroup SetAdAccountGroupData(long accountGroupId, string name, AdAccountGroupsStatusEnum status)
        {
            if (AccountGroupId <= 0)
                throw new ArgumentOutOfRangeException();

            if(String.IsNullOrEmpty(name))
                throw new ArgumentException();

            if(status == AdAccountGroupsStatusEnum.Undefined)
                throw new ArgumentException();

            AccountGroupId = accountGroupId;
            Name = name;
            Status = status;

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
