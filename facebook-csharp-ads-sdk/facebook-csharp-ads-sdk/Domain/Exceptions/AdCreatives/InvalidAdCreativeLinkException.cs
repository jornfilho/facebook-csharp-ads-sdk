using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeLinkException : Exception
    {
        public InvalidAdCreativeLinkException()
        {
        }

        public InvalidAdCreativeLinkException(string message) : base(message)
        {
        }

        public InvalidAdCreativeLinkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeLinkException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
