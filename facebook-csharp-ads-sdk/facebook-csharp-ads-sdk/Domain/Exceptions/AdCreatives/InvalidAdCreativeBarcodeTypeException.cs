using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives
{
    public class InvalidAdCreativeBarcodeTypeException : Exception
    {
        public InvalidAdCreativeBarcodeTypeException()
        {
        }

        public InvalidAdCreativeBarcodeTypeException(string message) : base(message)
        {
        }

        public InvalidAdCreativeBarcodeTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCreativeBarcodeTypeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
