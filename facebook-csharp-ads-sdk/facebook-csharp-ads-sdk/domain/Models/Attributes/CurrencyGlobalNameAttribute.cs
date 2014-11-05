using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get currency symbol
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class CurrencyGlobalNameAttribute : Attribute, IAttribute<string>
    {
        private readonly string _value;

        /// <summary>
        /// Basic constructor with attribute value
        /// </summary>
        public CurrencyGlobalNameAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }        
    }
}
