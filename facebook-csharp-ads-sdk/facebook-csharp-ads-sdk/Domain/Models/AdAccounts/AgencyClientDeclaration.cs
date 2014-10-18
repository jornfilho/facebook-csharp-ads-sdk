namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to agency client declaration
    /// </summary>
    public class AgencyClientDeclaration
    {
        #region Params
        /// <summary>
        /// <para>Whether this account is for an agency representing a client</para>
        /// </summary>
        public long AgencyRepresentingClient { get; private set; }

        /// <summary>
        /// <para>Whether the client is based in France</para>
        /// </summary>
        public long ClientBasedInFrance { get; private set; }

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

        /// <summary>
        /// <para>Whether the agency has a written mandate to advertise on behalf of this client</para>
        /// </summary>
        public long HasWrittenMandateFromAdvertiser { get; private set; }

        /// <summary>
        /// <para>Whether the client is paying via invoice</para>
        /// </summary>
        public long IsClientPayingInvoices { get; private set; }
        #endregion
    }
}
