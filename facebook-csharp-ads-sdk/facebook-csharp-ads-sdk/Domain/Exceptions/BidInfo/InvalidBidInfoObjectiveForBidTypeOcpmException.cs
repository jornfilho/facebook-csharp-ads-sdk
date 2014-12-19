using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoObjectiveForBidTypeOcpmException : Exception
    {
        public InvalidBidInfoObjectiveForBidTypeOcpmException()
        {
        }

        public InvalidBidInfoObjectiveForBidTypeOcpmException(string message) : base(message)
        {
        }

        public InvalidBidInfoObjectiveForBidTypeOcpmException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBidInfoObjectiveForBidTypeOcpmException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}