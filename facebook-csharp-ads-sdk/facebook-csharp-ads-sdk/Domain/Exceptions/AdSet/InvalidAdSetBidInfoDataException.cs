using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetBidInfoDataException : Exception
    {
        public InvalidAdSetBidInfoDataException()
        {
        }

        public InvalidAdSetBidInfoDataException(string message) : base(message)
        {
        }

        public InvalidAdSetBidInfoDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidAdSetBidInfoDataException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}