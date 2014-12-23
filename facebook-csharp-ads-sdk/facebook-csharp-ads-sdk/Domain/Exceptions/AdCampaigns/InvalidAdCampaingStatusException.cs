using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaingStatusException : Exception
    {
        public InvalidAdCampaingStatusException()
        {
        }

        public InvalidAdCampaingStatusException(string message) : base(message)
        {
        }

        public InvalidAdCampaingStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidAdCampaingStatusException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}