using System;

namespace facebook_csharp_ads_sdk.Domain.Models.Attributes
{
    /// <summary>
    ///     Attribute used to indicate whether a property can be sent in the update of Facebook
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter,
        Inherited = false, AllowMultiple = false)]
    public class CanUpdateOnFacebookAttribute : Attribute, IAttribute<bool>
    {
        #region Properties

        /// <summary>
        ///     Property that stores the attribute value
        /// </summary>
        private readonly bool _value;

        #endregion

        #region Constructor

        /// <summary>
        ///     Construtor base
        /// </summary>
        public CanUpdateOnFacebookAttribute(bool value)
        {
            _value = value;
        }

        #endregion

        /// <summary>
        ///     Getter for the attribute value
        /// </summary>
        public bool Value
        {
            get { return _value; }
        }
    }
}
