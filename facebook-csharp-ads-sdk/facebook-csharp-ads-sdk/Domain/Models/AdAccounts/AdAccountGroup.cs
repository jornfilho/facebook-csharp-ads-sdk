using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts;
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
        public long AccountGroupId { get; private set; }

        /// <summary>
        /// Name for the account group, and required when creating an account group; need not be unique; can be changed
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Determines whether the account has a status of active (1) or deleted (2)
        /// </summary>
        public AdAccountGroupsStatusEnum Status { get; private set; }
        #endregion

        /// <summary>
        /// Set ad account group data.
        /// All fields are required.
        /// </summary>
        public AdAccountGroup SetAdAccountGroupData(long accountGroupId, string name, AdAccountGroupsStatusEnum status)
        {
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


        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public AdAccountGroup ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            long groupId = 0;
            string name = null;
            var status = AdAccountGroupsStatusEnum.Undefined;

            if (jsonResult["account_group_id"] != null && jsonResult["account_group_id"].Type == JTokenType.Integer)
                groupId = jsonResult["account_group_id"].ToString().TryParseLong();

            if (jsonResult["name"] != null && jsonResult["name"].Type == JTokenType.String)
                name = jsonResult["name"].ToString();

            if (jsonResult["status"] != null && jsonResult["status"].Type == JTokenType.Integer)
                status = jsonResult["status"].ToString().TryParseInt().GetAdAccountGroupsStatusEnum();

            SetAdAccountGroupData(groupId, name, status);

            return this;
        }

        public override AdAccountGroup ReadSingle(long id)
        {
            throw new System.NotImplementedException();
        }

        public override AdAccountGroup ParseSingleResponse(string response)
        {
            throw new System.NotImplementedException();
        }
    }
}