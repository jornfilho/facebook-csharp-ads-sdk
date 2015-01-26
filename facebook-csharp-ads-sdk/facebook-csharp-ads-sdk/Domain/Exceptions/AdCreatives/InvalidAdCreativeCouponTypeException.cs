using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeCouponTypeException : Exception
    {
        public InvalidAdCreativeCouponTypeException()
        {
        }

        public InvalidAdCreativeCouponTypeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeCouponTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeCouponTypeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
