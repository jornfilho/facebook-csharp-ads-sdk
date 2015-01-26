using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeClaimLimitException : Exception
    {
        public InvalidAdCreativeClaimLimitException()
        {
        }

        public InvalidAdCreativeClaimLimitException(string message) : base(message)
        {
        }

        public InvalidAdCreativeClaimLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeClaimLimitException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
