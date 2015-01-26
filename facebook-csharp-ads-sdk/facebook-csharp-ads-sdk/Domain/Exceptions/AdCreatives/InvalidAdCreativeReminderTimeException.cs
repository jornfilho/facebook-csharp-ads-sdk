using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeReminderTimeException : Exception
    {
        public InvalidAdCreativeReminderTimeException()
        {
        }

        public InvalidAdCreativeReminderTimeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeReminderTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeReminderTimeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
