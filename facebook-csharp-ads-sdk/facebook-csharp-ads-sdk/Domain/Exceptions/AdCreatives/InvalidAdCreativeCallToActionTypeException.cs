using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeCallToActionTypeException : Exception
    {
        public InvalidAdCreativeCallToActionTypeException()
        {
        }

        public InvalidAdCreativeCallToActionTypeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeCallToActionTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeCallToActionTypeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
