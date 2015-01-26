using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeIdException : Exception
    {
        public InvalidAdCreativeIdException()
        {
        }

        public InvalidAdCreativeIdException(string message) : base(message)
        {
        }

        public InvalidAdCreativeIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
