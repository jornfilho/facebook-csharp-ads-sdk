using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeVideoIdException : Exception
    {
        public InvalidAdCreativeVideoIdException()
        {
        }

        public InvalidAdCreativeVideoIdException(string message) : base(message)
        {
        }

        public InvalidAdCreativeVideoIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeVideoIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
