namespace facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts
{
    /// <summary>
    /// Class with business rules of ad account basic data
    /// </summary>
    public static class BasicData
    {
        #region Ad account id
        /// <summary>
        /// Test if ad account id has a vaid value
        /// </summary>
        public static bool IsValidAdAccountId(this long adAccountId)
        {
            return adAccountId > 0;
        }

        /// <summary>
        /// Test if ad account id has a vaid value
        /// </summary>
        public static bool IsValidAdAccountId(this long? adAccountId)
        {
            return (adAccountId ?? 0).IsValidAdAccountId();
        }

        /// <summary>
        /// Test if ad account id has a vaid value
        /// </summary>
        public static bool IsValidAdAccountId(this string strId, long adAccountId)
        {
            return adAccountId.IsValidAdAccountId() && string.Format("act_{0}", adAccountId).Equals(strId);
        } 
        #endregion

        #region Ad campaign

        /// <summary>
        /// Test if ad campaign id has a valid value
        /// </summary>
        public static bool IsValidAdCampaignId(this long adCampaignId)
        {
            return adCampaignId > 0;
        }

        #endregion Ad campaign

        #region Ad set

        /// <summary>
        ///     Test if ad set id has a valid value
        /// </summary>
        public static bool IsValidAdSetId(this long adSetId)
        {
            return adSetId > 0;
        }

        #endregion Ad set
    }
}
