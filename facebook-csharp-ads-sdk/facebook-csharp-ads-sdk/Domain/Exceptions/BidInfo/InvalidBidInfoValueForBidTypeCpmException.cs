using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoValueForBidTypeCpmException : Exception
    {
        public InvalidBidInfoValueForBidTypeCpmException()
        {
        }

        public InvalidBidInfoValueForBidTypeCpmException(string message) : base(message)
        {
        }

        public InvalidBidInfoValueForBidTypeCpmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoValueForBidTypeCpmException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}