using System;
using System.Diagnostics;
using System.Globalization;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute
{
    /// <summary>
    /// Class to get custom enum option attribute
    /// </summary>
    public static class GetCustomEnumAttributeValueExtensions
    {
        /// <summary>
        /// Get custom enum attribute value
        /// </summary>
        /// <typeparam name="T">Attribute class</typeparam>
        /// <typeparam name="TR">Attribute type</typeparam>
        /// <param name="enum">enumevator</param>
        /// <returns>attribute value</returns>
        public static TR GetCustomEnumAttributeValue<T, TR>(this IConvertible @enum)
        {
            var attributeValue = default(TR);
            try
            {
                if (@enum != null)
                {
                    var fi = @enum.GetType().GetField(@enum.ToString(CultureInfo.InvariantCulture));
                    if (fi != null)
                    {
                        var attributes = fi.GetCustomAttributes(typeof(T), false) as T[];
                        if (attributes != null && attributes.Length > 0)
                        {
                            var attribute = attributes[0] as IAttribute<TR>;
                            if (attribute != null)
                                attributeValue = attribute.Value;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return attributeValue;
        }
    }
}
