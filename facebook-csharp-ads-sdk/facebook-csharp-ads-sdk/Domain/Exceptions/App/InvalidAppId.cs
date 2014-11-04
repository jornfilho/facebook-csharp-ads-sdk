using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.App
{
    public class InvalidAppId : Exception
    {
        public InvalidAppId()
        {
        }

        public InvalidAppId(string message)
            : base(message)
        {
        }

        public InvalidAppId(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidAppId(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAppId(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidAppId(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
