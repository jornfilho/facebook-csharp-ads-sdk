using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoValueForBidTypeCpaException : Exception
    {
        public InvalidBidInfoValueForBidTypeCpaException()
        {
        }

        public InvalidBidInfoValueForBidTypeCpaException(string message) : base(message)
        {
        }

        public InvalidBidInfoValueForBidTypeCpaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoValueForBidTypeCpaException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}