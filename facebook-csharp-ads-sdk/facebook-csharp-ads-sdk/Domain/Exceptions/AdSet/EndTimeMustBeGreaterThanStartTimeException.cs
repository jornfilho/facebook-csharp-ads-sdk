using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class EndTimeMustBeGreaterThanStartTimeException : Exception
    {
        public EndTimeMustBeGreaterThanStartTimeException()
        {
        }

        public EndTimeMustBeGreaterThanStartTimeException(string message) : base(message)
        {
        }

        public EndTimeMustBeGreaterThanStartTimeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EndTimeMustBeGreaterThanStartTimeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}