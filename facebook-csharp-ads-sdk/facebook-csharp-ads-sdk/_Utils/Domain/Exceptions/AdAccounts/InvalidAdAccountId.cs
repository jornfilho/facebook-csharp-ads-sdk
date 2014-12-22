using System;
using System.Runtime.Serialization;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts
{
    public class InvalidAdAccountId : Exception
    {
        public InvalidAdAccountId()
        {
        }

        public InvalidAdAccountId(string message)
            : base(message)
        {
        }

        public InvalidAdAccountId(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidAdAccountId(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAdAccountId(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidAdAccountId(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
