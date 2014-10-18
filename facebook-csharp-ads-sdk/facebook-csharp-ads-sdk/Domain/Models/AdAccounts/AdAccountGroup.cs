namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to ad account group
    /// </summary>
    public class AdAccountGroup
    {
        #region Params
        /// <summary>
        /// Id of account group
        /// </summary>
        public long AccountGroupId { get; private set; }

        /// <summary>
        /// Name of account group
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Status of account group
        /// </summary>
        public int Status { get; private set; }
        #endregion
    }
}
