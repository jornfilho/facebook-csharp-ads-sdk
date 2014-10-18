namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts
{
    /// <summary>
    /// Class to ad account funding source details
    /// </summary>
    public class FundingSourceDetail
    {
        #region Params
        public long Id { get; private set; }

        public string DisplayString { get; private set; }

        //TODO: Know more about this field on Facebook
        public int Type { get; private set; }
        #endregion
    }
}
