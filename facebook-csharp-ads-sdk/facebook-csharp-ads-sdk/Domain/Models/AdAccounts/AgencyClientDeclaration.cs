using System;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to agency client declaration
    /// </summary>
    public class AgencyClientDeclaration : ValidData
    {
        #region Properties
        /// <summary>
        /// <para>Whether this account is for an agency representing a client</para>
        /// </summary>
        public bool AgencyRepresentingClient { get; private set; }

        /// <summary>
        /// <para>Whether the client is based in France</para>
        /// </summary>
        public bool ClientBasedInFrance { get; private set; }

        /// <summary>
        /// <para>Whether the agency has a written mandate to advertise on behalf of this client</para>
        /// </summary>
        public bool HasWrittenMandateFromAdvertiser { get; private set; }

        /// <summary>
        /// <para>Whether the client is paying via invoice</para>
        /// </summary>
        public bool IsClientPayingInvoices { get; private set; }

        /// <summary>
        /// <para>Client's city</para>
        /// </summary>
        public string ClientCity { get; private set; }

        /// <summary>
        /// <para>Client's country code</para>
        /// </summary>
        public string ClientCountryCode { get; private set; }

        /// <summary>
        /// <para>Client's email address</para>
        /// </summary>
        public string ClientEmailAddress { get; private set; }

        /// <summary>
        /// <para>Name of the client</para>
        /// </summary>
        public string ClientName { get; private set; }

        /// <summary>
        /// <para>Client's postal code</para>
        /// </summary>
        public string ClientPostalCode { get; private set; }

        /// <summary>
        /// <para>Client's province</para>
        /// </summary>
        public string ClientProvince { get; private set; }

        /// <summary>
        /// <para>First line of client's street address</para>
        /// </summary>
        public string ClientStreet { get; private set; }

        /// <summary>
        /// <para>Second line of client's street address</para>
        /// </summary>
        public string ClientStreet2 { get; private set; }
        #endregion

        /// <summary>
        /// Set summary informations data
        /// </summary>
        public AgencyClientDeclaration SetClientSummaryInformationsData(bool agencyRepresentingClient, bool clientBasedInFrance, bool hasWrittenMandateFromAdvertiser, 
            bool isClientPayingInvoices)
        {
            AgencyRepresentingClient = agencyRepresentingClient;
            ClientBasedInFrance = clientBasedInFrance;
            HasWrittenMandateFromAdvertiser = hasWrittenMandateFromAdvertiser;
            IsClientPayingInvoices = isClientPayingInvoices;

            SetValid();

            return this;
        }

        /// <summary>
        /// Set address informations data
        /// </summary>
        public AgencyClientDeclaration SetClientAddressInformationsData(string clientCity, string clientCountryCode, string clientEmailAddress, string clientName, 
            string clientPostalCode, string clientProvince, string clientStreet, string clientStreet2)
        {
            var isValid = false;

            if (!String.IsNullOrEmpty(clientName))
            {
                ClientName = clientName;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientEmailAddress) && DevUtils.Validators.Email.IsEmailValid(clientEmailAddress))
            {
                ClientEmailAddress = clientEmailAddress;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientStreet))
            {
                ClientStreet = clientStreet;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientStreet2))
            {
                ClientStreet2 = clientStreet2;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientCity))
            {
                ClientCity = clientCity;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientProvince))
            {
                ClientProvince = clientProvince;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientPostalCode))
            {
                ClientPostalCode = clientPostalCode;
                isValid = true;
            }

            if (!String.IsNullOrEmpty(clientCountryCode))
            {
                ClientCountryCode = clientCountryCode;
                isValid = true;
            }

            if (isValid)
                SetValid();
            
            return this;
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public AgencyClientDeclaration ParseApiResponse(JToken jsonResult)
        {
            if (jsonResult == null)
                return this;

            #region Summary
            bool agencyRepresentingClient = false, clientBasedInFrance = false, hasWrittenMandateFromAdvertiser = false, 
                isClientPayingInvoices = false, sendSummary = false;
            if (jsonResult["agency_representing_client"] != null &&
                jsonResult["agency_representing_client"].Type == JTokenType.Integer)
            {
                agencyRepresentingClient = jsonResult["agency_representing_client"].ToString().TryParseInt() == 1;
                sendSummary = true;
            }

            if (jsonResult["client_based_in_france"] != null &&
                jsonResult["client_based_in_france"].Type == JTokenType.Integer)
            {
                clientBasedInFrance = jsonResult["client_based_in_france"].ToString().TryParseInt() == 1;
                sendSummary = true;
            }

            if (jsonResult["has_written_mandate_from_advertiser"] != null &&
                jsonResult["has_written_mandate_from_advertiser"].Type == JTokenType.Integer)
            {
                hasWrittenMandateFromAdvertiser = jsonResult["has_written_mandate_from_advertiser"].ToString().TryParseInt() == 1;
                sendSummary = true;
            }

            if (jsonResult["is_client_paying_invoices"] != null &&
                jsonResult["is_client_paying_invoices"].Type == JTokenType.Integer)
            {
                isClientPayingInvoices = jsonResult["is_client_paying_invoices"].ToString().TryParseInt() == 1;
                sendSummary = true;
            }

            if (sendSummary)
                SetClientSummaryInformationsData(agencyRepresentingClient, clientBasedInFrance, hasWrittenMandateFromAdvertiser, isClientPayingInvoices);
            #endregion

            #region Address
            string clientName = null, clientStreet = null, clientStreet2 = null;
            string clientCity = null, clientProvince = null, clientPostalCode = null;
            string clientCountryCode = null, clientEmailAddress = null;

            if (jsonResult["client_city"] != null && jsonResult["client_city"].Type == JTokenType.String)
                clientCity = jsonResult["client_city"].ToString();

            if (jsonResult["client_country_code"] != null && jsonResult["client_country_code"].Type == JTokenType.String)
                clientCountryCode = jsonResult["client_country_code"].ToString();

            if (jsonResult["client_email_address"] != null && jsonResult["client_email_address"].Type == JTokenType.String)
                clientEmailAddress = jsonResult["client_email_address"].ToString();

            if (jsonResult["client_name"] != null && jsonResult["client_name"].Type == JTokenType.String)
                clientName = jsonResult["client_name"].ToString();

            if (jsonResult["client_postal_code"] != null && jsonResult["client_postal_code"].Type == JTokenType.String)
                clientPostalCode = jsonResult["client_postal_code"].ToString();

            if (jsonResult["client_province"] != null && jsonResult["client_province"].Type == JTokenType.String)
                clientProvince = jsonResult["client_province"].ToString();

            if (jsonResult["client_street"] != null && jsonResult["client_street"].Type == JTokenType.String)
                clientStreet = jsonResult["client_street"].ToString();

            if (jsonResult["client_street2"] != null && jsonResult["client_street2"].Type == JTokenType.String)
                clientStreet2 = jsonResult["client_street2"].ToString();

            SetClientAddressInformationsData(clientCity, clientCountryCode, clientEmailAddress, clientName,
                clientPostalCode, clientProvince, clientStreet, clientStreet2);
            #endregion

            return this;
        }
    }
}
