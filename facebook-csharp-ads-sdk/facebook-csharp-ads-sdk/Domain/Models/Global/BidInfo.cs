using facebook_csharp_ads_sdk.Domain.Enums.Global;

namespace facebook_csharp_ads_sdk.Domain.Models.Global
{
    /// <summary>
    ///     Ad set bid info
    /// </summary>
    public class BidInfo
    {
        /// <summary>
        ///     Bid info objective
        /// </summary>
        public BidInfoObjectiveType Objective { get; private set; }

        /// <summary>
        ///     Bid info value
        /// </summary>
        public int Value { get; private set; }
    }
}