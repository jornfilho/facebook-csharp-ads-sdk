using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignObjectiveException : Exception
    {
        public InvalidAdCampaignObjectiveException()
        {
        }

        public InvalidAdCampaignObjectiveException(string message) : base(message)
        {
        }

        public InvalidAdCampaignObjectiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCampaignObjectiveException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}