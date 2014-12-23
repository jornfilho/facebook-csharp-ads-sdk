using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections
{
    /// <summary>
    /// Fields to read an ad account or ad set activity log
    /// </summary>
    public enum AdActivityLogFieldsEnum
    {
        /// <summary>
        /// <para> Name of event type </para>
        /// </summary>
        [FacebookName("event_type")]
        EventType,

        /// <summary>
        /// <para> id of the person who made the change </para>
        /// </summary>
        [FacebookName("actor_id")]
        ActorId,

        /// <summary>
        /// <para> name of the person who made the change </para>
        /// </summary>
        [FacebookName("actor_name")]
        ActorName,
        
        /// <summary>
        /// <para> id of the object on which the action was performed. It can be campaign id, ad set id, adgroup id, audience id, user id etc. </para>
        /// </summary>
        [FacebookName("object_id")]
        ObjectId,
        
        /// <summary>
        /// <para> name of the object on which the action was performed </para>
        /// </summary>
        [FacebookName("object_name")]
        ObjectName,
        
        /// <summary>
        /// <para> timestamp of when the event occured </para>
        /// </summary>
        [FacebookName("event_time")]
        EventTime,
    }
}
