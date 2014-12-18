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
        public BidInfoObjectiveTypeEnum? Objective { get; private set; }

        /// <summary>
        ///     Bid info value
        /// </summary>
        public int? Value { get; private set; }

        /// <summary>
        ///     Set attibutes value
        /// </summary>
        /// <param name="objective"> Bid info objective </param>
        /// <param name="value"> Value to bid info </param>
        /// <returns> This instance </returns>
        public BidInfo SetAttributes(BidInfoObjectiveTypeEnum objective, int value)
        {
            if (objective == BidInfoObjectiveTypeEnum.Undefined)
            {
                this.SetDefaultValues();
                return this;
            }

            if (value < 0)
            {
                this.SetDefaultValues();
                return this;
            }

            this.Objective = objective;
            this.Value = value;
            return this;
        }

        #region Private methods

        /// <summary>
        ///     Set default value attributes 
        /// </summary>
        private void SetDefaultValues()
        {
            this.Objective = null;
            this.Value = null;
        }

        #endregion Private methods
    }
}