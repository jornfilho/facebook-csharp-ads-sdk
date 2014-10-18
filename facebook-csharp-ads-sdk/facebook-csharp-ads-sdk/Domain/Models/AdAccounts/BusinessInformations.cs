using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class with ad account business informations
    /// </summary>
    public class BusinessInformations
    {
        #region Params
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
