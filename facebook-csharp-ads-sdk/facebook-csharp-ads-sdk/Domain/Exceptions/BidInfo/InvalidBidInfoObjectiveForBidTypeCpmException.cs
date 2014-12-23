using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoObjectiveForBidTypeCpmException : Exception
    {
        public InvalidBidInfoObjectiveForBidTypeCpmException()
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpmException(string message) : base(message)
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoObjectiveForBidTypeCpmException([NotNull] SerializationInfo info,
                                                                StreamingContext context) : base(info, context)
        {
        }
    }
}