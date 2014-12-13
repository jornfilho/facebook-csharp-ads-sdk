using System.ComponentModel;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk._Utils.Parser;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object to models 
    /// </summary>
    public abstract class BaseObject
    {
        #region Properties
        /// <summary>
        /// Api error response model
        /// </summary>
        private ApiErrorModelV22 ApiErrorResponseData { get; set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool IsValid { get; set; }
        #endregion

        #region Métodos de controle de validação do modelo
        /// <summary>
        /// Return true if has valid data 
        /// </summary>
        public bool IsValidData()
        {
            return IsValid;
        }

        /// <summary>
        /// Set data valid
        /// </summary>
        public void SetValid()
        {
            if (IsValid)
                return;

            IsValid = true;
        }

        /// <summary>
        /// Set data invalid
        /// </summary>
        public void SetInvalid()
        {
            if (!IsValid)
                return;

            IsValid = false;
        }
        #endregion

        #region Métodos para manipulação do objeto de erros do facebook
        /// <summary>
        /// Get api error response data model
        /// </summary>
        public ApiErrorModelV22 GetApiErrorResonse()
        {
            return ApiErrorResponseData;
        }

        /// <summary>
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            ApiErrorResponseData = errorResponse;
            SetInvalid();
        }
        #endregion

        #region Parsers de respostas do facebook
        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public void ParseSingleResponse(JToken jsonResult)
        {
            SetDefaultValues();

            if (!AutoSetResponsePropertiesValue(jsonResult, false))
                return;

            SetValid();
        }

        /// <summary>
        /// Parse create response from Facebook Api
        /// </summary>
        public void ParseCreateResponse(JToken jsonResult)
        {
            AutoSetResponsePropertiesValue(jsonResult, true);
        }

        /// <summary>
        /// Parse update response from Facebook Api
        /// </summary>
        public bool ParseUpdateResponse(JToken jsonResult)
        {
            if (IsValidResponse(jsonResult))
                return false;

            return jsonResult["success"] != null &&
                   (jsonResult["success"].Type == JTokenType.Boolean || jsonResult["success"].Type == JTokenType.String ||
                    jsonResult["success"].Type == JTokenType.Integer) &&
                   jsonResult["success"].ToString().TryParseBool();
        }

        /// <summary>
        /// Parse delete response from Facebook Api
        /// </summary>
        public bool ParseDeleteResponse(JToken jsonResult)
        {
            if (IsValidResponse(jsonResult))
                return false;

            return jsonResult["success"] != null &&
                   (jsonResult["success"].Type == JTokenType.Boolean || jsonResult["success"].Type == JTokenType.String ||
                    jsonResult["success"].Type == JTokenType.Integer) &&
                   jsonResult["success"].ToString().TryParseBool();
        }

        /// <summary>
        /// Método para atribuição automática dos dados recebidos pelo facebook
        /// </summary>
        private bool AutoSetResponsePropertiesValue(JToken jsonResult, bool isCreateMethod)
        {
            if (IsValidResponse(jsonResult))
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

                var property = this.GetType().GetProperty(prop.Name);
                if (property == null)
                    continue;

                var defaultValue = defaultValueAttribute != null
                    ? defaultValueAttribute.Value
                    : null;

                var facebookName = facebookAttributeName.Value;
                var facebookType = facebookAttributeType.Value;

                property.SetValue(this, jsonResult.GetValue(facebookName, facebookType, defaultValue), null);
            }

            return true;
        }

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
            SetApiErrorResonse(new ApiErrorModelV22().ParseApiResponse(jsonResult["error"]));
            return true;
        }
        #endregion

        /// <summary>
        /// Set default properties value
        /// </summary>
        protected void SetDefaultValues()
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                var attr = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (attr == null)
                    continue;

                var attrValue = attr.Value;
                var property = this.GetType().GetProperty(prop.Name);
                if (property != null)
                    property.SetValue(this, attrValue, null);
            }

            SetInvalid();
        }
    }
}
