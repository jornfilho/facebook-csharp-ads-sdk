using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignStatusException : Exception
    {
        public InvalidAdCampaignStatusException()
        {
        }

        public InvalidAdCampaignStatusException(string message) : base(message)
        {
        }

        public InvalidAdCampaignStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidAdCampaignStatusException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}