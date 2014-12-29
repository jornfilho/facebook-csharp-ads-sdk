using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class EndTimeRequiredInLifetimeBudgetException : Exception
    {
        public EndTimeRequiredInLifetimeBudgetException()
        {
        }

        public EndTimeRequiredInLifetimeBudgetException(string message) : base(message)
        {
        }

        public EndTimeRequiredInLifetimeBudgetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EndTimeRequiredInLifetimeBudgetException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}