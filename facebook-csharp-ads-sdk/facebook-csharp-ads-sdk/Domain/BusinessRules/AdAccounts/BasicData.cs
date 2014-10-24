﻿namespace facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts
{
    /// <summary>
    /// Class with business rules of ad account basic data
    /// </summary>
    public static class BasicData
    {
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
            return adAccountId.IsValidAdAccountId() && string.Format("act_{0}",adAccountId).Equals(strId);
        }
    }
}