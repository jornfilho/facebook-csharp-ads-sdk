using System.ComponentModel;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Domain.Utils;
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
        ///     Read a T in Facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Entity with the passed id  </returns>
        public abstract T ReadSingle(long id);

        /// <summary>
        ///     Does parse the response from Facebook
        /// </summary>
        /// <param name="response"> Model Json response </param>
        /// <returns> Entity </returns>
        public abstract T ParseSingleResponse(string response);

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

        #region Método privado para atribuição dos dados default de todas as propriedades da classe
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
        #endregion
    }
}
