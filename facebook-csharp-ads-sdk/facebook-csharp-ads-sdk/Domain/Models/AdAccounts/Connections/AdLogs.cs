using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts.Connections
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/activity-log/v2.2#account
    /// </summary>
    public class AdLogs : BaseObject
    {
        //exemplo de lista de campos
        //adsetreadfieldsenum
        /*
        event_type emum name of event type, see tables below
        actor_id int id of the person who made the change
        actor_name string name of the person who made the change
        object_id int id of the object on which the action was performed. It can be campaign id, ad set id, adgroup id, audience id, user id etc.
        object_name string name of the object on which the action was performed
        event_time ISO 8601 timestamp of when the event occured
        extra_data JSON object meta data for different event_types
        */
    }
}
