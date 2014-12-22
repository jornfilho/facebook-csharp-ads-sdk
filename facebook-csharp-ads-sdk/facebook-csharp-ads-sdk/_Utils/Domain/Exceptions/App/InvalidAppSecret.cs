using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.App
{
    public class InvalidAppSecret : Exception
    {
        public InvalidAppSecret()
        {
        }

        public InvalidAppSecret(string message)
            : base(message)
        {
        }

        public InvalidAppSecret(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidAppSecret(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAppSecret(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidAppSecret(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
