using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class LifetimeBudgetOrDailyBudgetRequiredException : Exception
    {
        public LifetimeBudgetOrDailyBudgetRequiredException()
        {
        }

        public LifetimeBudgetOrDailyBudgetRequiredException(string message) : base(message)
        {
        }

        public LifetimeBudgetOrDailyBudgetRequiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LifetimeBudgetOrDailyBudgetRequiredException([NotNull] SerializationInfo info,
                                                               StreamingContext context) : base(info, context)
        {
        }
    }
}