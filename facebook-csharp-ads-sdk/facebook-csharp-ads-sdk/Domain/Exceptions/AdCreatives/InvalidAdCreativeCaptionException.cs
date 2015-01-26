using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeCaptionException : Exception
    {
        public InvalidAdCreativeCaptionException()
        {
        }

        public InvalidAdCreativeCaptionException(string message) : base(message)
        {
        }

        public InvalidAdCreativeCaptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeCaptionException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
