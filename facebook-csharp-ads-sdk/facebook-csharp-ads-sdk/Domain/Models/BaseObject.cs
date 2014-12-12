using System.ComponentModel;
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
        public ApiErrorModelV22 ApiErrorResponseData { get; private set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool IsValid { get; set; }

        #endregion

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
            IsValid = true;
        }

        /// <summary>
        /// Set data invalid
        /// </summary>
        public void SetInvalid()
        {
            IsValid = false;
        }

        /// <summary>
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            this.SetInvalid();
            ApiErrorResponseData = errorResponse;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public void ParseSingleResponse(JToken jsonResult)
        {
            SetDefaultValues();

            if (jsonResult == null)
                return;

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
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

            SetValid();
        }

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
