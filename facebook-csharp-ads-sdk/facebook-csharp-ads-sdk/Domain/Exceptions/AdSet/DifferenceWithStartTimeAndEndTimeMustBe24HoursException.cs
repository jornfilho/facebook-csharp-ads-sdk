using System;
using System.Runtime.Serialization;
using facebook_csharp_ads_sdk.Annotations;

namespace facebook_csharp_ads_sdk.Domain.Exceptions.AdSet
{
    public class DifferenceWithStartTimeAndEndTimeMustBe24HoursException : Exception
    {
        public DifferenceWithStartTimeAndEndTimeMustBe24HoursException()
        {
        }

        public DifferenceWithStartTimeAndEndTimeMustBe24HoursException(string message) : base(message)
        {
        }

        public DifferenceWithStartTimeAndEndTimeMustBe24HoursException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DifferenceWithStartTimeAndEndTimeMustBe24HoursException([NotNull] SerializationInfo info,
                                                                          StreamingContext context)
            : base(info, context)
        {
        }
    }
}