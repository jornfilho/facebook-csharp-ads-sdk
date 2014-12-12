using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    ///     Class to identify properties that are returned when creating an object
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class IsFacebookCreateResponseAttribute : Attribute, IAttribute<bool>
    {
        private readonly bool _value;

        /// <summary>
        ///     Construtor base com atribuição do valor
        /// </summary>
        public IsFacebookCreateResponseAttribute(bool value)
        {
            _value = value;
        }

        /// <summary>
        ///     Getter base classe
        /// </summary>
        public bool Value
        {
            get { return _value; }
        }
    }
}