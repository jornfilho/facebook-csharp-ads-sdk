using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetBidInfoException : Exception
    {
        public InvalidAdSetBidInfoException()
        {
        }

        public InvalidAdSetBidInfoException(string message) : base(message)
        {
        }

        public InvalidAdSetBidInfoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetBidInfoException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}