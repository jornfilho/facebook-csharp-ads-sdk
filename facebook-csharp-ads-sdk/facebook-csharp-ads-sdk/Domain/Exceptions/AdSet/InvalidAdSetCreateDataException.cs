using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetCreateDataException : Exception
    {
        public InvalidAdSetCreateDataException()
        {
        }

        public InvalidAdSetCreateDataException(string message) : base(message)
        {
        }

        public InvalidAdSetCreateDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetCreateDataException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}