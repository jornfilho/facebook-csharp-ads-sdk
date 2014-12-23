using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetBidTypeException : Exception
    {
        public InvalidAdSetBidTypeException()
        {
        }

        public InvalidAdSetBidTypeException(string message) : base(message)
        {
        }

        public InvalidAdSetBidTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetBidTypeException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}