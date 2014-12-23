using System;
using System.ComponentModel;
using System.Reflection;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
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
        public bool IsValid { get; private set; }

        #endregion

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
        public virtual void ParseReadSingleResponse(string facebookResponse)
        {
            try
            {
                if (String.IsNullOrEmpty(facebookResponse))
                {
                    this.SetInvalid();
                }

                var response = JObject.Parse(facebookResponse);
                this.ParseReadSingleResponse(response);
            }
            catch (Exception)
            {
                this.SetInvalid();
            }
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public virtual void ParseReadSingleResponse(JToken facebookResponse)
        {
            try
            {
                SetDefaultValues();

                if (facebookResponse == null)
                    return;

                #region Api error

                if (facebookResponse["error"] != null)
                {
                    var errorModel = new ApiErrorModelV22().ParseApiResponse(facebookResponse);
                    this.SetApiErrorResonse(errorModel);
                    return;
                }

                #endregion

                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
                {
                    var facebookAttributeName = (FacebookNameAttribute)prop.Attributes[typeof(FacebookNameAttribute)];
                    var facebookAttributeType = (FacebookFieldTypeAttribute)prop.Attributes[typeof(FacebookFieldTypeAttribute)];
                    var defaultValueAttribute = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                    if (facebookAttributeName == null || facebookAttributeType == null)
                        continue;

                    PropertyInfo property = this.GetType().GetProperty(prop.Name);
                    if (property == null)
                        continue;

                    var defaultValue = defaultValueAttribute != null
                        ? defaultValueAttribute.Value
                        : null;

                    string facebookName = facebookAttributeName.Value;
                    FacebookFieldType facebookType = facebookAttributeType.Value;

                    property.SetValue(this, facebookResponse.GetValue(facebookName, facebookType, defaultValue), null);
                }

                this.SetValid();
            }
            catch (Exception)
            {
                this.SetInvalid();
            }
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

        /// <summary>
        ///     Get the facebook name of the property
        /// </summary>
        /// <param name="propertyName"> Property name </param>
        /// <returns> Facebook name </returns>
        protected string GetPropertyFacebookName(string propertyName)
        {
            var facebookAttributeName = this.GetType().GetProperty(propertyName).GetCustomAttribute<FacebookNameAttribute>();
            if (facebookAttributeName == null)
            {
                return string.Empty;
            }

            return facebookAttributeName.Value;
        }
    }
}
