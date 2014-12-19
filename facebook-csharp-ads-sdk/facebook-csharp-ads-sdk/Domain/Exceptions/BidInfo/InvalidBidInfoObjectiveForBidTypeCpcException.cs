using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoObjectiveForBidTypeCpcException : Exception
    {
        public InvalidBidInfoObjectiveForBidTypeCpcException()
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpcException(string message) : base(message)
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpcException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoObjectiveForBidTypeCpcException([NotNull] SerializationInfo info,
                                                                StreamingContext context) : base(info, context)
        {
        }
    }
}