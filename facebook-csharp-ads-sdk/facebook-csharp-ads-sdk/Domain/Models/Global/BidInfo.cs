using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo;

namespace facebook_csharp_ads_sdk.Domain.Models.Global
{
    /// <summary>
    ///     Ad set bid info
    /// </summary>
    public class BidInfo
    {
        #region Constants

        /// <summary>
        ///     Min value is 1 cent
        /// </summary>
        private const int MinValue1Cent = 1;

        /// <summary>
        ///     Min value is 2 cents
        /// </summary>
        private const int MinValue2Cents = 2;

        #endregion Constants

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
        public BidInfo SetAttributesFromFacebookResponse(BidInfoObjectiveTypeEnum objective, int value)
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

        /// <summary>
        ///     Set attributes to create a bid info on Facebook
        /// </summary>
        /// <param name="bidType"> Bid type </param>
        /// <param name="objective"> Objective of the bid info </param>
        /// <param name="value"> Value of the bid info </param>
        /// <exception cref="InvalidAdSetBidTypeException"> Invalid bid type </exception>
        /// <exception cref="InvalidBidInfoObjectiveForBidTypeCpmException"> Invalid bid info objective for the bid type CPM. </exception>
        /// <exception cref="InvalidBidInfoValueForBidTypeCpmException"> Invalid bid info value for the bid type CPM. </exception>
        /// <exception cref="InvalidBidInfoObjectiveForBidTypeCpcException"> Invalid bid info value for the bid type CPC. </exception>
        /// <exception cref="InvalidBidInfoValueForBidTypeCpcException"> Invalid bid info value for the bid type CPC. </exception>
        /// <exception cref="InvalidBidInfoObjectiveForBidTypeCpaException"> Invalid bid info value for the bid type CPA. </exception>
        /// <exception cref="InvalidBidInfoValueForBidTypeCpaException"> Invalid bid info value for the bid type CPA. </exception>
        /// <exception cref="InvalidBidInfoObjectiveForBidTypeOcpmException"> Invalid bid info value for the bid type OCPM. </exception>
        /// <exception cref="InvalidBidInfoValueForBidTypeOcpmException"> Invalid bid info value for the bid type OCPM. </exception>
        /// <returns> This instance </returns>
        public BidInfo SetAttributesToCreate(AdSetBidTypeEnum bidType, BidInfoObjectiveTypeEnum objective, int value)
        {
            switch (bidType)
            {
                case AdSetBidTypeEnum.Undefined:
                    throw new InvalidAdSetBidTypeException();
                case AdSetBidTypeEnum.Cpm:
                    this.ValidateBidInfoForBidTypeCpm(objective, value);
                    break;
                case AdSetBidTypeEnum.Cpc:
                    this.ValidateBidInfoForBidTypeCpc(objective, value);
                    break;
                case AdSetBidTypeEnum.Cpa:
                    this.ValidateBidInfoForBidTypeCpa(objective, value);
                    break;
                case AdSetBidTypeEnum.AbsoluteOcpm:
                    this.ValidateBidInfoForBidTypeOcpm(objective, value);
                    break;
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

        /// <summary>
        ///     Validate the business rules of the bid type OCpm
        /// </summary>
        /// <param name="objective"> Bid info objective type </param>
        /// <param name="value"> Bid info value </param>
        private void ValidateBidInfoForBidTypeOcpm(BidInfoObjectiveTypeEnum objective, int value)
        {
            if (objective != BidInfoObjectiveTypeEnum.Actions &&
                objective != BidInfoObjectiveTypeEnum.Reach &&
                objective != BidInfoObjectiveTypeEnum.Clicks &&
                objective != BidInfoObjectiveTypeEnum.Social)
            {
                throw new InvalidBidInfoObjectiveForBidTypeOcpmException();
            }

            if (objective == BidInfoObjectiveTypeEnum.Actions && value < MinValue1Cent)
            {
                throw new InvalidBidInfoValueForBidTypeOcpmException();
            }

            if (objective == BidInfoObjectiveTypeEnum.Reach && value < MinValue2Cents)
            {
                throw new InvalidBidInfoValueForBidTypeOcpmException();
            }

            if (objective == BidInfoObjectiveTypeEnum.Clicks && value < MinValue1Cent)
            {
                throw new InvalidBidInfoValueForBidTypeOcpmException();
            }

            if (objective == BidInfoObjectiveTypeEnum.Social && value < MinValue1Cent)
            {
                throw new InvalidBidInfoValueForBidTypeOcpmException();
            }
        }

        /// <summary>
        ///     Validate the business rules of the bid type cpa
        /// </summary>
        /// <param name="objective"> Bid info objective type </param>
        /// <param name="value"> Bid info value </param>
        private void ValidateBidInfoForBidTypeCpa(BidInfoObjectiveTypeEnum objective, int value)
        {
            if (objective != BidInfoObjectiveTypeEnum.Actions)
            {
                throw new InvalidBidInfoObjectiveForBidTypeCpaException();
            }

            if (value < MinValue1Cent)
            {
                throw new InvalidBidInfoValueForBidTypeCpaException();
            }
        }

        /// <summary>
        ///     Validate the business rules of the bid type cpc
        /// </summary>
        /// <param name="objective"> Bid info objective type </param>
        /// <param name="value"> Bid info value </param>
        private void ValidateBidInfoForBidTypeCpc(BidInfoObjectiveTypeEnum objective, int value)
        {
            if (objective != BidInfoObjectiveTypeEnum.Clicks)
            {
                throw new InvalidBidInfoObjectiveForBidTypeCpcException();
            }

            if (value < MinValue1Cent)
            {
                throw new InvalidBidInfoValueForBidTypeCpcException();
            }
        }

        /// <summary>
        ///     Validate the business rules of the bid type cpm
        /// </summary>
        /// <param name="objective"> Bid info objective type </param>
        /// <param name="value"> Bid info value </param>
        private void ValidateBidInfoForBidTypeCpm(BidInfoObjectiveTypeEnum objective, int value)
        {
            if (objective != BidInfoObjectiveTypeEnum.Impressions)
            {
                throw new InvalidBidInfoObjectiveForBidTypeCpmException();
            }

            if (value < MinValue2Cents)
            {
                throw new InvalidBidInfoValueForBidTypeCpmException();
            }
        }

        #endregion Private methods
    }
}