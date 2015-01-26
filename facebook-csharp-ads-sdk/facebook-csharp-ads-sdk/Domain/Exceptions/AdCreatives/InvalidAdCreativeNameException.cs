using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeNameException : Exception
    {
        public InvalidAdCreativeNameException()
        {
        }

        public InvalidAdCreativeNameException(string message) : base(message)
        {
        }

        public InvalidAdCreativeNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeNameException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
