using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts
{
    /// <summary>
    /// <para>Currencies enumerator with code and offset</para>
    /// <para>Web reference: http://www.xe.com/symbols.php </para>
    /// <para>Facebook reference: https://developers.facebook.com/docs/reference/ads-api/currencies/ </para>
    /// </summary>
    public enum CurrenciesEnum
    {
        /// <summary>
        /// Undefined
        /// </summary>
        [CurrencyGlobalName("Undefined")]
        [CurrencySymbol("")]
        [CurrencyOffset(100)]
        UND = 0,

        /// <summary>
        /// Argentine Peso
        /// </summary>
        [CurrencyGlobalName("Argentine Peso")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]        
        ARS = 1,

        /// <summary>
        /// Australian Dollar
        /// </summary>
        [CurrencyGlobalName("Australian Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        AUD = 2,

        /// <summary>
        /// Bolivian Boliviano
        /// </summary>
        [CurrencyGlobalName("Bolivian Boliviano")]
        [CurrencySymbol("$b")]
        [CurrencyOffset(100)]
        BOB = 3,

        /// <summary>
        /// Brazilian Real
        /// </summary>
        [CurrencyGlobalName("Brazilian Real")]
        [CurrencySymbol("R$")]
        [CurrencyOffset(100)]
        BRL = 4,

        /// <summary>
        /// British Pound
        /// </summary>
        [CurrencyGlobalName("British Pound")]
        [CurrencySymbol("£")]
        [CurrencyOffset(100)]
        GBP = 5,

        /// <summary>
        /// Bulgarian Lev
        /// </summary>
        [CurrencyGlobalName("Bulgarian Lev")]
        [CurrencySymbol("лв")]
        [CurrencyOffset(100)]
        BGN = 6,

        /// <summary>
        /// Canadian Dollar
        /// </summary>
        [CurrencyGlobalName("Canadian Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        CAD = 7,

        /// <summary>
        /// Chilean Peso
        /// </summary>
        [CurrencyGlobalName("Chilean Peso")]
        [CurrencySymbol("$")]
        [CurrencyOffset(1)]
        CLP = 8,

        /// <summary>
        /// Colombian Peso
        /// </summary>
        [CurrencyGlobalName("Colombian Peso")]
        [CurrencySymbol("$")]
        [CurrencyOffset(1)]
        COP = 9,

        /// <summary>
        /// Costa Rican Colon
        /// </summary>
        [CurrencyGlobalName("Costa Rican Colon")]
        [CurrencySymbol("₡")]
        [CurrencyOffset(1)]
        CRC = 10,

        /// <summary>
        /// Czech Koruna
        /// </summary>
        [CurrencyGlobalName("Czech Koruna")]
        [CurrencySymbol("Kč")]
        [CurrencyOffset(100)]
        CZK = 11,

        /// <summary>
        /// Danish Krone
        /// </summary>
        [CurrencyGlobalName("Danish Krone")]
        [CurrencySymbol("kr")]
        [CurrencyOffset(100)]
        DKK = 12,

        /// <summary>
        /// Euro
        /// </summary>
        [CurrencyGlobalName("Euro")]
        [CurrencySymbol("€")]
        [CurrencyOffset(100)]
        EUR = 13,

        /// <summary>
        /// Guatemalan Quetza
        /// </summary>
        [CurrencyGlobalName("Guatemalan Quetza")]
        [CurrencySymbol("Q")]
        [CurrencyOffset(100)]
        GTQ = 14,

        /// <summary>
        /// Honduran Lempira
        /// </summary>
        [CurrencyGlobalName("Honduran Lempira")]
        [CurrencySymbol("L")]
        [CurrencyOffset(100)]
        HNL = 15,

        /// <summary>
        /// Hong Kong Dollar
        /// </summary>
        [CurrencyGlobalName("Hong Kong Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        HKD = 16,

        /// <summary>
        /// Hungarian Forint
        /// </summary>
        [CurrencyGlobalName("Hungarian Forint")]
        [CurrencySymbol("Ft")]
        [CurrencyOffset(1)]
        HUF = 17,

        /// <summary>
        /// Iceland Krona
        /// </summary>
        [CurrencyGlobalName("Iceland Krona")]
        [CurrencySymbol("kr")]
        [CurrencyOffset(1)]
        ISK = 18,

        /// <summary>
        /// Indian Rupee
        /// </summary>
        [CurrencyGlobalName("Indian Rupee")]
        [CurrencyOffset(100)]
        INR = 19,

        /// <summary>
        /// Israeli New Shekel
        /// </summary>
        [CurrencyGlobalName("Israeli New Shekel")]
        [CurrencySymbol("₪")]
        [CurrencyOffset(100)]
        ILS = 20,

        /// <summary>
        /// Japanese Yen
        /// </summary>
        [CurrencyGlobalName("Japanese Yen")]
        [CurrencySymbol("¥")]
        [CurrencyOffset(1)]
        JPY = 21,

        /// <summary>
        /// Korean Won
        /// </summary>
        [CurrencyGlobalName("Korean Won")]
        [CurrencySymbol("₩")]
        [CurrencyOffset(1)]
        KRW = 22,

        /// <summary>
        /// Macau Patacas
        /// </summary>
        [CurrencyGlobalName("Macau Patacas")]
        [CurrencyOffset(100)]
        MOP = 23,

        /// <summary>
        /// Malaysian Ringgit
        /// </summary>
        [CurrencyGlobalName("Malaysian Ringgit")]
        [CurrencySymbol("RM")]
        [CurrencyOffset(100)]
        MYR = 24,

        /// <summary>
        /// Mexican Peso
        /// </summary>
        [CurrencyGlobalName("Mexican Peso")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        MXN = 25,

        /// <summary>
        /// New Zealand Dollar
        /// </summary>
        [CurrencyGlobalName("New Zealand Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        NZD = 26,

        /// <summary>
        /// Nicaraguan Cordoba
        /// </summary>
        [CurrencyGlobalName("Nicaraguan Cordoba")]
        [CurrencySymbol("C$")]
        [CurrencyOffset(100)]
        NIO = 27,

        /// <summary>
        /// Norwegian Krone
        /// </summary>
        [CurrencyGlobalName("Norwegian Krone")]
        [CurrencySymbol("kr")]
        [CurrencyOffset(100)]
        NOK = 28,

        /// <summary>
        /// Paraguayan Guarani
        /// </summary>
        [CurrencyGlobalName("Paraguayan Guarani")]
        [CurrencySymbol("Gs")]
        [CurrencyOffset(1)]
        PYG = 29,

        /// <summary>
        /// Peruvian Nuevo Sol
        /// </summary>
        [CurrencyGlobalName("Peruvian Nuevo Sol")]
        [CurrencySymbol("S/.")]
        [CurrencyOffset(100)]
        PEN = 30,

        /// <summary>
        /// Philippine Peso
        /// </summary>
        [CurrencyGlobalName("Philippine Peso")]
        [CurrencySymbol("₱")]
        [CurrencyOffset(100)]
        PHP = 31,

        /// <summary>
        /// Polish Zloty
        /// </summary>
        [CurrencyGlobalName("Polish Zloty")]
        [CurrencySymbol("zł")]
        [CurrencyOffset(100)]
        PLN = 32,

        /// <summary>
        /// Qatari Rials
        /// </summary>
        [CurrencyGlobalName("Qatari Rials")]
        [CurrencySymbol("﷼")]
        [CurrencyOffset(100)]
        QAR = 33,

        /// <summary>
        /// Romanian Leu
        /// </summary>
        [CurrencyGlobalName("Romanian Leu")]
        [CurrencySymbol("lei")]
        [CurrencyOffset(100)]
        RON = 34,

        /// <summary>
        /// Russian Ruble
        /// </summary>
        [CurrencyGlobalName("Russian Ruble")]
        [CurrencySymbol("руб")]
        [CurrencyOffset(100)]
        RUB = 35,

        /// <summary>
        /// Saudi Arabian Riyal
        /// </summary>
        [CurrencyGlobalName("Saudi Arabian Riyal")]
        [CurrencySymbol("﷼")]
        [CurrencyOffset(100)]
        SAR = 36,

        /// <summary>
        /// Singapore Dollar
        /// </summary>
        [CurrencyGlobalName("Singapore Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        SGD = 37,

        /// <summary>
        /// South African Rand
        /// </summary>
        [CurrencyGlobalName("South African Rand")]
        [CurrencySymbol("R")]
        [CurrencyOffset(100)]
        ZAR = 38,

        /// <summary>
        /// Swedish Krona
        /// </summary>
        [CurrencyGlobalName("Swedish Krona")]
        [CurrencySymbol("kr")]
        [CurrencyOffset(100)]
        SEK = 39,

        /// <summary>
        /// Swiss Franc
        /// </summary>
        [CurrencyGlobalName("Swiss Franc")]
        [CurrencySymbol("CHF")]
        [CurrencyOffset(100)]
        CHF = 40,

        /// <summary>
        /// Taiwan Dollar
        /// </summary>
        [CurrencyGlobalName("Taiwan Dollar")]
        [CurrencySymbol("NT$")]
        [CurrencyOffset(1)]
        TWD = 41,

        /// <summary>
        /// Thai Baht
        /// </summary>
        [CurrencyGlobalName("Thai Baht")]
        [CurrencySymbol("฿")]
        [CurrencyOffset(100)]
        THB = 42,

        /// <summary>
        /// Turkish Lira
        /// </summary>
        [CurrencyGlobalName("Turkish Lira")]
        [CurrencyOffset(100)]
        TRY = 43,

        /// <summary>
        /// UAE Dirham
        /// </summary>
        [CurrencyGlobalName("UAE Dirham")]
        [CurrencyOffset(100)]
        AED = 44,

        /// <summary>
        /// United States Dollar
        /// </summary>
        [CurrencyGlobalName("United States Dollar")]
        [CurrencySymbol("$")]
        [CurrencyOffset(100)]
        USD = 45,

        /// <summary>
        /// Uruguay Peso
        /// </summary>
        [CurrencyGlobalName("Uruguay Peso")]
        [CurrencySymbol("$U")]
        [CurrencyOffset(100)]
        UYU = 46,

        /// <summary>
        /// Venezuelan Bolivar
        /// </summary>
        [CurrencyGlobalName("Venezuelan Bolivar")]
        [CurrencySymbol("Bs")]
        [CurrencyOffset(100)]
        VEF = 47
    }
}
