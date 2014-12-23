using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetStatusException : Exception
    {
        public InvalidAdSetStatusException()
        {
        }

        public InvalidAdSetStatusException(string message) : base(message)
        {
        }

        public InvalidAdSetStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetStatusException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}