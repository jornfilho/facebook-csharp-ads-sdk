using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.Targetings
{
    public class TargetingDemographicsAgeMaxMustBeLessThan65Exception : Exception
    {
        public TargetingDemographicsAgeMaxMustBeLessThan65Exception()
        {
        }

        public TargetingDemographicsAgeMaxMustBeLessThan65Exception(string message) : base(message)
        {
        }

        public TargetingDemographicsAgeMaxMustBeLessThan65Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TargetingDemographicsAgeMaxMustBeLessThan65Exception([NotNull] SerializationInfo info,
                                                                       StreamingContext context) : base(info, context)
        {
        }
    }
}