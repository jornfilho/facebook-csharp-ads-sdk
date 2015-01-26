using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativePageIdException : Exception
    {
        
        public InvalidAdCreativePageIdException()
        {
        }

        public InvalidAdCreativePageIdException(string message) : base(message)
        {
        }

        public InvalidAdCreativePageIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativePageIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
