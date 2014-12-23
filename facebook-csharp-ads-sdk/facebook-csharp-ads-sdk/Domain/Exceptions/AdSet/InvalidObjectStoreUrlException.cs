using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidObjectStoreUrlException : Exception
    {
        public InvalidObjectStoreUrlException()
        {
        }

        public InvalidObjectStoreUrlException(string message) : base(message)
        {
        }

        public InvalidObjectStoreUrlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidObjectStoreUrlException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}