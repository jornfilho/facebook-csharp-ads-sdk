using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidObjectIdException : Exception
    {
        public InvalidObjectIdException()
        {
        }

        public InvalidObjectIdException(string message) : base(message)
        {
        }

        public InvalidObjectIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidObjectIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}