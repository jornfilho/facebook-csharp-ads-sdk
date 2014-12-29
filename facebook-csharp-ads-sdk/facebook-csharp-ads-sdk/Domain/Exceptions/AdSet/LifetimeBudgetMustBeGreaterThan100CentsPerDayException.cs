using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class LifetimeBudgetMustBeGreaterThan100CentsPerDayException : Exception
    {
        public LifetimeBudgetMustBeGreaterThan100CentsPerDayException()
        {
        }

        public LifetimeBudgetMustBeGreaterThan100CentsPerDayException(string message) : base(message)
        {
        }

        public LifetimeBudgetMustBeGreaterThan100CentsPerDayException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LifetimeBudgetMustBeGreaterThan100CentsPerDayException([NotNull] SerializationInfo info,
                                                                         StreamingContext context) : base(info, context)
        {
        }
    }
}