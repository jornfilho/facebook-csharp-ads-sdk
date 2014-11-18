using System;
using System.Collections.Generic;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with timezone ad account informations
    /// </summary>
    public class TimezoneInformations : BaseObject<TimezoneInformations>
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
        public TimezoneInformations SetTimezoneInformationsData(int timezoneId, string timezoneName, int timezoneOffsetHoursUtc)
        {
            bool isValid = false;

            if (timezoneId > 0)
            {
                TimezoneId = timezoneId;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(timezoneName))
            {
                TimezoneName = timezoneName;
                isValid = true;
            }

            if (timezoneOffsetHoursUtc != 0)
                isValid = true;

            TimezoneOffsetHoursUtc = timezoneOffsetHoursUtc;

            if(isValid)
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

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public TimezoneInformations ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            int timezoneId = 0;
            if (jsonResult["timezone_id"] != null && jsonResult["timezone_id"].Type == JTokenType.Integer)
                timezoneId = jsonResult["timezone_id"].ToString().TryParseInt();

            string timezoneName = null;
            if (jsonResult["timezone_name"] != null && jsonResult["timezone_name"].Type == JTokenType.String)
                timezoneName = jsonResult["timezone_name"].ToString();

            int timezoneOffsetHoursFromUtc = 0;
            if (jsonResult["timezone_offset_hours_utc"] != null && jsonResult["timezone_offset_hours_utc"].Type == JTokenType.Integer)
                timezoneOffsetHoursFromUtc = jsonResult["timezone_offset_hours_utc"].ToString().TryParseInt();

            SetTimezoneInformationsData(timezoneId, timezoneName, timezoneOffsetHoursFromUtc);

            return this;
        }

        public override TimezoneInformations Read(long id)
        {
            throw new NotImplementedException();
        }

        public override TimezoneInformations ParseFacebookResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}
