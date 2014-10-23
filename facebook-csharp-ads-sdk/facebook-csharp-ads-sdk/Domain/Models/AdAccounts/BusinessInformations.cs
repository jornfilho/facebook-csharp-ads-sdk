using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with ad account business informations
    /// </summary>
    public class BusinessInformations : ValidData
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
            if (!String.IsNullOrEmpty(businessName))
                BusinessName = businessName;

            if (!String.IsNullOrEmpty(businessStreet))
                BusinessStreet = businessStreet;

            if (!String.IsNullOrEmpty(businessStreet2))
                BusinessStreet2 = businessStreet2;

            if (!String.IsNullOrEmpty(businessCity))
                BusinessCity = businessCity;

            if (!String.IsNullOrEmpty(businessState))
                BusinessState = businessState;

            if (!String.IsNullOrEmpty(businessZip))
                BusinessZip = businessZip;

            if (!String.IsNullOrEmpty(businessCountryCode))
                BusinessCountryCode = businessCountryCode;

            if (!String.IsNullOrEmpty(businessName) ||
                !String.IsNullOrEmpty(businessStreet) ||
                !String.IsNullOrEmpty(businessStreet2) ||
                !String.IsNullOrEmpty(businessCity) ||
                !String.IsNullOrEmpty(businessState) ||
                !String.IsNullOrEmpty(businessZip) ||
                !String.IsNullOrEmpty(businessCountryCode))
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
    }
    
}
