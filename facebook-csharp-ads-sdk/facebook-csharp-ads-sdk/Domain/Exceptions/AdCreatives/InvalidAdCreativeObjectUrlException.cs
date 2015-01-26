using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeObjectUrlException : Exception
    {
        public InvalidAdCreativeObjectUrlException()
        {
        }

        public InvalidAdCreativeObjectUrlException(string message) : base(message)
        {
        }

        public InvalidAdCreativeObjectUrlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeObjectUrlException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
