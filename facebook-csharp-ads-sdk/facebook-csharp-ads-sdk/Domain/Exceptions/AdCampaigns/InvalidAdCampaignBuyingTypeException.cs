using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns
{
    public class InvalidAdCampaignBuyingTypeException : Exception
    {
        public InvalidAdCampaignBuyingTypeException()
        {
        }

        public InvalidAdCampaignBuyingTypeException(string message) : base(message)
        {
        }

        public InvalidAdCampaignBuyingTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidAdCampaignBuyingTypeException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}