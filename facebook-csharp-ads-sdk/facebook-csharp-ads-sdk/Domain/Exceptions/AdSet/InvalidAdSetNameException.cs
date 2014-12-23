using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class InvalidAdSetNameException : Exception
    {
        public InvalidAdSetNameException()
        {
        }

        public InvalidAdSetNameException(string message) : base(message)
        {
        }

        public InvalidAdSetNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdSetNameException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}