using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.FacebookConfig
{
    public class InvalidAccessToken : Exception
    {
        public InvalidAccessToken()
        {
        }

        public InvalidAccessToken(string message)
            : base(message)
        {
        }

        public InvalidAccessToken(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidAccessToken(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAccessToken(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidAccessToken(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
