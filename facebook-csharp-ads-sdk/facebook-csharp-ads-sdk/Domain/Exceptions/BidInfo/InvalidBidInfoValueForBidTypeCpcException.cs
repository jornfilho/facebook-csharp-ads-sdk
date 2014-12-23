using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoValueForBidTypeCpcException : Exception
    {
        public InvalidBidInfoValueForBidTypeCpcException()
        {
        }

        public InvalidBidInfoValueForBidTypeCpcException(string message) : base(message)
        {
        }

        public InvalidBidInfoValueForBidTypeCpcException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoValueForBidTypeCpcException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}