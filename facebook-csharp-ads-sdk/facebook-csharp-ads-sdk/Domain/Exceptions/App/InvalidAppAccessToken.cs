using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.App
{
    public class InvalidAppAccessToken : Exception
    {
        public InvalidAppAccessToken()
        {
        }

        public InvalidAppAccessToken(string message)
            : base(message)
        {
        }

        public InvalidAppAccessToken(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidAppAccessToken(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAppAccessToken(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidAppAccessToken(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
