using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeImageCropsException : Exception
    {
        public InvalidAdCreativeImageCropsException()
        {
        }

        public InvalidAdCreativeImageCropsException(string message) : base(message)
        {
        }

        public InvalidAdCreativeImageCropsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeImageCropsException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
