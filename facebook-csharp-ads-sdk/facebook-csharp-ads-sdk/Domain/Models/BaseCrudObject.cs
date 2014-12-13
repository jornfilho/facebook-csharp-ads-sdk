using System.ComponentModel;
using DevUtils.PrimitivesExtensions;
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
        ///     Read a T in Facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Entity with the passed id  </returns>
        public abstract T ReadSingle(long id);

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
            SetApiErrorResonse(new ApiErrorModelV22().ParseApiResponse(jsonResult["error"]));
            return true;
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

        #endregion Private methods
    }
}
