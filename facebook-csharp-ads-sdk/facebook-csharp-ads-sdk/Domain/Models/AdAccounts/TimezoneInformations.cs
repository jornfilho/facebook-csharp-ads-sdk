using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with timezone ad account informations
    /// </summary>
    public class TimezoneInformations
    {
        #region Params
        /// <summary>
        /// <para>ID for the timezone. See at https://fbcdn-dragon-a.akamaihd.net/hphotos-ak-prn1/851565_362033717242167_978236896_n.txt </para>
        /// </summary>
        public int TimezoneId { get; private set; }

        /// <summary>
        /// <para>Name for the time zone</para>
        /// </summary>
        public string TimezoneName { get; private set; }

        /// <summary>
        /// <para>Time Zone difference from UTC</para>
        /// </summary>
        public int TimezoneOffsetHoursUtc { get; private set; }
        #endregion

        /// <summary>
        /// Return a list of fields of ad account timezone informations
        /// </summary>
        /// <returns>list of fields of ad account timezone informations</returns>
        public IList<AdAccountFieldsEnum> GetFields()
        {
            return new[]
            {
                AdAccountFieldsEnum.TimezoneId, 
                AdAccountFieldsEnum.TimezoneName, 
                AdAccountFieldsEnum.TimezoneOffsetHoursUtc
            };
        }
    }
}
