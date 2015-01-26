using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeObjectStoryIdException : Exception
    {
        public InvalidAdCreativeObjectStoryIdException()
        {
        }

        public InvalidAdCreativeObjectStoryIdException(string message) : base(message)
        {
        }

        public InvalidAdCreativeObjectStoryIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeObjectStoryIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
