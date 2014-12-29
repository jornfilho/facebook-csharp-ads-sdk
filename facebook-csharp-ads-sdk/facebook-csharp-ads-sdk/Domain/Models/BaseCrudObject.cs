using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk._Utils.Parser;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object for CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseCrudObject<T> : BaseObject
    {
        /// <summary>
        ///     Indicates whether the model is ready to be created on facebook
        /// </summary>
        public bool CreateModelIsReady { get; private set; }

        /// <summary>
        ///     Indicates whether the model is ready to be updated on facebook
        /// </summary>
        public bool UpdateModelIsReady { get; private set; }

        /// <summary>
        ///     Create a entity on Facebook
        /// </summary>
        /// <returns> Entity created </returns>
        public abstract T Create();

        /// <summary>
        ///     Mount a dictionary with parameters and values to create
        /// </summary>
        /// <returns> Dictionary with facebook name and value </returns>
        public abstract Dictionary<string, string> GetSingleCreateParams();

        /// <summary>
        ///     Read a T in Facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Entity with the passed id  </returns>
        public abstract T ReadSingle(long id);

        /// <summary>
        ///     Update a entity on Facebook
        /// </summary>
        /// <returns> Entity updated </returns>
        public abstract T Update(long id);

        /// <summary>
        ///     Mount a dictionary with parameters and values to update
        /// </summary>
        /// <returns> Dictionary with facebook name and value </returns>
        public abstract Dictionary<string, string> GetSingleUpdateParams();

        /// <summary>
        ///     Delete the object in facebook
        /// </summary>
        /// <returns> Success </returns>
        public abstract bool Delete();

        /// <summary>
        ///     Delete the object in facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Success </returns>
        public abstract bool Delete(long id);

        /// <summary>
        /// Parse create response from Facebook Api
        /// </summary>
        public void ParseCreateResponse(string facebookResponse)
        {
            try
            {
                if (String.IsNullOrEmpty(facebookResponse))
                {
                    this.SetInvalid();
                }

                var response = JObject.Parse(facebookResponse);
                bool success = this.AutoSetResponsePropertiesValue(response, true);
                if (!success)
                {
                    return;
                }

                this.SetInvalidCreateModel();
                this.SetValid();
            }
            catch (Exception)
            {
                this.SetInvalid();
            }
        }

        /// <summary>
        /// Parse update response from Facebook Api
        /// </summary>
        public bool ParseUpdateResponse(string facebookResponse)
        {
            try
            {
                if (String.IsNullOrEmpty(facebookResponse))
                {
                    this.SetInvalid();
                }

                var jsonResult = JObject.Parse(facebookResponse);
                if (!IsValidResponse(jsonResult))
                    return false;

                this.SetValid();
                return jsonResult["success"] != null &&
                       (jsonResult["success"].Type == JTokenType.Boolean ||
                        jsonResult["success"].Type == JTokenType.String ||
                        jsonResult["success"].Type == JTokenType.Integer) &&
                       jsonResult["success"].ToString().TryParseBool();
            }
            catch (Exception)
            {
                this.SetInvalid();
                return false;
            }
        }

        /// <summary>
        /// Parse delete response from Facebook Api
        /// </summary>
        public bool ParseDeleteResponse(string facebookResponse)
        {
            try
            {
                if (String.IsNullOrEmpty(facebookResponse))
                {
                    this.SetInvalid();
                }

                var jsonResult = JObject.Parse(facebookResponse);
                if (IsValidResponse(jsonResult))
                    return false;

                return jsonResult["success"] != null &&
                       (jsonResult["success"].Type == JTokenType.Boolean || jsonResult["success"].Type == JTokenType.String ||
                        jsonResult["success"].Type == JTokenType.Integer) &&
                       jsonResult["success"].ToString().TryParseBool();
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Protected methods

        /// <summary>
        ///     Invalidate model for creation on Facebook
        /// </summary>
        protected void SetInvalidCreateModel()
        {
            this.CreateModelIsReady = false;
        }

        /// <summary>
        ///     Validate model for creation on Facebook
        /// </summary>
        protected void SetValidCreateModel()
        {
            this.CreateModelIsReady = true;
        }

        /// <summary>
        ///     Invalidate model for update on Facebook
        /// </summary>
        protected void SetInvalidUpdateModel()
        {
            this.UpdateModelIsReady = false;
        }

        /// <summary>
        ///     Validate model for update on Facebook
        /// </summary>
        protected void SetValidUpdateModel()
        {
            this.UpdateModelIsReady = true;
        }

        /// <summary>
        ///     Verify if property can be used in operation
        /// </summary>
        /// <param name="property"> Property </param>
        /// <param name="operationType"> Operations type </param>
        /// <returns> Flag indicating it can be used </returns>
        protected bool PropertyCanBeUsedInTheOperation(PropertyDescriptor property, GetParamsType operationType)
        {
            if (operationType == GetParamsType.Create)
            {
                var canCreateOnFacebookAttribute = (CanCreateOnFacebookAttribute)property.Attributes[typeof(CanCreateOnFacebookAttribute)];
                if (canCreateOnFacebookAttribute == null || canCreateOnFacebookAttribute.Value == false)
                {
                    return false;
                }

                return true;
            }

            var canUpdateOnFacebookAttribute = (CanUpdateOnFacebookAttribute)property.Attributes[typeof(CanUpdateOnFacebookAttribute)];
            if (canUpdateOnFacebookAttribute == null || canUpdateOnFacebookAttribute.Value == false)
            {
                return false;
            }

            return true;
        }

        #endregion Protected methods

        #region Private methods

        /// <summary>
        /// Realiza validação base de resposta do facebook
        /// </summary>
        private bool IsValidResponse(JToken jsonResult)
        {
            if (jsonResult == null || jsonResult.Type != JTokenType.Object)
                return false;

            return !HasResponseError(jsonResult);
        }

        /// <summary>
        /// Verifica se tem erro na resposta do facebook
        /// Caso haja, faz parse do erro
        /// </summary>
        private bool HasResponseError(JToken jsonResult)
        {
            if (jsonResult == null)
                return false;

            if (jsonResult["error"] == null)
                return false;

            SetDefaultValues();
            SetApiErrorResonse(new ApiErrorModelV22().ParseApiResponse(jsonResult));
            return true;
        }

        /// <summary>
        /// Método para atribuição automática dos dados recebidos pelo facebook
        /// </summary>
        private bool AutoSetResponsePropertiesValue(JToken jsonResult, bool isCreateMethod)
        {
            if (!IsValidResponse(jsonResult))
                return false;

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                if (isCreateMethod)
                {
                    var isFacebookCreationReturnPropertie = (IsFacebookCreateResponseAttribute)prop.Attributes[typeof(IsFacebookCreateResponseAttribute)];
                    if (isFacebookCreationReturnPropertie == null)
                        continue;

                    if (!isFacebookCreationReturnPropertie.Value)
                        continue;
                }

                var facebookAttributeName = (FacebookNameAttribute)prop.Attributes[typeof(FacebookNameAttribute)];
                var facebookAttributeType = (FacebookFieldTypeAttribute)prop.Attributes[typeof(FacebookFieldTypeAttribute)];
                var defaultValueAttribute = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (facebookAttributeName == null || facebookAttributeType == null)
                    continue;

                PropertyInfo property = this.GetType().GetProperty(prop.Name);
                if (property == null)
                {
                    continue;
                }

                object defaultValue = defaultValueAttribute != null
                    ? defaultValueAttribute.Value
                    : null;

                string facebookName = facebookAttributeName.Value;
                FacebookFieldType facebookType = facebookAttributeType.Value;

                property.SetValue(this, jsonResult.GetValue(facebookName, facebookType, defaultValue), null);
            }

            return true;
        }

        #endregion Private methods
    }
}
