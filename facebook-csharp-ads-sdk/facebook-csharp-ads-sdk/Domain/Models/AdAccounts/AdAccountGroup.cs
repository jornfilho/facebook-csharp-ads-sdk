using System;
using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to ad account group
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/adaccountgroup/ </para>
    /// </summary>
    public class AdAccountGroup : BaseCrudObject<AdAccountGroup>
    {
        #region Properties
        /// <summary>
        /// The account group ID, required for updating an account group
        /// </summary>
        [DefaultValue(0L)]
        [FacebookName("account_group_id")]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long AccountGroupId { get; private set; }

        /// <summary>
        /// Name for the account group, and required when creating an account group; need not be unique; can be changed
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("name")]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Name { get; private set; }

        /// <summary>
        /// Determines whether the account has a status of active (1) or deleted (2)
        /// </summary>
        [DefaultValue(AdAccountGroupsStatusEnum.Undefined)]
        [FacebookName("status")]
        [FacebookFieldType(FacebookFieldType.AdAccountGroupsStatusEnum)]
        public AdAccountGroupsStatusEnum Status { get; private set; }
        #endregion

        #region Método de atribuição dos dados da classe
        /// <summary>
        /// Set ad account group data.
        /// All fields are required.
        /// </summary>
        public AdAccountGroup SetAdAccountGroupData(long accountGroupId, string name, AdAccountGroupsStatusEnum status)
        {
            SetDefaultValues();

            if (accountGroupId <= 0)
                return this;

            if (status == AdAccountGroupsStatusEnum.Undefined)
                return this;

            AccountGroupId = accountGroupId;
            Name = name;
            Status = status;

            SetValid();

            return this;
        } 
        #endregion

        #region Métodos para parse das respostas do Facebook
        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public override AdAccountGroup ParseSingleResponse(string response)
        {
            SetDefaultValues();

            if (String.IsNullOrEmpty(response))
                return this;

            var jsonObject = JObject.Parse(response);
            if (jsonObject == null)
                return this;

            ParseSingleResponse(jsonObject);
            return this;
        }
        #endregion


        public override AdAccountGroup ReadSingle(long id)
        {
            throw new NotImplementedException();
        }

        
    }
}