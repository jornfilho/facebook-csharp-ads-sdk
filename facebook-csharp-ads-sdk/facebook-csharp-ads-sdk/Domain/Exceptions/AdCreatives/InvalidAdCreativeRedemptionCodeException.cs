using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeRedemptionCodeException : Exception
    {
        public InvalidAdCreativeRedemptionCodeException()
        {
        }

        public InvalidAdCreativeRedemptionCodeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeRedemptionCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeRedemptionCodeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
