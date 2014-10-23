using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with timezone ad account informations
    /// </summary>
    public class TimezoneInformations : ValidData
    {
        #region Properties
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
        /// Set timezone informations data
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">invalid timezoneId</exception>
        /// <exception cref="ArgumentException">invalid timezoneName</exception>
        public TimezoneInformations SetTimezoneInformationsData(int timezoneId, string timezoneName, int timezoneOffsetHoursUtc)
        {
            if (timezoneId <= 0)
                throw new ArgumentOutOfRangeException();

            if(String.IsNullOrEmpty(timezoneName))
                throw new ArgumentException();


            TimezoneId = timezoneId;
            TimezoneName = timezoneName;
            TimezoneOffsetHoursUtc = timezoneOffsetHoursUtc;

            SetValid();

            return this;
        }

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
