using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeMessageException : Exception
    {
        public InvalidAdCreativeMessageException()
        {
        }

        public InvalidAdCreativeMessageException(string message) : base(message)
        {
        }

        public InvalidAdCreativeMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeMessageException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
