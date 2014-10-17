using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk.domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get Facebook properties name
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class FacebookNameAttribute : Attribute, IAttribute<string>
    {
        public FacebookNameAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        private readonly string _value;
    }
}
