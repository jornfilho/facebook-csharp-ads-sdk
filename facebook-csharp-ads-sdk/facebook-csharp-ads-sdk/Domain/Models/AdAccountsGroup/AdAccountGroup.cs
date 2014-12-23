using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup
{
    /// <summary>
    /// Class to ad account group
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/adaccountgroup/ </para>
    /// </summary>
    public class AdAccountGroup : BaseObject
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

        ///// <summary>
        ///// TODO: criar parser quando finalizar o parse de contas
        ///// Users and roles in an account group
        ///// </summary>
        //[DefaultValue(null)]
        //[FacebookName("users")]
        //[FacebookFieldType(FacebookFieldType.UsersList)]
        //public IList<User> Users { get; private set; }

        ///// <summary>
        ///// TODO: criar parser quando finalizar o parse de contas
        ///// The accounts in an account group in which the users have access
        ///// </summary>
        //[DefaultValue(null)]
        //[FacebookName("accounts")]
        //[FacebookFieldType(FacebookFieldType.AdAccountsList)]
        //public IList<AdAccount> AccountIds { get; private set; }
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
        public AdAccountGroup ParseSingleesponse(string response)
        {
            SetDefaultValues();

            if (String.IsNullOrEmpty(response))
                return this;

            var jsonObject = JObject.Parse(response);
            if (jsonObject == null)
                return this;

            #region Error
            if (jsonObject["error"] != null)
            {
                var errorModel = new ApiErrorModelV22().ParseApiResponse(jsonObject);
                this.SetInvalid();
                this.SetApiErrorResonse(errorModel);

                return this;
            } 
            #endregion

            this.ParseReadSingleesponse(jsonObject);
            return this;
        }

        /// <summary>
        /// Método para parse multiplo dos dados de uma lista de grupo de contas
        /// </summary>
        public BaseObjectsList<AdAccountGroup> ParseMultipleResponse(string response)
        {
            var objectResult = new BaseObjectsList<AdAccountGroup>();

            if (String.IsNullOrEmpty(response))
                return objectResult;

            var jsonObject = JObject.Parse(response);
            if (jsonObject == null)
                return objectResult;

            #region Error
            if (jsonObject["error"] != null)
            {
                var errorModel = new ApiErrorModelV22().ParseApiResponse(jsonObject);
                objectResult.SetInvalid();
                objectResult.SetApiErrorResonse(errorModel);

                return objectResult;
            }
            #endregion

            if (jsonObject["data"] == null)
                return objectResult;

            foreach (var item in jsonObject["data"])
            {
                if (item.Type != JTokenType.Object)
                    continue;

                var accountGroup = new AdAccountGroup();
                accountGroup.ParseReadSingleesponse(item.ToString());
                if (!accountGroup.IsValid)
                    continue;

                objectResult.Add(accountGroup);
            }
                
            objectResult.SetValid();
            
            return objectResult;
        }
        #endregion

        #region Método para GET dos dados no Facebook
        /// <summary>
        /// Método para leitura dos dados de um único grupo de contas
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">accountGroupId menor ou igual a zero</exception>
        /// <exception cref="ArgumentNullException">repository nulo</exception>
        public AdAccountGroup ReadSingle(long accountGroupId, IList<AdAccountGroupFieldsEnum> fields, IAccountGroupRepository repository)
        {
            SetDefaultValues();

            if (accountGroupId <= 0)
                throw new ArgumentOutOfRangeException("accountGroupId");

            if (fields == null || !fields.Any())
                fields = AdAccountGroupFieldsEnumExtensions.GetAllAdAccountGroupFieldsList();

            if (repository == null)
                throw new ArgumentNullException("repository");

            var getResult = repository.ReadSingle(accountGroupId, fields);
            CopyModelData(getResult);
            
            return this;
        }

        /// <summary>
        /// Método para leitura dos dados de um único grupo de contas
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">accountGroupId menor ou igual a zero</exception>
        /// <exception cref="ArgumentNullException">repository nulo</exception>
        public AdAccountGroup ReadSingle(long accountGroupId, IAccountGroupRepository repository)
        {
            ReadSingle(accountGroupId, AdAccountGroupFieldsEnumExtensions.GetDefaultsAdAccountGroupFieldsList(), repository);
            return this;
        } 
        #endregion

        /// <summary>
        /// Método para atribuição espelho de uma instancia da classe para a classe atual
        /// </summary>
        private void CopyModelData(AdAccountGroup data)
        {
            SetDefaultValues();

            if (data.IsValid)
                this.SetValid();

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                var dataValue = data.GetType().GetProperty(prop.Name).GetValue(data, null);

                PropertyInfo property = this.GetType().GetProperty(prop.Name);
                if (property != null)
                    property.SetValue(this, dataValue, null);
            }
        }
    }
}