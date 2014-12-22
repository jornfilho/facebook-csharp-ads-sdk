using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get flag if field has an object or primitive value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class IsParentObjectAttribute : Attribute, IAttribute<bool>
    {
        /// <summary>
        /// Basic constructor with attribute value
        /// </summary>
        public IsParentObjectAttribute(bool value)
        {
            _value = value;
        }

        public bool Value
        {
            get { return _value; }
        }

        private readonly bool _value;
    }
}
