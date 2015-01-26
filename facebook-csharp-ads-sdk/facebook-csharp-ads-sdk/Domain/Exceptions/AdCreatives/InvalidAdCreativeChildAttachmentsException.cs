using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeChildAttachmentsException : Exception
    {
        public InvalidAdCreativeChildAttachmentsException()
        {
        }

        public InvalidAdCreativeChildAttachmentsException(string message) : base(message)
        {
        }

        public InvalidAdCreativeChildAttachmentsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeChildAttachmentsException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
