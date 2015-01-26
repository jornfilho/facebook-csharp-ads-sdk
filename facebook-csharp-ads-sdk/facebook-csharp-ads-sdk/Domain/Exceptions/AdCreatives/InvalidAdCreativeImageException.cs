using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeImageException : Exception
    {
        public InvalidAdCreativeImageException()
        {
        }

        public InvalidAdCreativeImageException(string message) : base(message)
        {
        }

        public InvalidAdCreativeImageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeImageException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
