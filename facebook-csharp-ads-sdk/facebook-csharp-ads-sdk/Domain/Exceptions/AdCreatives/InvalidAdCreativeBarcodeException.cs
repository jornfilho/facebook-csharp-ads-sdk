using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeBarcodeException : Exception
    {
        public InvalidAdCreativeBarcodeException()
        {
        }

        public InvalidAdCreativeBarcodeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeBarcodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeBarcodeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
