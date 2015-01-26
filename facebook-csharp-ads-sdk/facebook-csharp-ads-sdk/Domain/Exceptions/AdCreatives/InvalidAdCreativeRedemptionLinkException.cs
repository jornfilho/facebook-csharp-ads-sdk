using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeRedemptionLinkException : Exception
    {
        public InvalidAdCreativeRedemptionLinkException()
        {
        }

        public InvalidAdCreativeRedemptionLinkException(string message) : base(message)
        {
        }

        public InvalidAdCreativeRedemptionLinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeRedemptionLinkException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
