using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetTargetingException : Exception
    {
        public InvalidAdSetTargetingException()
        {
        }

        public InvalidAdSetTargetingException(string message) : base(message)
        {
        }

        public InvalidAdSetTargetingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetTargetingException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}