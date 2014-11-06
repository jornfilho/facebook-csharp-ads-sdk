using System;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Attribute;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdAccounts
{
    public static class CurrenciesEnumExtensions
    {
        /// <summary>
        /// Get Global Name enum custom attribute
        /// </summary>
        public static string GetCurrencyGlobalName(this CurrenciesEnum currency)
        {
            return currency.GetCustomEnumAttributeValue<CurrencyGlobalNameAttribute, string>();
        }

        /// <summary>
        /// Get Global Name enum custom attribute
        /// </summary>
        public static string GetCurrencyGlobalName(this CurrenciesEnum? currency)
        {
            if (currency == null)
                currency = CurrenciesEnum.UND;
            
            return currency.Value.GetCurrencyGlobalName();
        }

        /// <summary>
        /// Get Symbol enum custom attribute
        /// </summary>
        public static string GetCurrencySymbol(this CurrenciesEnum currency)
        {
            return currency.GetCustomEnumAttributeValue<CurrencySymbolAttribute, string>();
        }

        /// <summary>
        /// Get Symbol enum custom attribute
        /// </summary>
        public static string GetCurrencySymbol(this CurrenciesEnum? currency)
        {
            if (currency == null)
                currency = CurrenciesEnum.UND;

            return currency.Value.GetCurrencySymbol();
        }

        /// <summary>
        /// Get Offset enum custom attribute
        /// </summary>
        public static int GetCurrencyOffset(this CurrenciesEnum currency)
        {
            return currency.GetCustomEnumAttributeValue<CurrencyOffsetAttribute, int>();
        }

        /// <summary>
        /// Get Offset enum custom attribute
        /// </summary>
        public static int GetCurrencyOffset(this CurrenciesEnum? currency)
        {
            if (currency == null)
                currency = CurrenciesEnum.UND;

            return currency.Value.GetCurrencyOffset();
        }
        
        /// <summary>
        /// Get Offset enum custom attribute
        /// </summary>
        public static CurrenciesEnum GetCurrencyEnum(this string currencyString)
        {
            if (String.IsNullOrEmpty(currencyString))
                return CurrenciesEnum.UND;

            foreach (CurrenciesEnum currency in Enum.GetValues(typeof (CurrenciesEnum)))
            {
                //Code comparator
                if (currency.ToString().Equals(currencyString, StringComparison.InvariantCultureIgnoreCase))
                    return currency;

                //Global name
                if (currency.GetCurrencyGlobalName().Equals(currencyString, StringComparison.InvariantCultureIgnoreCase))
                    return currency;

                //Symbol name
                if (currency.GetCurrencySymbol().Equals(currencyString, StringComparison.InvariantCultureIgnoreCase))
                    return currency;
            }

            return CurrenciesEnum.UND;
        }
    }
}
