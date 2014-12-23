using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class StartDateMustBeGreatherThanUtcNowException : Exception
    {
        public StartDateMustBeGreatherThanUtcNowException()
        {
        }

        public StartDateMustBeGreatherThanUtcNowException(string message) : base(message)
        {
        }

        public StartDateMustBeGreatherThanUtcNowException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected StartDateMustBeGreatherThanUtcNowException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}