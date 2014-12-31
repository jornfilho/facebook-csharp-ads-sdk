using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.Targetings
{
    public class TargetingDemographicsAgeMinMustBeGreatherThan13Exception : Exception
    {
        public TargetingDemographicsAgeMinMustBeGreatherThan13Exception()
        {
        }

        public TargetingDemographicsAgeMinMustBeGreatherThan13Exception(string message) : base(message)
        {
        }

        public TargetingDemographicsAgeMinMustBeGreatherThan13Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TargetingDemographicsAgeMinMustBeGreatherThan13Exception([NotNull] SerializationInfo info,
                                                                           StreamingContext context)
            : base(info, context)
        {
        }
    }
}