using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.Users
{
    public class InvalidUserAccessToken : Exception
    {
        public InvalidUserAccessToken()
        {
        }

        public InvalidUserAccessToken(string message)
            : base(message)
        {
        }

        public InvalidUserAccessToken(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidUserAccessToken(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidUserAccessToken(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidUserAccessToken(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
