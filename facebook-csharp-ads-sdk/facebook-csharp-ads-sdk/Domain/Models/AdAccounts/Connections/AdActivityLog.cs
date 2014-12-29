using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts.Connections;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdAccounts.Connections
{
    /// <summary>
    /// https://developers.facebook.com/docs/reference/ads-api/activity-log/v2.2#account
    /// </summary>
    public class AdActivityLog : BaseObject
    {
        #region Properties
        /// <summary>
        /// <para> Name of event type </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("event_type")]
        public AdActivityLogEventTypesEnum EventType { get; private set; }

        /// <summary>
        /// <para> id of the person who made the change </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("actor_id")]
        public long ActorId { get; private set; }

        /// <summary>
        /// <para> name of the person who made the change </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("actor_name")]
        public string ActorName { get; private set; }
        
        /// <summary>
        /// <para> id of the object on which the action was performed. It can be campaign id, ad set id, adgroup id, audience id, user id etc. </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("object_id")]
        public long ObjectId { get; private set; }
        
        /// <summary>
        /// <para> name of the object on which the action was performed </para>
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("object_name")]
        public string ObjectName { get; private set; }
       
        /// <summary>
        /// <para> timestamp of when the event occured </para>
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        [FacebookName("event_time")]
        public DateTime EventTime { get; private set; }
        #endregion

        #region Metodos para parse das respostas do Facebook
        /// <summary>
        /// Método para parse multiplo dos dados de uma lista de grupo de contas
        /// </summary>
        public BaseObjectsList<AdActivityLog> ParseMultipleResponse(string response)
        {
            var objectResult = new BaseObjectsList<AdActivityLog>();

            if (String.IsNullOrEmpty(response))
                return objectResult;

            var jsonObject = JObject.Parse(response);
            if (jsonObject == null)
                return objectResult;

            #region Error
            if (jsonObject["error"] != null)
            {
                var errorModel = new ApiErrorModelV22().ParseApiResponse(jsonObject);
                objectResult.SetInvalid();
                objectResult.SetApiErrorResonse(errorModel);

                return objectResult;
            }
            #endregion

            if (jsonObject["data"] == null)
                return objectResult;

            foreach (var item in jsonObject["data"])
            {
                if (item.Type != JTokenType.Object)
                    continue;

                var adActivityLog = new AdActivityLog();
                adActivityLog.ParseReadSingleResponse(item.ToString());
                if (!adActivityLog.IsValid)
                    continue;

                objectResult.Add(adActivityLog);
            }
                
            objectResult.SetValid();
            
            return objectResult;
        }
        #endregion
    }
}
