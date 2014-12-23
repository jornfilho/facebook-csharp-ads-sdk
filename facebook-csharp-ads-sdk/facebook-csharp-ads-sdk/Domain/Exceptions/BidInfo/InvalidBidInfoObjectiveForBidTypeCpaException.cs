﻿using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.BidInfo
{
    public class InvalidBidInfoObjectiveForBidTypeCpaException : Exception
    {
        public InvalidBidInfoObjectiveForBidTypeCpaException()
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpaException(string message) : base(message)
        {
        }

        public InvalidBidInfoObjectiveForBidTypeCpaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidBidInfoObjectiveForBidTypeCpaException([NotNull] SerializationInfo info,
                                                                StreamingContext context) : base(info, context)
        {
        }
    }
}