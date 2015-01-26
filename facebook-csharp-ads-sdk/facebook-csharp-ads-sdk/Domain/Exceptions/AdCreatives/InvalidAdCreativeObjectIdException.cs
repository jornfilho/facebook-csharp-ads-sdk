using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeObjectIdException : Exception
    {
        public InvalidAdCreativeObjectIdException()
        {
        }

        public InvalidAdCreativeObjectIdException(string message) : base(message)
        {
        }

        public InvalidAdCreativeObjectIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeObjectIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
