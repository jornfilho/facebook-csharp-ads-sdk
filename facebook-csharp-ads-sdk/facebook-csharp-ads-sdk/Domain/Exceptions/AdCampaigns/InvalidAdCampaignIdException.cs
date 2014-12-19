using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignIdException : Exception
    {
        public InvalidAdCampaignIdException()
        {
        }

        public InvalidAdCampaignIdException(string message) : base(message)
        {
        }

        public InvalidAdCampaignIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCampaignIdException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}