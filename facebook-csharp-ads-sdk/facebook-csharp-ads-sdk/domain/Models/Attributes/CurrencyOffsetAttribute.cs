using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get currency offset
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class CurrencyOffsetAttribute : Attribute, IAttribute<int>
    {
        private readonly int _value;

        public CurrencyOffsetAttribute(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
        }        
    }
}
