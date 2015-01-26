using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeBodyException : Exception
    {
        public InvalidAdCreativeBodyException()
        {
        }

        public InvalidAdCreativeBodyException(string message) : base(message)
        {
        }

        public InvalidAdCreativeBodyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeBodyException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
