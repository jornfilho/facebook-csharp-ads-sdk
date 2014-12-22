using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get Facebook properties name
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class FacebookNameAttribute : Attribute, IAttribute<string>
    {
        private readonly string _value;

        /// <summary>
        /// Basic constructor with attribute value
        /// </summary>
        public FacebookNameAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
