using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeDescriptionException : Exception
    {
        public InvalidAdCreativeDescriptionException()
        {
        }

        public InvalidAdCreativeDescriptionException(string message) : base(message)
        {
        }

        public InvalidAdCreativeDescriptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeDescriptionException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
