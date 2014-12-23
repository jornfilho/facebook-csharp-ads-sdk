using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoValueForBidTypeOcpmException : Exception
    {
        public InvalidBidInfoValueForBidTypeOcpmException()
        {
        }

        public InvalidBidInfoValueForBidTypeOcpmException(string message) : base(message)
        {
        }

        public InvalidBidInfoValueForBidTypeOcpmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoValueForBidTypeOcpmException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}