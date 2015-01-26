using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeObjectStorySpecException : Exception
    {
        public InvalidAdCreativeObjectStorySpecException()
        {
        }

        public InvalidAdCreativeObjectStorySpecException(string message) : base(message)
        {
        }

        public InvalidAdCreativeObjectStorySpecException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeObjectStorySpecException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
