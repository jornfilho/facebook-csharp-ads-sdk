using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignCreateDataException : Exception
    {
        public InvalidAdCampaignCreateDataException()
        {
        }

        public InvalidAdCampaignCreateDataException(string message) : base(message)
        {
        }

        public InvalidAdCampaignCreateDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidAdCampaignCreateDataException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}