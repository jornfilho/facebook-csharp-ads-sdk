using System;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get Facebook field type
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class FacebookFieldTypeAttribute : Attribute, IAttribute<FacebookFieldType>
    {
        private readonly FacebookFieldType _value;

        /// <summary>
        /// Basic constructor with attribute value
        /// </summary>
        public FacebookFieldTypeAttribute(FacebookFieldType value)
        {
            _value = value;
        }

        /// <summary>
        /// Class base getter
        /// </summary>
        public FacebookFieldType Value
        {
            get { return _value; }
        }
    }
}
