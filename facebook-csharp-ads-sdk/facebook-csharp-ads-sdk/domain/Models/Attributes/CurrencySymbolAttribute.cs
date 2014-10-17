using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk.domain.Models.Attributes
{
    /// <summary>
    /// Class for custom attibutes used to get currency symbol
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class CurrencySymbolAttribute : Attribute, IAttribute<string>
    {
        private readonly string _value;

        public CurrencySymbolAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }        
    }
}
