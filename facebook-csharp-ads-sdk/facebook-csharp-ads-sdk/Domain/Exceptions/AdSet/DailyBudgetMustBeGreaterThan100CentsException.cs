using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class DailyBudgetMustBeGreaterThan100CentsException : Exception
    {
        public DailyBudgetMustBeGreaterThan100CentsException()
        {
        }

        public DailyBudgetMustBeGreaterThan100CentsException(string message) : base(message)
        {
        }

        public DailyBudgetMustBeGreaterThan100CentsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DailyBudgetMustBeGreaterThan100CentsException([NotNull] SerializationInfo info,
                                                                StreamingContext context) : base(info, context)
        {
        }
    }
}