using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeTitleException : Exception
    {
        public InvalidAdCreativeTitleException()
        {
        }

        public InvalidAdCreativeTitleException(string message) : base(message)
        {
        }

        public InvalidAdCreativeTitleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeTitleException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
