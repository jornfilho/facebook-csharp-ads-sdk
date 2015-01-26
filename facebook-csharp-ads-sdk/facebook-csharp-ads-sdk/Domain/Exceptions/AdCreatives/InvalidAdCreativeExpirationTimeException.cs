using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeExpirationTimeException : Exception
    {
        public InvalidAdCreativeExpirationTimeException()
        {
        }

        public InvalidAdCreativeExpirationTimeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeExpirationTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeExpirationTimeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
