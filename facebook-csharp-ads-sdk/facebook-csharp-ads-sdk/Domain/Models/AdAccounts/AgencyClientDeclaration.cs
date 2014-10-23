using System;
using facebook_csharp_ads_sdk.Domain.Contracts.Common;

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
            if (!String.IsNullOrEmpty(clientName))
                ClientName = clientName;

            if (!String.IsNullOrEmpty(clientEmailAddress))
                ClientEmailAddress = clientEmailAddress;

            if (!String.IsNullOrEmpty(clientStreet))
                ClientStreet = clientStreet;

            if (!String.IsNullOrEmpty(clientStreet2))
                ClientStreet2 = clientStreet2;

            if (!String.IsNullOrEmpty(clientCity))
                ClientCity = clientCity;

            if (!String.IsNullOrEmpty(clientProvince))
                ClientProvince = clientProvince;

            if (!String.IsNullOrEmpty(clientPostalCode))
                ClientPostalCode = clientPostalCode;

            if (!String.IsNullOrEmpty(clientCountryCode))
                ClientCountryCode = clientCountryCode;

            if (!String.IsNullOrEmpty(clientName) ||
                !String.IsNullOrEmpty(clientEmailAddress) ||
                !String.IsNullOrEmpty(clientStreet) ||
                !String.IsNullOrEmpty(clientStreet2) ||
                !String.IsNullOrEmpty(clientCity) ||
                !String.IsNullOrEmpty(clientProvince) ||
                !String.IsNullOrEmpty(clientPostalCode) ||
                !String.IsNullOrEmpty(clientCountryCode))
                SetValid();

            return this;
        }
    }
}
