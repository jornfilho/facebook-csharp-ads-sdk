using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignNameException : Exception
    {
        public InvalidAdCampaignNameException()
        {
        }

        public InvalidAdCampaignNameException(string message)
            : base(message)
        {
        }

        public InvalidAdCampaignNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAdCampaignNameException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}