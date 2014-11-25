using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with ad account business informations
    /// </summary>
    public class BusinessInformations : BaseObject
    {
        #region Properties
        /// <summary>
        /// <para>The business name for the account</para>
        /// </summary>
        public string BusinessName { get; private set; }

        /// <summary>
        /// <para>First line of the business street address for the account</para>
        /// </summary>
        public string BusinessStreet { get; private set; }

        /// <summary>
        /// <para>Second line of the business street address for the account</para>
        /// </summary>
        public string BusinessStreet2 { get; private set; }

        /// <summary>
        /// <para>City for business address</para>
        /// </summary>
        public string BusinessCity { get; private set; }

        /// <summary>
        /// <para>State abbreviation for business address</para>
        /// </summary>
        public string BusinessState { get; private set; }

        /// <summary>
        /// <para>Zip code for business address</para>
        /// </summary>
        public string BusinessZip { get; private set; }

        /// <summary>
        /// <para>Country code for the business address</para>
        /// </summary>
        public string BusinessCountryCode { get; private set; }
        #endregion

        /// <summary>
        /// Set business information data
        /// </summary>
        public BusinessInformations SetBusinessInformationsData(string businessName, string businessStreet, 
            string businessStreet2, string businessCity, string businessState, 
            string businessZip, string businessCountryCode)
        {
            bool isValid = false;

            if (!String.IsNullOrEmpty(businessName))
            {
                BusinessName = businessName;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessStreet))
            {
                BusinessStreet = businessStreet;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessStreet2))
            {
                BusinessStreet2 = businessStreet2;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessCity))
            {
                BusinessCity = businessCity;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessState))
            {
                BusinessState = businessState;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessZip))
            {
                BusinessZip = businessZip;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(businessCountryCode))
            {
                BusinessCountryCode = businessCountryCode;
                isValid = true;
            }

            if (isValid)
                SetValid();

            return this;
        }

        /// <summary>
        /// Return a list of fields of ad account business informations
        /// </summary>
        /// <returns>list of fields of ad account business informations</returns>
        public IList<AdAccountFieldsEnum> GetFields()
        {
            return new[]
            {
                AdAccountFieldsEnum.BusinessName, 
                AdAccountFieldsEnum.BusinessStreet, 
                AdAccountFieldsEnum.BusinessStreet2, 
                AdAccountFieldsEnum.BusinessCity, 
                AdAccountFieldsEnum.BusinessState, 
                AdAccountFieldsEnum.BusinessZip, 
                AdAccountFieldsEnum.BusinessCountryCode
            };
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public BusinessInformations ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            string businessName = null, businessStreet = null, businessStreet2 = null;
            string businessCity = null, businessState = null, businessZip = null;
            string businessCountryCode = null;

            if (jsonResult["business_name"] != null && jsonResult["business_name"].Type == JTokenType.String)
                businessName = jsonResult["business_name"].ToString();

            if (jsonResult["business_street"] != null && jsonResult["business_street"].Type == JTokenType.String)
                businessStreet = jsonResult["business_street"].ToString();
            
            if (jsonResult["business_street2"] != null && jsonResult["business_street2"].Type == JTokenType.String)
                businessStreet2 = jsonResult["business_street2"].ToString();

            if (jsonResult["business_city"] != null && jsonResult["business_city"].Type == JTokenType.String)
                businessCity = jsonResult["business_city"].ToString();

            if (jsonResult["business_state"] != null && jsonResult["business_state"].Type == JTokenType.String)
                businessState = jsonResult["business_state"].ToString();

            if (jsonResult["business_zip"] != null && jsonResult["business_zip"].Type == JTokenType.String)
                businessZip = jsonResult["business_zip"].ToString();

            if (jsonResult["business_country_code"] != null && jsonResult["business_country_code"].Type == JTokenType.String)
                businessCountryCode = jsonResult["business_country_code"].ToString();

            SetBusinessInformationsData(businessName, businessStreet, businessStreet2, businessCity, businessState,
                businessZip, businessCountryCode);

            return this;
        }
    }
    
}
